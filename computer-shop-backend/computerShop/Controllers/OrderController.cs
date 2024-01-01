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
    [RoutePrefix("api/order")]
    public class OrderController : ApiController
    {
        [HttpPost]
        [Route("")]
        public HttpResponseMessage PlaceOrder(OrderDTO order)
        {
            try
            {
                var data = OrderService.CreateOrder(order);
                if(data) return Request.CreateResponse(HttpStatusCode.OK, new { message = "Order placed successfully." });
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Failed!" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [HttpPost]
        [Route("status")]
        public HttpResponseMessage ChangeOrderStatus(OrderStatusDTO os)
        {
            try
            {
                var data = OrderService.ChangeOrderStatus(os);
                if (data) return Request.CreateResponse(HttpStatusCode.OK, new { message = "Order status changed." });
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Failed!" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("all")]
        public HttpResponseMessage AllOrderList()
        {
            try
            {
                var data = OrderService.GetAllOrder();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("details/{id}")]//order id for a single order details
        public HttpResponseMessage GetAOrder(int id)
        {
            try
            {
                var data = OrderService.GetSingleOrder(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [HttpGet]
        [Route("customer/{id}")]
        public HttpResponseMessage CustomerOrderList(int id)
        {
            try
            {
                var data = OrderService.CustomerOrderList(id);
                if(data != null) return Request.CreateResponse(HttpStatusCode.OK, data);
                return Request.CreateResponse(HttpStatusCode.OK, new {message = "No Order data found!"});
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
    }
}
