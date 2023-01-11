using POS_Accessories.Models;
using POS_Accessories.Models.Request;

namespace POS_Accessories.Business.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<string>> CreateOrderAsync(Order request);
        Task<IEnumerable<string>> UpdateOrderAsync(Order request);
        Task<IEnumerable<string>> UpdateOrderDetailsAsync(Order request);
        Task<IEnumerable<string>> DeleteOrderAsync(int orderId);
        Task<Order> GetOrderAsync(int orderId);
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<IEnumerable<Order>> GetPagedOrdersAsync(GetPagedRequest request);
        Task<IEnumerable<OrderDetailsMap>> GetOrderDetailsAsync(int orderId);
        Task<OrderDetailsMap> GetOrderDetailAsync(int orderDetailId);
        Task<IEnumerable<OrderDetailsMap>> GetPagedOrderDetailsAsync(int orderId);
        Task<IEnumerable<OrderHistoryMap>> GetOrderHistoryAsync(int orderId);
        Task<OrderHistoryMap> GetOrderHistoryDetailsAsync(int orderHistoryId);
        Task<IEnumerable<OrderHistoryMap>> GetPagedOrderHistoryDetailsAsync(int orderId);
        Task<IEnumerable<OrderPaymentMap>> GetOrderPaymentsAsync(int orderId);
        Task<OrderPaymentMap> GetOrderPaymentDetailsAsync(int orderPaymentDetailId);
        Task<IEnumerable<OrderPaymentMap>> GetPagedOrderPaymentsAsync(int orderId);
        Task<IEnumerable<string>> CreateOrderHistoryAsync(OrderHistoryMap request);
        Task<IEnumerable<string>> UpdateOrderHistoryAsync(OrderHistoryMap request);
        Task<IEnumerable<string>> DeleteOrderHistoryAsync(int orderHistoryId);

        Task<IEnumerable<string>> CreateOrderPaymentAsync(OrderPaymentMap request);
        Task<IEnumerable<string>> UpdateOrderPaymentAsync(OrderPaymentMap request);
        Task<IEnumerable<string>> DeleteOrderPaymentAsync(int orderPaymentId);
    }
}
