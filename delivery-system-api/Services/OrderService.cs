using AutoMapper;
using delivery_system_api.Domain.Models;
using delivery_system_api.Domain.Repositories;
using delivery_system_api.Domain.Services;
using delivery_system_api.Domain.Services.Communications;
using delivery_system_api.Persistence.Contexts;
using delivery_system_api.Resources;
using Microsoft.EntityFrameworkCore.Storage;

namespace delivery_system_api.Services
{
    public class OrderService : IOrderService
    {
        private readonly DeliverySystemDbContext _context;
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IOrderAddressRepository _orderAddressRepository;
        private readonly IOrderProductItemRepository _orderProductItemRepository;

        public OrderService(
            DeliverySystemDbContext context,
            IOrderRepository orderRepository, 
            IUnitOfWork unitOfWork,IMapper mapper, 
            IOrderAddressRepository orderAddressRepository,
            IOrderProductItemRepository orderProductItemRepository)
        {
           _context = context;
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _orderAddressRepository = orderAddressRepository;
            _orderProductItemRepository = orderProductItemRepository;
        }
        public async Task<OrderResponse> AddOrderAsync(OrderResource orderResource)
        {
            using(IDbContextTransaction transaction = _context.Database.BeginTransaction() )
            {

                try
                {
                    
                    //1....save order using saveorder Dto and get id
                    var saveOrder = _mapper.Map<OrderResource, SaveOrderResource>(orderResource);
                    var order = _mapper.Map<SaveOrderResource, Order>(saveOrder);  
                    var orderId = await _orderRepository.AddAsync(order);

                     OrderAddressResource orderAddressDto = orderResource.OrderAddress;
                     OrderAddress orderAddress =  _mapper.Map<OrderAddressResource, OrderAddress>(orderAddressDto);
                    IEnumerable<OrderProductItemResource> orderItemsDto = orderResource.Products;
                     IEnumerable<OrderProductItem> orderItems =_mapper.Map<IEnumerable<OrderProductItemResource>,IEnumerable<OrderProductItem>>(orderItemsDto);
                    
                    //2....save productitem 
                  
                    orderItems.ToList().ForEach( async orderItem  =>
                    {
                        orderItem.OrderId = orderId;
                        await _orderProductItemRepository.AddAsync(orderItem);
                    });
                    
                   
                    //3....save address 
                    orderAddress.OrderId = orderId;
                    await _orderAddressRepository.AddAsync(orderAddress);
                    await _context.SaveChangesAsync();

                     transaction.Commit();   
                    return new OrderResponse(order);

                }
                catch (Exception ex)
                {
                    transaction.Rollback(); 
                    return new OrderResponse($"could not add product : {ex.Message}");
                }

            } 
           
        }

        public async Task<OrderResponse> DeleteOrderAsync(int orderId)
        {
            var existingOrder = await _orderRepository.GetByIdAsync(orderId);
            if (existingOrder == null)
            {
                return new OrderResponse("Order not found!");
            }
          
            try
            {
                await _orderRepository.Delete(existingOrder);
                await _unitOfWork.CompleteAsync();
                return new OrderResponse(existingOrder);
            }
            catch (Exception ex)
            {
                return new OrderResponse(ex.Message);
            }
        }

        public async  Task<Order> GetOrderByIdAsync(int orderId)
        {
           return await _orderRepository.GetByIdAsync(orderId);
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await _orderRepository.ListAsync();  
        }

        public async Task<OrderResponse> UpdateOrderAsync(OrderResource resource, int id)
        {
            Order existingOrder = await _orderRepository.GetByIdAsync(id);
            if (existingOrder == null)
            {
                return new OrderResponse("Order not found!");
            }
            using (IDbContextTransaction transaction = _context.Database.BeginTransaction())
            {

            try
            {
                    //1.......updating order table
                    var saveOrder = _mapper.Map<OrderResource, SaveOrderResource>(resource);
                    var order = _mapper.Map<SaveOrderResource, Order>(saveOrder);
                    order.Id = id;
                    await _orderRepository.Update(order);
                    _context.SaveChanges();
                   
                    //2.........updating order items
                    IEnumerable<OrderProductItemResource> orderItemsDto = resource.Products;
                    IEnumerable<OrderProductItem> newOrderItems = _mapper.Map<IEnumerable<OrderProductItemResource>, IEnumerable<OrderProductItem>>(orderItemsDto);
                    IEnumerable < OrderProductItem> existingItems = existingOrder.Products;
                    existingItems.ToList().ForEach(async item =>
                    {
                        await _orderProductItemRepository.Delete(item);
                        _context.SaveChanges();
                    });

                    newOrderItems.ToList().ForEach(async orderItem =>
                    {
                       // orderItem.OrderId = id;
                        await _orderProductItemRepository.AddAsync(orderItem);
                        _context.SaveChanges();

                    });
                    

                    //3..........updating order address table
                    OrderAddressResource orderAddressDto = resource.OrderAddress;
                    OrderAddress newOrderAddress = _mapper.Map<OrderAddressResource, OrderAddress>(orderAddressDto);
                    var existingAddress = await _orderAddressRepository.GetByIdAsync(existingOrder.OrderAddress.Id);
                    if(existingAddress == null)
                    {
                        await  _orderAddressRepository.AddAsync(newOrderAddress);
                        _context.SaveChanges();
                    }
                    else
                    {
                        newOrderAddress.Id= existingOrder.OrderAddress.Id;
                        newOrderAddress.OrderId = id;
                        await _orderAddressRepository.Update(newOrderAddress);
                        _context.SaveChanges();
                    }


                   await transaction.CommitAsync();
                return new OrderResponse(order);

            }
            catch (Exception ex)
            {
                   await  transaction.RollbackAsync();
                return new OrderResponse($"Could not update order : {ex.Message}");
            }
            }
        }
    }
}
