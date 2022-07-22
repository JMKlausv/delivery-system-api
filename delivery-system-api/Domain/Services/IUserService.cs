using delivery_system_api.Domain.Models;
using delivery_system_api.Domain.Services.Communications;
using Microsoft.AspNetCore.Mvc;

namespace delivery_system_api.Domain.Services
{
    public interface IUserService
    {
       Task<CreateUserResponse> CreateUserAsync(User user, string role); 
     Task<LoginUserResponse> AuthenticateUserAsync(string email,string password);
    }

}