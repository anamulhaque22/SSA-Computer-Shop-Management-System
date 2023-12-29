using BLL.DTOs;
using BLL.Services;
using computerShop.Auth;
using computerShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace computerShop.Controllers
{
    public class AdminController : ApiController
    {
        [HttpPost]
        [Route("admin/create")]
        [AdminLogged]
        public HttpResponseMessage Create(AdminSingupDTO obj)
        {
            try
            {
                //status 0 = Model Invalid
                //status 1 = Confirm Password Invalid
                //status 2 = OTP Invalid
                //status 3 = License Key Invalid
                //status 4 = create success
                if (!ModelState.IsValid) { return Request.CreateResponse(HttpStatusCode.NotAcceptable, new { message = "Invalid Response", status=0 }); }
                if (!confirmPassChecker(obj.Password, obj.cPassword)) { return Request.CreateResponse(HttpStatusCode.NotAcceptable, new { message = "Password and Confirm Password not matched", status = 1 }); }
                if (!ProductKeyService.IsValid(obj.Key)) { return Request.CreateResponse(HttpStatusCode.NotAcceptable, new { message = "Invalid Product Key", status = 3 }); }
                                
                if (AdminService.Signup(obj) == true) return Request.CreateResponse(HttpStatusCode.Created, new { message = "Admin Information Added successfully", status=4 });
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
        public HttpResponseMessage Get(AdminDTO obj)
        {
            try
            {
                var response = AdminService.Get(obj.Username);
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
