using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace computerShop.Controllers
{
    public class ProductController : ApiController
    {
        [HttpPost]
        [Route("api/product/create")]
        public HttpResponseMessage AddProduct(ProductCreateDTO p)
        {
            try { 
                var response = ProductService.AddProduct(p);
                if(response == true) return Request.CreateResponse(HttpStatusCode.Created, new { message = "Product added successfully." });
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = "Failed!" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/product/{id}")]
        public HttpResponseMessage GetAProduct(int id)
        {
            try
            {
                var data = ProductService.GetAProduct(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/products")]
        public HttpResponseMessage GetAllProduct()
        {
            try
            {
                var data = ProductService.GetAllProduct();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/product/delete/{id}")]
        public HttpResponseMessage Delete(int id) {
            try
            {
                var result = ProductService.DeleteProduct(id);

                if(result == true) return Request.CreateResponse(HttpStatusCode.OK, new{ Message = "Product is deleted successfully." });
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Failed!" });

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/product/update")]
        public HttpResponseMessage UpdateProduct(ProductCreateDTO p) {
            try
            {
                var result = ProductService.UpdateProduct(p);

                if (result == true) return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Product is updated successfully." });
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Failed!" });

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
    }
}
