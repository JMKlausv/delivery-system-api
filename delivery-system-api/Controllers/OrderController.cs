using AutoMapper;
using delivery_system_api.Domain.Models;
using delivery_system_api.Domain.Services;
using delivery_system_api.Resources;
using delivery_system_api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace delivery_system_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService , IMapper mapper)
        {
           _orderService = orderService;
            _mapper = mapper;
        }
        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("could not add order");
            }
            

       

            var Response = await _orderService.AddOrderAsync(resource);
            if (!Response.IsSuccess)
            {
                return BadRequest(Response.Message);
            }
            return Ok(Response.Order);
        }
        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _orderService.DeleteOrderAsync(id);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return Ok(id);
        }
        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                var viechle = await _orderService.GetOrderByIdAsync(id);
                return Ok(viechle);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IEnumerable<FetchOrdersResource>> Get()
        {
            return await _orderService.GetOrdersAsync();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] OrderResource resource)
        {

        
            var response = await _orderService.UpdateOrderAsync(resource,id);
            if (!response.IsSuccess )
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Order);
        }
    }
}
