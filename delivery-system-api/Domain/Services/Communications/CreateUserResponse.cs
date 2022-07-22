using delivery_system_api.Domain.Models;

namespace delivery_system_api.Domain.Services.Communications
{
    public class CreateUserResponse : BaseResponse
    {
        public User User { get; set; }
        public CreateUserResponse(bool success, string message,User user) : base(success, message)
        {
            User = user;    
        }
        public CreateUserResponse(User user): this(true ,string.Empty,user)
        {
           
        }
        public CreateUserResponse(string message):this(false,message,null)
        {

        }
    }
}
