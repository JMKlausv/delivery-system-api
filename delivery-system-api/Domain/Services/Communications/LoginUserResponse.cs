using delivery_system_api.Resources;
namespace delivery_system_api.Domain.Services.Communications
{
    public class LoginUserResponse : BaseResponse
    {
        public TokenResource Token { get; set; }
        public LoginUserResponse(bool success, string message, TokenResource token) : base(success, message)
        {
            Token = token;
        }
        public LoginUserResponse(TokenResource token) : this(true, string.Empty, token)
        {

        }
        public LoginUserResponse(string message) : this(false, message, null)
        {

        }
    }
    
}
