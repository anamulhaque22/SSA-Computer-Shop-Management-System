using BLL.DTOs;
using BLL.Services;
using computerShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace computerShop.Controllers
{
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage GetACustomer(int id)
        {
            try
            {
                var data = CustomerService.GetCustomer(id);

                if(data != null)return Request.CreateResponse(HttpStatusCode.OK, data);
                return Request.CreateResponse(HttpStatusCode.BadRequest, new {Message = "Customer is not found!"});
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPost]
        [Route("registration")]
        public HttpResponseMessage Registration(CustomerRegistrationDTO obj)
        {
            try
            {
                var data = CustomerService.Registration(obj);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [HttpPost]
        [Route("login")]
        public HttpResponseMessage Login(CustomerLoginModel login) {
            try
            {
                var res = AuthService.CustomerAuthenticate(login.Email, login.Password);
                if(res != null) return Request.CreateResponse(HttpStatusCode.OK, res);
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "User not found!"});
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetAllCustomer()
        {
            try
            {
                var data = CustomerService.GetAllCustomer();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var result = CustomerService.DeleteCustomer(id);

                if (result == true) return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Cutomer is deleted successfully." });
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Failed!" });

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPost]
        [Route("update")]
        public HttpResponseMessage UpdateProduct(CustomerUpdateDTO p)
        {
            try
            {
                var result = CustomerService.UpdateCustomer(p);

                if (result != null) return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Customer is updated successfully." });
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Failed!" });

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
    }
}
