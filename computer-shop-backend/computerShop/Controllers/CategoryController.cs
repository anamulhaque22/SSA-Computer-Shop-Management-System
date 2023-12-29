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
    [RoutePrefix("api/categories")]
    public class CategoryController : ApiController
    {
        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage GetACategory(int id)
        {
            try
            {
                var data = CategoryService.Get(id);
                return Request.CreateResponse(HttpStatusCode.BadRequest, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage Categories()
        {
            try
            {
                var data = CategoryService.Get();
                return Request.CreateResponse(HttpStatusCode.BadRequest, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(CategoryDTO obj)
        {
            try
            {
                var response = CategoryService.CreateBrand(obj);
                if (response == true) return Request.CreateResponse(HttpStatusCode.Created, new { message = "Category added successfully." });
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = "Category already exists" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(CategoryDTO obj)
        {
            try
            {
                var result = CategoryService.UpdateBrand(obj);

                if (result == true) return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Category is updated successfully." });
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
                var result = CategoryService.Delete(id);

                if (result == true) return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Category is deleted successfully." });
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Failed!" });

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
    }
}
