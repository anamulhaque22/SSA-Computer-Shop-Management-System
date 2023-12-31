using BLL.Services;
using computerShop.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace computerShop.Controllers
{
    public class EmployeeController : ApiController
    {
        [HttpPost]
        [Route("employee/empOfTheMonth")]
        [AdminLogged]
        public HttpResponseMessage GetEmployeeOfTheMonth()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, EmployeeService.GetEmployeeOfTheMonth());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [HttpPost]
        [Route("employee/getEmployeeWage")]
        [AdminLogged]
        public HttpResponseMessage GetEmployeeWage()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { wage = EmployeeService.GetTotalEmployeeWage() });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [HttpPost]
        [Route("employee/nonApprovedEmployees")]
        [AdminLogged]
        public HttpResponseMessage GetNonApprovedEmployees()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, EmployeeService.NonApprovedEmployeeList());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [HttpGet]
        [Route("employee/approve/{id}")]
        [AdminLogged]
        public HttpResponseMessage ApproveEmployee(int id)
        {
            try
            {
                if (EmployeeService.AdminApprove(id))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new {message = "Emmployee Approved"});
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { message = "Emmployee Not Approved" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [HttpGet]
        [Route("employee/delete/{id}")]
        [AdminLogged]
        public HttpResponseMessage DeleteEmployee(int id)
        {
            try
            {
                if (EmployeeService.Delete(id))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { message = "Emmployee Data Removed" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { message = "Emmployee Data Not Removed" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
    }
}
