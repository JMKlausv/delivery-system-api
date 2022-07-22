namespace delivery_system_api.Domain.Services.Communications
{
    public abstract class BaseResponse
    {
        public bool IsSuccess { get; set; } 
        public string Message { get; set; }
        public BaseResponse(bool success, string message)
        {
            IsSuccess = success;    
            Message = message;  
        }
    }
}
