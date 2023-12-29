using BLL.DTOs;
using BLL.Services;
using computerShop.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace computerShop.Controllers
{
    [EnableCors("*", "*", "*")]
    public class ModeratorController : ApiController
    {
        [HttpGet]
        [Route("api/Moderator")]
        public HttpResponseMessage Moderators()
        {
            try
            {
                var data = ModeratorService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);


            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });

            }
        }


        [HttpGet]
        [Route("api/Moderator/{id}")]
        public HttpResponseMessage Moderator(int id)
        {
            try
            {
                var data = ModeratorService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [Logged]
        [HttpGet]
        [Route("api/Moderator/{id}/salary")]
        public HttpResponseMessage MSalary(int id)
        {
            try
            {
                var data = ModeratorService.Getwithsalary(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [Logged]
        [HttpGet]
        [Route("api/Moderator/{id}/AttendanceReport")]
        public HttpResponseMessage MAttendanceReport(int id)
        {
            try
            {
                var data = ModeratorService.GetWithAttenden(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }

        }

        [HttpPost]
        [Route("api/Moderator/add")]

        public HttpResponseMessage Add(ModeratorDTO obj)
        {
            try
            {
                var res = ModeratorService.Create(obj);
                if (res)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Inserted", Data = obj });

                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = "Not Inserted", Data = obj });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message, });
            }

        }

        [HttpPost]
        [Route("api/Moderator/update")]

        public HttpResponseMessage Update(ModeratorDTO obj)
        {
            try
            {
                var res = ModeratorService.Update(obj);
                if (res)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Update", Data = obj });

                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = "Not Update", Data = obj });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message, });
            }
        }


        [HttpPost]
        [Route("api/Moderator/Delete/{id}")]

        public HttpResponseMessage Delete(int id)
        {
            try
            {

                return Request.CreateResponse(HttpStatusCode.OK, ModeratorService.Delete(id));
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }


        [HttpPost]
        [Route("api/Moderator/change-password/{Id}")]

        public HttpResponseMessage ChangePassword(int Id, ChangePasswordDTO changePassword)
        {
            var moderator = ModeratorService.Get(Id);
            if (moderator != null)
            {
                try
                {
                    var res = ModeratorService.ChangePassword(Id, changePassword);
                    return Request.CreateResponse(HttpStatusCode.OK, EmailService.SendEmail(Id));
                    //return Request.CreateResponse(HttpStatusCode.OK, res);
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        
    }
}
