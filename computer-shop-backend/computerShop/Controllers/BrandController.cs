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
    [RoutePrefix("api/brands")]
    public class BrandController : ApiController
    {
        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage GetABrand(int id)
        {
            try
            {
                var data = BrandService.Get(id);
                return Request.CreateResponse(HttpStatusCode.BadRequest, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage Brands()
        {
            try
            {
                var data = BrandService.Get();
                return Request.CreateResponse(HttpStatusCode.BadRequest, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(BrandDTO obj)
        {
            try
            {
                var response = BrandService.CreateBrand(obj);
                if (response == true) return Request.CreateResponse(HttpStatusCode.Created, new { message = "Brand added successfully." });
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = "Brand already exists" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(BrandDTO obj)
        {
            try
            {
                var result = BrandService.UpdateBrand(obj);

                if (result == true) return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Brand is updated successfully." });
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Failed!" });

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
                var result = BrandService.Delete(id);

                if (result == true) return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Brand is deleted successfully." });
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Failed!" });

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
    }
}
