using ECommerce.Application.Dtos;
using ECommerce.Application.Interfaces.Repositories;
using ECommerce.Application.Wrappers;
using ECommerce.Domain.Entities;
using ECommerce.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        /// <summary>
        /// Retrieves all products.
        /// </summary>
        /// <returns>A ServiceResponse containing the list of products.</returns>
        /// <response code="200">Returns the list of products successfully.</response>
        [ServiceResponseFilter]
        [HttpGet("GetProducts")]
        public IActionResult GetProducts()
        {
            var response = _productService.GetAllProducts();
            return Ok(response);
        }

        /// <summary>
        /// Adds a new product.
        /// </summary>
        /// <param name="productDto">The product details to be added.</param>
        /// <returns>A ServiceResponse indicating the success or failure of the operation.</returns>
        /// <response code="200">Returns the success response when product is added.</response>
        /// <response code="400">Returns error response if product details are invalid.</response>
        [ServiceResponseFilter]
        [HttpPost("AddProduct")]
        public IActionResult AddProduct([FromBody] CreateProductDto productDto)
        {
            var response = _productService.CreateProduct(productDto);
            return Ok(response);
        }


        /// <summary>
        /// Endpoint to trigger an error for testing purposes.
        /// </summary>
        /// <returns>Throws an exception to test error handling.</returns>
        [HttpGet("error")]
        public IActionResult GetError()
        {
            //error for testing purposes
            throw new Exception("Test exception");
        }
    }
}
