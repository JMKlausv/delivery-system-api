using delivery_system_api.Domain.Models;
using delivery_system_api.Domain.Repositories;
using delivery_system_api.Domain.Services;
using delivery_system_api.Domain.Services.Communications;
using delivery_system_api.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace delivery_system_api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        //  private readonly IAuthenticationService _authenticationService;

        public UserService( IUserRepository userRepository , IUnitOfWork unitOfWork , IConfiguration configuration)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            // _authenticationService = authenticationService;
        }
        public async Task<CreateUserResponse> CreateUserAsync(User user, string role)
        {
            var existingUser =  _userRepository.FindByEmailAsync(user.Email);
            if(existingUser != null)
            {
                return new CreateUserResponse("The email already in use");
            }
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Role = role;
            try
            {
               await  _userRepository.AddAsync(user);
                await _unitOfWork.CompleteAsync();
                return new CreateUserResponse(user);


            }
            catch (Exception ex)
            {
                return new CreateUserResponse($"could not create user : ${ex}");
                
            }
           
        }

        public async Task<LoginUserResponse> AuthenticateUserAsync(string email,string password)
        {
            var existingUser =  _userRepository.FindByEmailAsync(email);
            if (existingUser == null)
            {
                return new LoginUserResponse("Invalid Login");
            }
          bool  passwordCheck = BCrypt.Net.BCrypt.Verify(password, existingUser.Password);
            if (!passwordCheck)
            {
                return new LoginUserResponse("Invalid Login");
            }
            var tokenString = generateToken(existingUser);
            var tokenResource = new TokenResource()
            {
                TokenString = tokenString,
            };
            return  new LoginUserResponse(tokenResource);

        }

        private string generateToken(User user)
        {
            var claims = new[]
            {
               new Claim(ClaimTypes.Role,user.Role),
               new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
               new Claim(ClaimTypes.Email, user.Email)
           };
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                notBefore:DateTime.UtcNow,
                signingCredentials: new SigningCredentials(
                    key:new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])),
                    algorithm:SecurityAlgorithms.HmacSha256)
                );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString; 
        }
    }
    
}
