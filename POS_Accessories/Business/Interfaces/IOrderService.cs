using POS_Accessories.Business.Helper;
using POS_Accessories.Business.Interfaces;
using POS_Accessories.Data.Repository.Interfaces;
using POS_Accessories.Models;
using POS_Accessories.Models.Request;
using POS_Accessories.Models.Response;
using System.Net;

namespace POS_Accessories.Business.Interfaces
{
    public interface IOrderService
    {
        Task<CommonResponse> CreateAsync(OrderDetailsModel request);
        Task<CommonResponse> UpdateAsync(OrderDetailsModel request);
        Task<CommonResponse> UpdateStatusAsync(OrderStatusModel request);
        Task<CommonResponse> GetByIdAsync(int id);
        Task<CommonResponse> GetByPagingAsync(GetPagedSearch request);



        //Task<IEnumerable<string>> CreateOrderAsync(Order request);
        //Task<IEnumerable<string>> UpdateOrderAsync(Order request);
        //Task<IEnumerable<string>> UpdateOrderDetailsAsync(Order request);
        //Task<IEnumerable<string>> DeleteOrderAsync(int orderId);
        //Task<Order> GetOrderAsync(int orderId);
        //Task<IEnumerable<Order>> GetAllOrdersAsync();
        //Task<CommonResponse> GetByPagingAsync(GetPagedSearch request);
        //Task<IEnumerable<OrderDetailsMap>> GetOrderDetailsAsync(int orderId);
        //Task<OrderDetailsMap> GetOrderDetailAsync(int orderDetailId);
        //Task<IEnumerable<OrderDetailsMap>> GetPagedOrderDetailsAsync(int orderId);
        //Task<IEnumerable<OrderHistoryMap>> GetOrderHistoryAsync(int orderId);
        //Task<OrderHistoryMap> GetOrderHistoryDetailsAsync(int orderHistoryId);
        //Task<IEnumerable<OrderHistoryMap>> GetPagedOrderHistoryDetailsAsync(int orderId);
        //Task<IEnumerable<OrderPaymentMap>> GetOrderPaymentsAsync(int orderId);
        //Task<OrderPaymentMap> GetOrderPaymentDetailsAsync(int orderPaymentDetailId);
        //Task<IEnumerable<OrderPaymentMap>> GetPagedOrderPaymentsAsync(int orderId);
        //Task<IEnumerable<string>> CreateOrderHistoryAsync(OrderHistoryMap request);
        //Task<IEnumerable<string>> UpdateOrderHistoryAsync(OrderHistoryMap request);
        //Task<IEnumerable<string>> DeleteOrderHistoryAsync(int orderHistoryId);

        //Task<IEnumerable<string>> CreateOrderPaymentAsync(OrderPaymentMap request);
        //Task<IEnumerable<string>> UpdateOrderPaymentAsync(OrderPaymentMap request);
        //Task<IEnumerable<string>> DeleteOrderPaymentAsync(int orderPaymentId);
    }
}
