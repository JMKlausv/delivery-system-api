using delivery_system_api.Domain.Models;

namespace delivery_system_api.Domain.Services.Communications
{
    public class OrderResponse:BaseResponse
    {
        public Order Order { get; set; }
        private OrderResponse(bool isSuccess,string message  , Order order):base(isSuccess,message)
        {
            Order = order;
        }
        public OrderResponse(Order order):this(true,string.Empty,order)
        {
         
        }
        public OrderResponse(string message):this(false,message,null)
        {

        }
    }
}
