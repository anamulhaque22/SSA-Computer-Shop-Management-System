using BLL.DTOs;
using BLL.Services;
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
