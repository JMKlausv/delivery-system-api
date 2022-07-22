namespace delivery_system_api.Domain.Services.Communications
{
    public class TokenResponse : BaseResponse
    {
        public TokenResponse(bool success, string message) : base(success, message)
        {
        }
    }
}
