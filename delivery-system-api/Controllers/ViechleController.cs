using AutoMapper;
using delivery_system_api.Domain.Models;
using delivery_system_api.Domain.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace delivery_system_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViechleController : ControllerBase
    {
        private readonly IViechleService _viechleService;
        private readonly IMapper _mappr;

        public ViechleController(IViechleService viechleService, IMapper mappr)
        {
            _viechleService = viechleService;
          _mappr = mappr;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var viechles = await _viechleService.GetViechlesAsync();
            return Ok(viechles);
        }
        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                var viechle = await _viechleService.GetViechleById(id);
                return Ok(viechle);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Viechle resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("could not add category");
            }
         
            var Response = await _viechleService.AddViechleAsync(resource);
            if (!Response.IsSuccess)
            {
                return BadRequest(Response.Message);
            }
            return Ok(Response.Viechle);
        }


        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Viechle resource)
        {
          
          resource.Id = id;
            var response = await _viechleService.UpdateViechleAsync(resource);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Viechle);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _viechleService.DeleteViechleAsync(id);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return Ok(id);
        }
    }
}