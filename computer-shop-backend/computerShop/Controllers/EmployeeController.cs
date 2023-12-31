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
    }
}
