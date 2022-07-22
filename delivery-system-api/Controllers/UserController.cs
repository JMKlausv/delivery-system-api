using AutoMapper;
using delivery_system_api.Domain.Models;
using delivery_system_api.Domain.Services;
using delivery_system_api.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace delivery_system_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService , IMapper mapper )
        {
            _userService = userService;
           _mapper = mapper;
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserCredentialResource resource)

        {
            var user = _mapper.Map<UserCredentialResource,User>(resource);
            var response = await  _userService.CreateUserAsync(user,"systemUser");
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }

            var userResource = _mapper.Map<User, UserResource>(response.User);
            return Ok(userResource) ;

        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginUser([FromBody] UserCredentialResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
          var  response = await _userService.AuthenticateUserAsync(resource.Email,resource.Password);
            if(!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }


           return Ok(response.Token); 
        }
    }
}
