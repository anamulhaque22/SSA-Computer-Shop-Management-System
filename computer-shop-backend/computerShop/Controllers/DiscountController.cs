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
    public class DiscountController : ApiController
    {

        [HttpPost]
        [Route("discount/create")]
        [AdminLogged]
        public HttpResponseMessage Create(DiscountDTO obj)
        {
            try
            {
                if (!ModelState.IsValid) { return Request.CreateResponse(HttpStatusCode.NotAcceptable, new { message = "Invalid Response" }); }
                if (DiscountService.Create(obj)) return Request.CreateResponse(HttpStatusCode.Created, new { message = "Discount Added successfully"});
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = "Unsuccessfull" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [HttpPost]
        [Route("discount/delete")]
        [AdminLogged]
        public HttpResponseMessage Delete(DiscountModel obj)
        {
            try
            {
                if (!ModelState.IsValid) { return Request.CreateResponse(HttpStatusCode.NotAcceptable, new { message = "Invalid Response" }); }
                if (DiscountService.Delete(obj.Id)) return Request.CreateResponse(HttpStatusCode.OK, new { message = "Discount Deleted successfully" });
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = "Unsuccessfull" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [HttpGet]
        [Route("discount/get/{Id}")]
        [AdminLogged]
        public HttpResponseMessage Get(int Id)
        {
            try
            {
                if (!ModelState.IsValid) { return Request.CreateResponse(HttpStatusCode.NotAcceptable, new { message = "Invalid Response" }); }
                return Request.CreateResponse(HttpStatusCode.OK, DiscountService.Get(Id));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [HttpPost]
        [Route("discount/getAll")]
        [AdminLogged]
        public HttpResponseMessage GetAll()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, DiscountService.Get());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [HttpGet]
        [Route("discount/check/{coupon}")]
        public HttpResponseMessage isValid(string coupon)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, DiscountService.isValid(coupon));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
    }
}
