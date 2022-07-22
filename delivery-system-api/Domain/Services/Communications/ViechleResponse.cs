using delivery_system_api.Domain.Models;

namespace delivery_system_api.Domain.Services.Communications
{
    public class ViechleResponse:BaseResponse
    {
        public Viechle Viechle { get; set; }
        public ViechleResponse(bool success, string message, Viechle viechle) : base(success, message)
        {
            Viechle = viechle;
        }
        public ViechleResponse(Viechle viechle) : this(true, string.Empty, viechle)
        {

        }
        public ViechleResponse(string message) : this(false, message, null)
        {

        }
    }

}