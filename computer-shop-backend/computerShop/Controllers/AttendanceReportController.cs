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
    public class AttendanceReportController : ApiController
    {
        [HttpGet]
        [Route("api/AttendanceReport")]

        public HttpResponseMessage AttendanceReports()
        {
            try
            {
                var data = AttendanceReportService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/Attendance/{id}")]

        public HttpResponseMessage AttendanceReports(int id)
        {
            try
            {
                var data = AttendanceReportService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }


        [HttpPost]
        [Route("api/Attendance/add")]
        public HttpResponseMessage Add(AttendanceReportDTO obj)
        {
            try
            {
                var res = AttendanceReportService.Create(obj);
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

                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message, Data = obj });
            }
        }

        [HttpPost]
        [Route("api/Attendance/Update")]
        public HttpResponseMessage Update(AttendanceReportDTO obj)
        {
            try
            {
                var res = AttendanceReportService.Upadte(obj);
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

                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message, Data = obj });
            }
        }

        [HttpPost]
        [Route("api/Attendance/Delete/{id}")]

        public HttpResponseMessage Delete(int id)
        {
            try
            {

                return Request.CreateResponse(HttpStatusCode.OK, AttendanceReportService.Delete(id));
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }

    }
}
