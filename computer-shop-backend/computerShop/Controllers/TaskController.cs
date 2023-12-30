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
    public class TaskController : ApiController
    {
        [HttpPost]
        [Route("task/create")]
        [AdminLogged]
        public HttpResponseMessage Create(TaskDTO obj)
        {
            try
            {
                if (!ModelState.IsValid) { return Request.CreateResponse(HttpStatusCode.NotAcceptable, new { message = "Invalid Response" }); }
                if (TaskService.Create(obj)) return Request.CreateResponse(HttpStatusCode.Created, new { message = "Task Added successfully" });
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = "Unsuccessfull" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [HttpPost]
        [Route("task/delete")]
        [AdminLogged]
        public HttpResponseMessage Delete(TaskModel obj)
        {
            try
            {
                if (!ModelState.IsValid) { return Request.CreateResponse(HttpStatusCode.NotAcceptable, new { message = "Invalid Response" }); }
                if (TaskService.Delete(obj.Id)) return Request.CreateResponse(HttpStatusCode.OK, new { message = "Task Deleted successfully" });
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = "Unsuccessfull" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [HttpPost]
        [Route("task/get")]
        [AdminLogged]
        public HttpResponseMessage Get(TaskModel obj)
        {
            try
            {
                if (!ModelState.IsValid) { return Request.CreateResponse(HttpStatusCode.NotAcceptable, new { message = "Invalid Response" }); }
                return Request.CreateResponse(HttpStatusCode.OK, TaskService.Get(obj.Id));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [HttpPost]
        [Route("task/getAll")]
        [AdminEmployeeLogged]
        public HttpResponseMessage GetAll()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, TaskService.Get());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
    }
}
