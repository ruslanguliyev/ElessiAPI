using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("productList")]
        public IActionResult GetAllProduct()
        {
            var products = _productService.GetAllProduct();
            if (products != null)
                return Ok(new { status = 200, message = products });
            return BadRequest();
        }

        [HttpPost("addProduct")]
        public IActionResult AddProduct(Product product)
        {
            var addProduct = _productService.AddProduct(product);
            if (addProduct.Success)
                return Ok(new { status = 200, message = addProduct.Message });
            return BadRequest(new { status = 400, message = addProduct.Message });
        }


        [HttpGet("GetById")]
        public IActionResult GetById(int Id)
        {
            var getProduct = _productService.GetById(Id);
            if (getProduct.Success)
                return Ok(new { status = 200, message = getProduct });
            return BadRequest(new { status = 400, message = getProduct });
        }


        [HttpDelete("deleteProduct")]
        public IActionResult Delete(int Id)
        {
            var deleteProduct = _productService.DeleteProduct(Id);
            if (deleteProduct.Success)
                return Ok(new { status = 200, message = deleteProduct.Message });
            return BadRequest();
        }

        [HttpPost("updateProduct")]
        public IActionResult UpdateProduct(Product product)
        {
            var updateProduct = _productService.UpdateProduct(product);
            if(updateProduct.Success)
                return Ok(new { status = 200, message = updateProduct});
            return BadRequest(new { status = 400, message = updateProduct });
        }
    }
}
