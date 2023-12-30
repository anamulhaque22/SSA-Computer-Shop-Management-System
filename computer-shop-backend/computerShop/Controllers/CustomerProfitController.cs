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
    public class CustomerProfitController : ApiController
    {

        [HttpPost]
        [Route("customer/profit/create")]
        [AdminLogged]
        public HttpResponseMessage Create(CustomerProfitDTO obj)
        {
            try
            {
                if (!ModelState.IsValid) { return Request.CreateResponse(HttpStatusCode.NotAcceptable, new { message = "Invalid Response" }); }
                if (CustomerProfitService.Create(obj)) return Request.CreateResponse(HttpStatusCode.Created, new { message = "Customer Profit Data Added successfully" });
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = "Unsuccessfull" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [HttpPost]
        [Route("customer/profit/get")]
        [AdminLogged]
        public HttpResponseMessage Get(CustomerProfitDTO obj)
        {
            try
            {
                if (!ModelState.IsValid) { return Request.CreateResponse(HttpStatusCode.NotAcceptable, new { message = "Invalid Response" }); }
                return Request.CreateResponse(HttpStatusCode.OK, CustomerProfitService.Get(obj.CusId));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [HttpPost]
        [Route("customer/profit/getActiveCustomerCount")]
        [AdminLogged]
        public HttpResponseMessage GetActiveCustomerCount()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { count = CustomerProfitService.GetActiveCustomerCount() });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [HttpPost]
        [Route("customer/profit/getAll")]
        [AdminLogged]
        public HttpResponseMessage GetAll()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, CustomerProfitService.Get());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [HttpPost]
        [Route("customer/getTop3")]
        [AdminLogged]
        public HttpResponseMessage GetTop3Customers()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, CustomerProfitService.GetTop3Customers());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
    }
}
