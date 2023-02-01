using POS_Accessories.Models;
using POS_Accessories.Models.Request;

namespace POS_Accessories.Data.Repository.Interfaces
{
    public interface IOrderRepository: IRepository
    {
        Task<Order> GetOrderAsync(int orderId);
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<IEnumerable<Order>> GetPagedOrdersAsync(GetPagedSearch request);
        Task<IEnumerable<OrderDetailsMap>> GetOrderDetailsAsync(int orderId);
        Task<OrderDetailsMap> GetOrderDetailAsync(int orderDetailId);
        Task<IEnumerable<OrderDetailsMap>> GetPagedOrderDetailsAsync(int orderId);
        Task<IEnumerable<OrderHistoryMap>> GetOrderHistoryAsync(int orderId);
        Task<OrderHistoryMap> GetOrderHistoryDetailsAsync(int orderHistoryId);
        Task<IEnumerable<OrderHistoryMap>> GetPagedOrderHistoryDetailsAsync(int orderId);
        Task<IEnumerable<OrderPaymentMap>> GetOrderPaymentsAsync(int orderId);
        Task<OrderPaymentMap> GetOrderPaymentDetailsAsync(int orderPaymentDetailId);
        Task<IEnumerable<OrderPaymentMap>> GetPagedOrderPaymentsAsync(int orderId);

    }
}
