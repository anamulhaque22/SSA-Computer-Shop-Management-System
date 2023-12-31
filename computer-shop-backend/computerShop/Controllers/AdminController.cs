using BLL.DTOs;
using BLL.Services;
using computerShop.Auth;
using computerShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace computerShop.Controllers
{
    [EnableCors("*","*","*")]
    public class AdminController : ApiController
    {
        [HttpPost]
        [Route("admin/createForm")]
        public HttpResponseMessage CreateForm()
        {
            try
            {
                //status 0 = Model Invalid
                //status 1 = Confirm Password Invalid
                //status 2 = OTP Invalid
                //status 3 = License Key Invalid
                //status 4 = OTP sent to your email
                //status 5 = Username Duplicate
                //status 6 = Email Duplicate
                //status 7 = Invalid file format or size
                //status 8 = OTP Generation Failed

                var obj = new AdminSingupDTO();
                obj.Username = HttpContext.Current.Request.Form["Username"];
                obj.Email = HttpContext.Current.Request.Form["Email"];
                obj.Password = HttpContext.Current.Request["Password"];
                obj.cPassword = HttpContext.Current.Request["cPassword"];
                obj.Name= HttpContext.Current.Request.Form["Name"];
                obj.Gender = HttpContext.Current.Request.Form["Gender"];
                obj.DateOfBirth = DateTime.Parse(HttpContext.Current.Request.Form["DateOfBirth"]);
                obj.Nid = HttpContext.Current.Request.Form["Nid"];
                obj.Phone = HttpContext.Current.Request.Form["Phone"];
                obj.Address = HttpContext.Current.Request.Form["Address"];
                obj.Key = HttpContext.Current.Request.Form["Key"];

                if (!ModelState.IsValid) { return Request.CreateResponse(HttpStatusCode.NotAcceptable, new { message = "Invalid Response", status = 0 }); }
                if (!confirmPassChecker(obj.Password, obj.cPassword)) { return Request.CreateResponse(HttpStatusCode.NotAcceptable, new { message = "Password and Confirm Password not matched", status = 1 }); }
                if (!AdminService.isUsernameUnique(obj.Username)) { return Request.CreateResponse(HttpStatusCode.OK, new { message = "Username Already Exist. Choose a different one", status = 5 }); }
                if (!AdminService.isEmailUnique(obj.Email)) { return Request.CreateResponse(HttpStatusCode.OK, new { message = "Email Already Exist. Choose a different one", status = 6 }); }
                if (!ProductKeyService.IsValid(obj.Key)) { return Request.CreateResponse(HttpStatusCode.NotAcceptable, new { message = "Invalid Product Key", status = 3 }); }

                var httpRequest = HttpContext.Current.Request;
                if (httpRequest.Files.Count > 0)
                {
                    var postedFile = httpRequest.Files[0];

                    // Check file type and size
                    if (IsValidFile(postedFile))
                    {
                        var fileName = SaveFile(postedFile);
                        obj.PictureName = fileName;
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotAcceptable, new { message = "Invalid file format or size", status = 7 });
                    }
                }

                var otp = AdminService.GenerateOTP();

                // Send OTP to the user's email
                if(AdminService.SendOTPEmail(obj.Email, otp))
                {
                    // Save the OTP in the server's OTP table
                    if(!AdminService.SaveOTP(obj.Username, otp)){
                        return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = "OTP Generation Failed", status = 8 });
                    }
                }

                if (AdminService.Signup(obj) == true) return Request.CreateResponse(HttpStatusCode.OK, new { message = "OTP sent to your email. Submit on url and Create Account", url = "https://localhost:44389/admin/create/submitOtp", status = 4 });
                //if (AdminService.Signup(obj) == true) return Request.CreateResponse(HttpStatusCode.Created, new { message = "Admin Information Added successfully", status = 4 });
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = "Unsuccessfull" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [HttpPost]
        [Route("admin/create/submitOtp")]
        public HttpResponseMessage SubmitOtp()
        {
            //status 9 = Account Created
            try
            {
                string Username = HttpContext.Current.Request.Form["Username"];
                string Otp = HttpContext.Current.Request.Form["Otp"];
                if (AdminService.otpMatched(Username, Otp) && AdminService.UpdateOtpVerificationStatus(Username) && AdminService.DeleteOtp(Username))
                {
                    return Request.CreateResponse(HttpStatusCode.Created, new { message = "Admin Information Added successfully", status = 9 });
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = "Unsuccessfull" });
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        //[HttpPost]
        //[Route("admin/createAsJson")]
        public HttpResponseMessage Create(AdminSingupDTO obj)
        {
            try
            {
                //status 0 = Model Invalid
                //status 1 = Confirm Password Invalid
                //status 2 = OTP Invalid
                //status 3 = License Key Invalid
                //status 4 = create success
                //status 5 = Username Duplicate
                //status 6 = Email Duplicate
                if (!ModelState.IsValid) { return Request.CreateResponse(HttpStatusCode.NotAcceptable, new { message = "Invalid Response", status=0 }); }
                if (!confirmPassChecker(obj.Password, obj.cPassword)) { return Request.CreateResponse(HttpStatusCode.NotAcceptable, new { message = "Password and Confirm Password not matched", status = 1 }); }
                if (!AdminService.isUsernameUnique(obj.Username)) { return Request.CreateResponse(HttpStatusCode.OK, new { message = "Username Already Exist. Choose a different one", status = 5 }); }
                if (!AdminService.isEmailUnique(obj.Email)) { return Request.CreateResponse(HttpStatusCode.OK, new { message = "Email Already Exist. Choose a different one", status = 6 }); }
                if (!ProductKeyService.IsValid(obj.Key)) { return Request.CreateResponse(HttpStatusCode.NotAcceptable, new { message = "Invalid Product Key", status = 3 }); }

                if (AdminService.Signup(obj) == true) return Request.CreateResponse(HttpStatusCode.Created, new { message = "Admin Information Added successfully", status=4 });
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = "Unsuccessfull" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        private bool IsValidFile(HttpPostedFile file)
        {
            // Check file type
            string[] allowedFileTypes = { "image/jpeg", "image/png", "image/jpg" };
            if (!allowedFileTypes.Contains(file.ContentType))
            {
                return false;
            }

            // Check file size (5MB limit)
            int maxFileSize = 5 * 1024 * 1024; // 5MB
            return file.ContentLength <= maxFileSize;
        }

        private string SaveFile(HttpPostedFile file)
        {
            // Specify the folder path
            
            //var folderPath = HttpContext.Current.Server.MapPath("~/Pictures/");
            var folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "AdminPictures");

            // Create the folder if it doesn't exist
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Generate a unique file name
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            // Combine the folder path and file name
            var filePath = Path.Combine(folderPath, fileName);

            // Save the file, overwriting if it already exists
            file.SaveAs(filePath);

            return fileName;
        }

        [HttpPost]
        [Route("admin/update")]
        [AdminLogged]
        public HttpResponseMessage Update(AdminUpdateDTO obj)
        {
            try
            {
                //status 0 = Model Invalid
                //status 1 = Confirm Password Invalid
                //status 2 = OTP Invalid
                //status 4 = Update success
                var token = Request.Headers.Authorization?.ToString();

                if (!ModelState.IsValid) { return Request.CreateResponse(HttpStatusCode.NotAcceptable, new { message = "Invalid Response", status = 0 }); }

                if (AdminService.Update(obj, token))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { message = "Admin Information Updated successfully", status = 4 });
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = "Unsuccessfull" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [HttpPost]
        [Route("admin/updatePassword")]
        [AdminLogged]
        public HttpResponseMessage UpdatePassword(AdminUpdatePasswordModel obj)
        {
            try
            {
                //status 0 = Model Invalid
                //status 1 = Confirm Password Invalid
                //status 2 = OTP Invalid
                //status 3 = Current Password not matched
                //status 4 = Update success
                var token = Request.Headers.Authorization?.ToString();
                if (!ModelState.IsValid) { return Request.CreateResponse(HttpStatusCode.NotAcceptable, new { message = "Invalid Response", status = 0 }); }
                if(!AdminService.isCurrPassExist(token, obj.currPassword))
                {
                    return Request.CreateResponse(HttpStatusCode.NotAcceptable, new { message = "Current Password not matched", status = 3 });
                }
                if (!confirmPassChecker(obj.Password, obj.cPassword)) { return Request.CreateResponse(HttpStatusCode.NotAcceptable, new { message = "Password and Confirm Password not matched", status = 1 }); }

                if (AdminService.UpdatePassword(token, obj.Password))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { message = "Password Changed successfully", status = 4 });
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = "Unsuccessfull" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [HttpPost]
        [Route("admin/updateProfilePicture")]
        [AdminLogged]
        public HttpResponseMessage UpdateProfilePicture()
        {
            try
            {
                //status 4 = Update success
                //status 7 = Invalid file format or size

                var token = Request.Headers.Authorization?.ToString();
                var httpRequest = HttpContext.Current.Request;
                if (httpRequest.Files.Count > 0)
                {
                    var postedFile = httpRequest.Files[0];

                    // Check file type and size
                    if (IsValidFile(postedFile))
                    {
                        var fileName = SaveFile(postedFile);
                        if (AdminService.UpdateProfilePicture(token, fileName))
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, new { message = "Profile Picture Updated successfully", status = 4 });
                        }
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotAcceptable, new { message = "Invalid file format or size", status = 7 });
                    }
                }
                

               
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = "Unsuccessfull" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [HttpPost]
        [AdminLogged]
        [Route("admin/getProfilePicture")]
        public IHttpActionResult GetProfilePicture()
        {
            var token = Request.Headers.Authorization?.ToString();
            string fileName = AdminService.GetPictureNameFromToken(token);

            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "AdminPictures");
            string filePath = Path.Combine(folderPath, fileName);

            if (File.Exists(filePath))
            {
                byte[] fileBytes = File.ReadAllBytes(filePath);
                return Ok(fileBytes);  // Return the image bytes in the response
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        [Route("admin/updateEmail")]
        [AdminLogged]
        public HttpResponseMessage UpdateEmail(AdminUpdateEmailModel obj)
        {
            try
            {
                //status 0 = Model Invalid
                //status 4 = Update success
                //status 6 = Email Duplicate
                var token = Request.Headers.Authorization?.ToString();
                if (!ModelState.IsValid) { return Request.CreateResponse(HttpStatusCode.NotAcceptable, new { message = "Invalid Response", status = 0 }); }
                if (!AdminService.isEmailUnique(obj.Email)) { return Request.CreateResponse(HttpStatusCode.OK, new { message = "Email Already Exist. Choose a different one", status = 6 }); }

                if (AdminService.UpdateEmail(token, obj.Email))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { message = "Email Changed successfully", status = 4 });
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = "Unsuccessfull" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [HttpPost]
        [Route("admin/Get")]
        [AdminLogged]
        public HttpResponseMessage Get()
        {
            try
            {
                var token = Request.Headers.Authorization?.ToString();
                var username = AdminService.GetUsernameFromToken(token);
                var response = AdminService.Get(username);
                if (response != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { message = "No Data Found"});
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [HttpPost]
        [Route("admin/login")]
        public HttpResponseMessage Login(AdminLoginModel obj)
        {
            try
            {
                var response = AuthService.AdminAuthenticate(obj.Username, obj.Password);
                if (response != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { message = "Invalid Credentials" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [HttpPost]
        [Route("admin/logout")]
        [AdminLogged]
        public HttpResponseMessage Logout()
        {
            try
            {
                var token = Request.Headers.Authorization?.ToString();
                if (!string.IsNullOrEmpty(token) && AuthService.AdminLogout(token))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Logout successful" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Invalid token" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        public bool confirmPassChecker(string password, string cPassword)
        {
            if (password == cPassword)
            {
                return true;
            }
            return false;
        }
    }
}
