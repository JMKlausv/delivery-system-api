using AutoMapper;
using delivery_system_api.Domain.Models;
using delivery_system_api.Domain.Services;
using delivery_system_api.Resources;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace delivery_system_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
           _productService = productService;
            _mapper = mapper;   
        }
        // GET: api/<ValuesController>
       /* 
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _productService.GetProductsAsync();
        }
        */
      //GET: api/<ValuesController>...filtering
        [HttpGet]
        public async Task<IEnumerable<Product>> GetFiltered([FromQuery] string?  categoryId )
        {
            if (categoryId == null)
            {
                return await _productService.GetProductsAsync();
            }
            return await _productService.GetFilteredProductsAsync(categoryId);
        }
      
        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                var product = await _productService.GetProductByIdAsync(id);
                return Ok(product);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }


        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("could not add product");
            }
            var product = _mapper.Map<ProductResource, Product>(resource);
            var Response = await _productService.AddProductAsync(product);
            if (!Response.IsSuccess)
            {
                return BadRequest(Response.Message);
            }
            return Ok(Response.Product);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductResource resource)
        {
            var product = _mapper.Map<ProductResource, Product>(resource);
            product.Id = id;
            var response = await _productService.UpdateProductAsync(product);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Product);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _productService.DeleteProductAsync(id);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return Ok(id);
        }
    }
}