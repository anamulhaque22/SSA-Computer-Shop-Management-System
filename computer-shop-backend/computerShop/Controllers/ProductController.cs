using BLL.DTOs;
using BLL.Services;
using computerShop.Auth;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Web.Http;

namespace computerShop.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductController : ApiController
    {
        [HttpPost]
        [Route("create")]
        public async Task<HttpResponseMessage> AddProductAsync()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                return Request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
            }
            var provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);

            ProductCreateDTO productCreateDTO = new ProductCreateDTO();
            foreach (var content in provider.Contents)
            {
                var contentDisposition = content.Headers.ContentDisposition;
                var fieldName = contentDisposition.Name.Trim('\"');

                if (content.Headers.ContentDisposition.FileName != null) // This is a file
                {
                    var stream = await content.ReadAsStreamAsync();
                    var fileName = contentDisposition.FileName.Trim('\"');

                    if (fileName != null)
                    {
                        productCreateDTO.FileName = fileName;
                        productCreateDTO.FileData = stream;
                    }
                    // Process the file stream, e.g., upload to Cloudinary
                    //fileUrl = _cloudinaryService.UploadFile(stream, fileName);
                }
                else // This is form data
                {
                    var key = content.Headers.ContentDisposition.Name.Trim('"');
                    var value = await content.ReadAsStringAsync();
                    
                    // Example: if(key == "ProductName") productCreateDTO.ProductName = value;
                    if(key == "Name") productCreateDTO.Name = value;
                    if(key == "ProductPrice") productCreateDTO.ProductPrice = Convert.ToInt16(value);
                    if (key == "Quantity") productCreateDTO.Quantity = Convert.ToInt16(value);
                    if (key == "Description") productCreateDTO.Description = value;
                    if (key == "CategoryId") productCreateDTO.CategoryId = Convert.ToInt16(value);
                    if (key == "BrandId") productCreateDTO.BrandId = Convert.ToInt16(value);
                    if (key == "CostPrice") productCreateDTO.CostPrice = Convert.ToInt16(value);

                }
            }

            try {
                var response = ProductService.AddProduct(productCreateDTO);
                if (response == true) return Request.CreateResponse(HttpStatusCode.Created, new { message = "Product added successfully." });
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = "Failed!" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("{id}")]
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
        [Route("")]
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
        [Route("filter")]
        public HttpResponseMessage FilterProduct([FromUri] ProductFilterDTO filter)
        {
            try
            {
                var data = ProductService.GetFilteredProduct(filter);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("delete/{id}")]
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
        [Route("update")]
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
        [HttpPost]
        [Route("mostSoldProduct")]
        [AdminLogged]
        public HttpResponseMessage GetMostSoldProduct()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, ProductService.GetMostSoldProduct());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
    }
}
