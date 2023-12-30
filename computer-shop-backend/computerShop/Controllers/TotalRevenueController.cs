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
    public class TotalRevenueController : ApiController
    {
        [HttpPost]
        [Route("totalRevenue/create")]
        [AdminLogged]
        public HttpResponseMessage Create(TotalRevenueDTO obj)
        {
            try
            {
                if (!ModelState.IsValid) { return Request.CreateResponse(HttpStatusCode.NotAcceptable, new { message = "Invalid Response" }); }
                if (TotalRevenuesService.Create(obj)) return Request.CreateResponse(HttpStatusCode.Created, new { message = obj.Year+ "'s Total Revenue Data Added successfully" });
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = "Unsuccessfull" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [HttpPost]
        [Route("totalRevenue/get")]
        [AdminLogged]
        public HttpResponseMessage Get(TotalRevenueDTO obj)
        {
            try
            {
                if (!ModelState.IsValid) { return Request.CreateResponse(HttpStatusCode.NotAcceptable, new { message = "Invalid Response" }); }
                return Request.CreateResponse(HttpStatusCode.OK, TotalRevenuesService.Get(obj.Year));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [HttpPost]
        [Route("totalRevenue/getAll")]
        [AdminLogged]
        public HttpResponseMessage GetAll()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, TotalRevenuesService.Get());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [HttpPost]
        [Route("totalRevenue/update")]
        [AdminLogged]
        public HttpResponseMessage Update(TotalRevenueDTO obj)
        {
            try
            {
                if (!ModelState.IsValid) { return Request.CreateResponse(HttpStatusCode.NotAcceptable, new { message = "Invalid Response" }); }
                if (TotalRevenuesService.Update(obj)) {
                    return Request.CreateResponse(HttpStatusCode.OK, new { message = obj.Year + "'s Total Revenue Data Updated successfully" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { message = obj.Year + "'s Total Revenue Data NOT Updated" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
    }
}
