using BLL.DTOs;
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
    public class TotalSaleController : ApiController
    {
        [HttpPost]
        [Route("totalSale/create")]
        [AdminLogged]
        public HttpResponseMessage Create(TotalSaleDTO obj)
        {
            try
            {
                if (!ModelState.IsValid) { return Request.CreateResponse(HttpStatusCode.NotAcceptable, new { message = "Invalid Response" }); }
                if (TotalSaleService.Create(obj)) return Request.CreateResponse(HttpStatusCode.Created, new { message = obj.Year + "'s Total Sale Data Added successfully" });
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = "Unsuccessfull" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [HttpPost]
        [Route("totalSale/get")]
        [AdminLogged]
        public HttpResponseMessage Get(TotalSaleDTO obj)
        {
            try
            {
                if (!ModelState.IsValid) { return Request.CreateResponse(HttpStatusCode.NotAcceptable, new { message = "Invalid Response" }); }
                return Request.CreateResponse(HttpStatusCode.OK, TotalSaleService.Get(obj.Year));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [HttpPost]
        [Route("totalSale/getAll")]
        [AdminLogged]
        public HttpResponseMessage GetAll()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, TotalSaleService.Get());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [HttpPost]
        [Route("totalSale/update")]
        [AdminLogged]
        public HttpResponseMessage Update(TotalSaleDTO obj)
        {
            try
            {
                if (!ModelState.IsValid) { return Request.CreateResponse(HttpStatusCode.NotAcceptable, new { message = "Invalid Response" }); }
                if (TotalSaleService.Update(obj))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { message = obj.Year + "'s Total Sales Data Updated successfully" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { message = obj.Year + "'s Total Sales Data NOT Updated" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
    }
}
