using Mango.Services.ProductsAPI.Models.Dto;
using Mango.Services.ProductsAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        protected ResponseDto _response;
        private readonly IProductRepository _product;

        public ProductsController(IProductRepository product)
        {
           this._response = new ResponseDto();
            _product = product;
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<ProductDto> products = await _product.GetProducts();
                _response.Result = products;
                _response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = ex.Message;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }

            return _response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                var product = await _product.GetProductById(id);
                _response.Result = product;
                _response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = ex.Message;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }

            return _response;
        }

        [HttpPost]
        public async Task<object> Post([FromBody] ProductDto product)
        {
            try
            {
                var newProduct = await _product.CreateUpdateProduct(product);
                _response.Result = newProduct;
                _response.DisplayMessage = "Product Added Successfully";
                _response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = ex.Message;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }

            return _response;
        }

        [HttpPut]
        public async Task<object> Update([FromBody]ProductDto product)
        {
            try
            {
                var newProduct = await _product.CreateUpdateProduct(product);
                _response.Result = newProduct;
                _response.DisplayMessage = "Product Updated Successfully";
                _response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = ex.Message;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }

            return _response;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool deleteProduct = await _product.DeleteProduct(id);
                _response.Result = deleteProduct;
                _response.IsSuccess = true;
                _response.DisplayMessage = "Product Deleted Successfully";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = ex.Message;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }

            return _response;
        }
    }
}
