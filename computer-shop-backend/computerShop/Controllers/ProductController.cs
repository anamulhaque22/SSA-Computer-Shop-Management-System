using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace computerShop.Controllers
{
    public class ProductController : ApiController
    {
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
    }
}
