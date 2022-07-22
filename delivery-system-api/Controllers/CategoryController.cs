using AutoMapper;
using delivery_system_api.Domain.Models;
using delivery_system_api.Domain.Services;
using delivery_system_api.Resources;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace delivery_system_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService , IMapper mapper)
        {
           _categoryService = categoryService;
            _mapper = mapper;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
        {
          
            return await  _categoryService.GetCategoriesAsync();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
            var category =  await _categoryService.GetCategoryByIdAsync(id);
                return Ok(category);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

          
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async  Task<IActionResult> Post([FromBody] CategoryResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("could not add category");
            }
            var category =  _mapper.Map<CategoryResource, Category>(resource);
          var Response = await _categoryService.AddCategoryAsync(category);
            if (!Response.IsSuccess)
            {
                return BadRequest(Response.Message);    
            }
            return Ok(Response.Category);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CategoryResource resource)
        {
            var category = _mapper.Map<CategoryResource, Category>(resource);   
            category.Id = id;   
            var response = await  _categoryService.UpdateCategoryAsync(category);
            if (!response.IsSuccess)
            {
              return BadRequest(response.Message);
            }
            return Ok(response.Category);
        }

        // Patch api/<ValuesController>/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument resource)
        {
            var response = await _categoryService.PatchCategoryAsync(id,resource);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return Ok(id);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public  async Task<IActionResult> Delete(int id)
        {
           var response = await _categoryService.DeleteCategoryAsync(id);   
            if(!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return Ok(id);
        }
    }
}
