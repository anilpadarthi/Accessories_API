using POS_Accessories.Business.Interfaces;
using POS_Accessories.Data.Repository.Interfaces;
using POS_Accessories.Models;
using POS_Accessories.Models.Request;


namespace POS_Accessories.Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository OrderRepository)
        {
            _orderRepository = OrderRepository;
        }

        #region Order
        public async Task<IEnumerable<string>> CreateOrderAsync(Order orderModel)
        {
            _orderRepository.Add(orderModel);
            await _orderRepository.SaveChangesAsync();
            foreach (var item in orderModel.OrderDetailsMaps)
            {
                OrderDetailsMap mapObject = new OrderDetailsMap();
                mapObject.Order = orderModel;
                mapObject.ProductId = item.ProductId;
                mapObject.SalePrice = item.SalePrice;
                mapObject.Qty = item.Qty;
                mapObject.ProductColourId = item.ProductColourId;
                mapObject.ProductSizeId = item.ProductSizeId;
                mapObject.CreatedDate = DateTime.Now;
                mapObject.CreatedBy = 1;
                _orderRepository.Add(mapObject);
            }
            await _orderRepository.SaveChangesAsync();
            var historyRecord = CreateHistoryRecord(orderModel.OrderId, "Placed", orderModel.PaymentMethod);
            await CreateOrderHistoryAsync(historyRecord);
            List<string> resultList = new List<string>();
            resultList.Add("Created successfully");
            return resultList;
        }

        public async Task<IEnumerable<string>> DeleteOrderAsync(int orderId)
        {
            var saleOrder = await _orderRepository.GetOrderAsync(orderId);
            saleOrder.IsActive = false;
            await _orderRepository.SaveChangesAsync();
            List<string> resultList = new List<string>();
            resultList.Add("Deleted successfully");
            return resultList;
        }

        public async Task<IEnumerable<string>> UpdateOrderAsync(Order orderModel)
        {
            var saleOrder = await _orderRepository.GetOrderAsync(orderModel.OrderId);
            saleOrder.TotalAmount = orderModel.TotalAmount;
            saleOrder.NetAmount = orderModel.NetAmount;
            saleOrder.DiscountAmount = orderModel.DiscountAmount;
            saleOrder.VatAmount = orderModel.VatAmount;
            saleOrder.DeliveryCharges = orderModel.DeliveryCharges;
            saleOrder.OrderStatus = orderModel.OrderStatus;
            saleOrder.PaymentMethod = orderModel.PaymentMethod;
            saleOrder.ShippingMode = orderModel.ShippingMode;
            saleOrder.TrackNumber = orderModel.TrackNumber;
            saleOrder.IsVatEnabled = orderModel.IsVatEnabled;
            saleOrder.DiscountPercent = orderModel.DiscountPercent;
            saleOrder.VatPercent = orderModel.VatPercent;
            saleOrder.CouponCode = orderModel.CouponCode;
            saleOrder.ModifiedBy = orderModel.ModifiedBy;
            await _orderRepository.SaveChangesAsync();


            var historyRecord = CreateHistoryRecord(orderModel.OrderId, orderModel.OrderStatus, orderModel.PaymentMethod);
            await CreateOrderHistoryAsync(historyRecord);

            List<string> resultList = new List<string>();
            resultList.Add("Updated successfully");
            return resultList;
        }

        public async Task<Order> GetOrderAsync(int orderId)
        {
            return await _orderRepository.GetOrderAsync(orderId);
        }

        public async Task<IEnumerable<Order>> GetPagedOrdersAsync(GetPagedSearch request)
        {
            return await _orderRepository.GetPagedOrdersAsync(request);
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _orderRepository.GetAllOrdersAsync();
        }

        public async Task<IEnumerable<string>> UpdateOrderDetailsAsync(Order orderModel)
        {
            var saleOrder = await _orderRepository.GetOrderAsync(orderModel.OrderId);
            saleOrder.TotalAmount = orderModel.TotalAmount;
            saleOrder.NetAmount = orderModel.NetAmount;
            saleOrder.DiscountAmount = orderModel.DiscountAmount;
            saleOrder.VatAmount = orderModel.VatAmount;
            saleOrder.DeliveryCharges = orderModel.DeliveryCharges;
            saleOrder.OrderStatus = orderModel.OrderStatus;
            saleOrder.PaymentMethod = orderModel.PaymentMethod;
            saleOrder.ShippingMode = orderModel.ShippingMode;
            saleOrder.TrackNumber = orderModel.TrackNumber;
            saleOrder.IsVatEnabled = orderModel.IsVatEnabled;
            saleOrder.DiscountPercent = orderModel.DiscountPercent;
            saleOrder.VatPercent = orderModel.VatPercent;
            saleOrder.CouponCode = orderModel.CouponCode;
            saleOrder.ModifiedBy = orderModel.ModifiedBy;

            await _orderRepository.SaveChangesAsync();
            //Update existing records
            foreach (var item in saleOrder.OrderDetailsMaps)
            {
                var isMatched = orderModel.OrderDetailsMaps.ToList().Exists(e => e.OrderDetailId == item.OrderDetailId);

                if (!isMatched)
                {
                    OrderDetailsMap mapObject = new OrderDetailsMap();
                    mapObject = await _orderRepository.GetOrderDetailAsync(item.OrderDetailId);
                    mapObject.IsActive = false;
                }
            }
            await _orderRepository.SaveChangesAsync();

            //Add new records
            foreach (var item in orderModel.OrderDetailsMaps)
            {
                var isMatched = saleOrder.OrderDetailsMaps.ToList().Exists(e => e.OrderDetailId == item.OrderDetailId);
                OrderDetailsMap mapObject = new OrderDetailsMap();
                if (isMatched)
                {
                    mapObject = await _orderRepository.GetOrderDetailAsync(item.OrderDetailId);
                    mapObject.Order = saleOrder;
                    mapObject.OrderId = saleOrder.OrderId;
                    mapObject.ProductId = item.ProductId;
                    mapObject.SalePrice = item.SalePrice;
                    mapObject.Qty = item.Qty;
                    mapObject.ProductColourId = item.ProductColourId;
                    mapObject.ProductSizeId = item.ProductSizeId;
                }
                else
                {
                    mapObject.Order = saleOrder;
                    mapObject.OrderId = saleOrder.OrderId;
                    mapObject.ProductId = item.ProductId;
                    mapObject.SalePrice = item.SalePrice;
                    mapObject.Qty = item.Qty;
                    mapObject.ProductColourId = item.ProductColourId;
                    mapObject.ProductSizeId = item.ProductSizeId;
                    _orderRepository.Add(mapObject);
                }
            }
            await _orderRepository.SaveChangesAsync();
            var historyRecord = CreateHistoryRecord(orderModel.OrderId, "Edited", orderModel.PaymentMethod);
            await CreateOrderHistoryAsync(historyRecord);

            List<string> resultList = new List<string>();
            resultList.Add("Updated successfully");
            return resultList;
        }

        public async Task<IEnumerable<OrderDetailsMap>> GetOrderDetailsAsync(int orderId)
        {
            return await _orderRepository.GetOrderDetailsAsync(orderId);
        }

        public async Task<OrderDetailsMap> GetOrderDetailAsync(int orderDetailId)
        {
            return await _orderRepository.GetOrderDetailAsync(orderDetailId);
        }

        public async Task<IEnumerable<OrderDetailsMap>> GetPagedOrderDetailsAsync(int orderId)
        {
            return await _orderRepository.GetPagedOrderDetailsAsync(orderId);
        }

        #endregion

        #region OrderHistoryMap

        public async Task<IEnumerable<OrderHistoryMap>> GetOrderHistoryAsync(int orderId)
        {
            return await _orderRepository.GetOrderHistoryAsync(orderId);
        }

        public async Task<OrderHistoryMap> GetOrderHistoryDetailsAsync(int orderHistoryId)
        {
            return await _orderRepository.GetOrderHistoryDetailsAsync(orderHistoryId);
        }

        public async Task<IEnumerable<OrderHistoryMap>> GetPagedOrderHistoryDetailsAsync(int orderId)
        {
            return await _orderRepository.GetPagedOrderHistoryDetailsAsync(orderId);
        }

        public async Task<IEnumerable<string>> CreateOrderHistoryAsync(OrderHistoryMap request)
        {
            _orderRepository.Add(request);
            await _orderRepository.SaveChangesAsync();
            List<string> resultList = new List<string>();
            resultList.Add("Created successfully");
            return resultList;
        }

        public async Task<IEnumerable<string>> UpdateOrderHistoryAsync(OrderHistoryMap request)
        {
            var OrderPaymentMap = await _orderRepository.GetOrderHistoryDetailsAsync(request.OrderHistoryId);
            await _orderRepository.SaveChangesAsync();
            List<string> resultList = new List<string>();
            resultList.Add("Updated successfully");
            return resultList;
        }

        public async Task<IEnumerable<string>> DeleteOrderHistoryAsync(int orderHistoryId)
        {
            var orderHistoryDetail = await _orderRepository.GetOrderHistoryDetailsAsync(orderHistoryId);
            orderHistoryDetail.IsActive = false;
            await _orderRepository.SaveChangesAsync();
            List<string> resultList = new List<string>();
            resultList.Add("Deleted successfully");
            return resultList;
        }
        #endregion

        #region OrderPaymentMap

        public async Task<IEnumerable<OrderPaymentMap>> GetOrderPaymentsAsync(int orderId)
        {
            return await _orderRepository.GetOrderPaymentsAsync(orderId);
        }

        public async Task<OrderPaymentMap> GetOrderPaymentDetailsAsync(int orderPaymentDetailId)
        {
            return await _orderRepository.GetOrderPaymentDetailsAsync(orderPaymentDetailId);
        }

        public async Task<IEnumerable<OrderPaymentMap>> GetPagedOrderPaymentsAsync(int orderId)
        {
            return await _orderRepository.GetPagedOrderPaymentsAsync(orderId);
        }


        public async Task<IEnumerable<string>> CreateOrderPaymentAsync(OrderPaymentMap request)
        {
            _orderRepository.Add(request);
            await _orderRepository.SaveChangesAsync();
            List<string> resultList = new List<string>();
            resultList.Add("Created successfully");
            return resultList;
        }

        public async Task<IEnumerable<string>> UpdateOrderPaymentAsync(OrderPaymentMap request)
        {
            var OrderPaymentMap = await _orderRepository.GetOrderPaymentDetailsAsync(request.OrderPaymentId);
            await _orderRepository.SaveChangesAsync();
            List<string> resultList = new List<string>();
            resultList.Add("Updated successfully");
            return resultList;
        }

        public async Task<IEnumerable<string>> DeleteOrderPaymentAsync(int orderPaymentId)
        {
            var orderHistoryDetail = await _orderRepository.GetOrderPaymentDetailsAsync(orderPaymentId);
            orderHistoryDetail.IsActive = false;
            await _orderRepository.SaveChangesAsync();
            List<string> resultList = new List<string>();
            resultList.Add("Deleted successfully");
            return resultList;
        }

        #endregion


        #region Private Methods

        private OrderHistoryMap CreateHistoryRecord(int orderId, string orderStatus, string paymentMethod)
        {
            OrderHistoryMap OrderHistoryMap = new OrderHistoryMap();
            OrderHistoryMap.OrderId = orderId;
            OrderHistoryMap.OrderStatus = orderStatus;
            OrderHistoryMap.PaymentMethod = paymentMethod;
            OrderHistoryMap.IsActive = true;
            OrderHistoryMap.CreatedDate = DateTime.Now;
            OrderHistoryMap.CreatedBy = 1;
            return OrderHistoryMap;
        }

        #endregion
    }
}
