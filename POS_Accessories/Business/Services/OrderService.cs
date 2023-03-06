using POS_Accessories.Business.Helper;
using POS_Accessories.Business.Interfaces;
using POS_Accessories.Data.Repository.Interfaces;
using POS_Accessories.Models;
using POS_Accessories.Models.Request;
using POS_Accessories.Models.Response;
using System.Net;


namespace POS_Accessories.Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository OrderRepository)
        {
            _orderRepository = OrderRepository;
        }

        public async Task<CommonResponse> CreateAsync(OrderDetailsModel request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                int orderId = 0;
                if (request != null)
                {
                    orderId = await CreateOrder(request);
                }

                foreach (var item in request.Items)
                {
                    OrderDetailsMap mapObject = new OrderDetailsMap()
                    {
                        OrderId = orderId,
                        ProductId = item.ProductId,
                        SalePrice = item.Price,
                        Qty = item.Quantity,
                        ProductColourId = item.ProductColourId,
                        ProductSizeId = item.ProductSizeId,
                        IsActive = true,
                        CreatedDate = DateTime.Now,
                        CreatedBy = 1
                    };
                    _orderRepository.Add(mapObject);
                }
                await _orderRepository.SaveChangesAsync();

                await CreateHistoryRecord(orderId, request.OrderStatus, request.PaymentMethod, "Created");
                response = Utility.CreateResponse("Order placed successfully", HttpStatusCode.Created);

            }
            catch (Exception ex)
            {
                response = response.HandleException(ex);
            }
            return response;
        }

        public async Task<CommonResponse> UpdateAsync(OrderDetailsModel request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                int orderId = request.OrderId ?? 0;
                if (request != null && orderId > 0)
                {
                    await UpdateOrder(request);
                    var savedItems = await _orderRepository.GetOrderDetailsAsync(orderId);

                    //update existing items as inactive if not found in the requested items
                    foreach (var item in savedItems)
                    {
                        var IsSavedItem = request.Items.Where(e => e.ProductId == item.ProductId).FirstOrDefault();
                        if (IsSavedItem != null)
                        {
                            item.Qty = IsSavedItem.Quantity;
                            item.SalePrice = IsSavedItem.Price;
                            item.ProductSizeId = IsSavedItem.ProductSizeId;
                            item.ProductColourId = IsSavedItem.ProductColourId;
                            item.ModifiedDate = DateTime.Now;
                            item.ModifiedBy = 1;
                        }
                        else
                        {
                            item.IsActive = false;
                        }
                    }
                    await _orderRepository.SaveChangesAsync();

                    foreach (var item in request.Items)
                    {
                        var IsNewItem = savedItems.Where(e => e.ProductId == item.ProductId).FirstOrDefault();
                        if (IsNewItem == null)
                        {
                            OrderDetailsMap mapObject = new OrderDetailsMap()
                            {
                                OrderId = orderId,
                                ProductId = item.ProductId,
                                SalePrice = item.Price,
                                Qty = item.Quantity,
                                ProductColourId = item.ProductColourId,
                                ProductSizeId = item.ProductSizeId,
                                IsActive = true,
                                CreatedDate = DateTime.Now,
                                CreatedBy = 1
                            };
                            _orderRepository.Add(mapObject);
                        }
                    }
                    await _orderRepository.SaveChangesAsync();

                    await CreateHistoryRecord(orderId, request.OrderStatus, request.PaymentMethod, "Updated Order Details");
                    response = Utility.CreateResponse("Order updated successfully", HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                response = response.HandleException(ex);
            }
            return response;

        }


        public async Task<CommonResponse> UpdateStatusAsync(OrderStatusModel request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                var order = await _orderRepository.GetByIdAsync(request.OrderId);
                order.OrderStatus = request.OrderStatus;
                order.PaymentMethod = request.PaymentMethod;
                order.ShippingMode = request.ShippingMode;
                order.TrackNumber = request.TrackNumber;
                order.ShippingAddress = request.ShippingAddress;
                _orderRepository.SaveChangesAsync();
                response = Utility.CreateResponse("Updated status successfully", HttpStatusCode.OK);
                await CreateHistoryRecord(request.OrderId, request.OrderStatus, request.PaymentMethod, "Updated_" + request.ShippingMode + "_" + request.TrackNumber);

            }
            catch (Exception ex)
            {
                response = response.HandleException(ex);
            }
            return response;
        }


        public async Task<CommonResponse> GetByIdAsync(int id)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                var result = await _orderRepository.GetByIdAsync(id);
                result.OrderDetailsMaps = (await _orderRepository.GetOrderDetailsAsync(id)).ToList();
                response = Utility.CreateResponse(result, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                response = response.HandleException(ex);
            }
            return response;
        }

        public async Task<CommonResponse> GetByPagingAsync(GetPagedSearch request)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                PagedResult pageResult = new PagedResult();
                pageResult.Results = await _orderRepository.GetByPagingAsync(request);
                pageResult.TotalRecords = await _orderRepository.GetTotalCountAsync(request);

                response = Utility.CreateResponse(pageResult, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                response = response.HandleException(ex);
            }
            return response;
        }

        //#region Order
        //public async Task<IEnumerable<string>> CreateOrderAsync(Order orderModel)
        //{
        //    _orderRepository.Add(orderModel);
        //    await _orderRepository.SaveChangesAsync();
        //    foreach (var item in orderModel.OrderDetailsMaps)
        //    {
        //        OrderDetailsMap mapObject = new OrderDetailsMap();
        //        mapObject.Order = orderModel;
        //        mapObject.ProductId = item.ProductId;
        //        mapObject.SalePrice = item.SalePrice;
        //        mapObject.Qty = item.Qty;
        //        mapObject.ProductColourId = item.ProductColourId;
        //        mapObject.ProductSizeId = item.ProductSizeId;
        //        mapObject.CreatedDate = DateTime.Now;
        //        mapObject.CreatedBy = 1;
        //        _orderRepository.Add(mapObject);
        //    }
        //    await _orderRepository.SaveChangesAsync();
        //    var historyRecord = CreateHistoryRecord(orderModel.OrderId, "Placed", orderModel.PaymentMethod);
        //    await CreateOrderHistoryAsync(historyRecord);
        //    List<string> resultList = new List<string>();
        //    resultList.Add("Created successfully");
        //    return resultList;
        //}

        //public async Task<IEnumerable<string>> DeleteOrderAsync(int orderId)
        //{
        //    var saleOrder = await _orderRepository.GetOrderAsync(orderId);
        //    saleOrder.IsActive = false;
        //    await _orderRepository.SaveChangesAsync();
        //    List<string> resultList = new List<string>();
        //    resultList.Add("Deleted successfully");
        //    return resultList;
        //}

        //public async Task<IEnumerable<string>> UpdateOrderAsync(Order orderModel)
        //{
        //    var saleOrder = await _orderRepository.GetOrderAsync(orderModel.OrderId);
        //    saleOrder.TotalAmount = orderModel.TotalAmount;
        //    saleOrder.NetAmount = orderModel.NetAmount;
        //    saleOrder.DiscountAmount = orderModel.DiscountAmount;
        //    saleOrder.VatAmount = orderModel.VatAmount;
        //    saleOrder.DeliveryCharges = orderModel.DeliveryCharges;
        //    saleOrder.OrderStatus = orderModel.OrderStatus;
        //    saleOrder.PaymentMethod = orderModel.PaymentMethod;
        //    saleOrder.ShippingMode = orderModel.ShippingMode;
        //    saleOrder.TrackNumber = orderModel.TrackNumber;
        //    saleOrder.IsVatEnabled = orderModel.IsVatEnabled;
        //    saleOrder.DiscountPercent = orderModel.DiscountPercent;
        //    saleOrder.VatPercent = orderModel.VatPercent;
        //    saleOrder.CouponCode = orderModel.CouponCode;
        //    saleOrder.ModifiedBy = orderModel.ModifiedBy;
        //    await _orderRepository.SaveChangesAsync();


        //    var historyRecord = CreateHistoryRecord(orderModel.OrderId, orderModel.OrderStatus, orderModel.PaymentMethod);
        //    await CreateOrderHistoryAsync(historyRecord);

        //    List<string> resultList = new List<string>();
        //    resultList.Add("Updated successfully");
        //    return resultList;
        //}

        //public async Task<Order> GetOrderAsync(int orderId)
        //{
        //    return await _orderRepository.GetOrderAsync(orderId);
        //}

        //public async Task<IEnumerable<Order>> GetPagedOrdersAsync(GetPagedSearch request)
        //{
        //    return await _orderRepository.GetPagedOrdersAsync(request);
        //}

        //public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        //{
        //    return await _orderRepository.GetAllOrdersAsync();
        //}

        //public async Task<IEnumerable<string>> UpdateOrderDetailsAsync(Order orderModel)
        //{
        //    var saleOrder = await _orderRepository.GetOrderAsync(orderModel.OrderId);
        //    saleOrder.TotalAmount = orderModel.TotalAmount;
        //    saleOrder.NetAmount = orderModel.NetAmount;
        //    saleOrder.DiscountAmount = orderModel.DiscountAmount;
        //    saleOrder.VatAmount = orderModel.VatAmount;
        //    saleOrder.DeliveryCharges = orderModel.DeliveryCharges;
        //    saleOrder.OrderStatus = orderModel.OrderStatus;
        //    saleOrder.PaymentMethod = orderModel.PaymentMethod;
        //    saleOrder.ShippingMode = orderModel.ShippingMode;
        //    saleOrder.TrackNumber = orderModel.TrackNumber;
        //    saleOrder.IsVatEnabled = orderModel.IsVatEnabled;
        //    saleOrder.DiscountPercent = orderModel.DiscountPercent;
        //    saleOrder.VatPercent = orderModel.VatPercent;
        //    saleOrder.CouponCode = orderModel.CouponCode;
        //    saleOrder.ModifiedBy = orderModel.ModifiedBy;

        //    await _orderRepository.SaveChangesAsync();
        //    //Update existing records
        //    foreach (var item in saleOrder.OrderDetailsMaps)
        //    {
        //        var isMatched = orderModel.OrderDetailsMaps.ToList().Exists(e => e.OrderDetailId == item.OrderDetailId);

        //        if (!isMatched)
        //        {
        //            OrderDetailsMap mapObject = new OrderDetailsMap();
        //            mapObject = await _orderRepository.GetOrderDetailAsync(item.OrderDetailId);
        //            mapObject.IsActive = false;
        //        }
        //    }
        //    await _orderRepository.SaveChangesAsync();

        //    //Add new records
        //    foreach (var item in orderModel.OrderDetailsMaps)
        //    {
        //        var isMatched = saleOrder.OrderDetailsMaps.ToList().Exists(e => e.OrderDetailId == item.OrderDetailId);
        //        OrderDetailsMap mapObject = new OrderDetailsMap();
        //        if (isMatched)
        //        {
        //            mapObject = await _orderRepository.GetOrderDetailAsync(item.OrderDetailId);
        //            mapObject.Order = saleOrder;
        //            mapObject.OrderId = saleOrder.OrderId;
        //            mapObject.ProductId = item.ProductId;
        //            mapObject.SalePrice = item.SalePrice;
        //            mapObject.Qty = item.Qty;
        //            mapObject.ProductColourId = item.ProductColourId;
        //            mapObject.ProductSizeId = item.ProductSizeId;
        //        }
        //        else
        //        {
        //            mapObject.Order = saleOrder;
        //            mapObject.OrderId = saleOrder.OrderId;
        //            mapObject.ProductId = item.ProductId;
        //            mapObject.SalePrice = item.SalePrice;
        //            mapObject.Qty = item.Qty;
        //            mapObject.ProductColourId = item.ProductColourId;
        //            mapObject.ProductSizeId = item.ProductSizeId;
        //            _orderRepository.Add(mapObject);
        //        }
        //    }
        //    await _orderRepository.SaveChangesAsync();
        //    var historyRecord = CreateHistoryRecord(orderModel.OrderId, "Edited", orderModel.PaymentMethod);
        //    await CreateOrderHistoryAsync(historyRecord);

        //    List<string> resultList = new List<string>();
        //    resultList.Add("Updated successfully");
        //    return resultList;
        //}

        //public async Task<IEnumerable<OrderDetailsMap>> GetOrderDetailsAsync(int orderId)
        //{
        //    return await _orderRepository.GetOrderDetailsAsync(orderId);
        //}

        //public async Task<OrderDetailsMap> GetOrderDetailAsync(int orderDetailId)
        //{
        //    return await _orderRepository.GetOrderDetailAsync(orderDetailId);
        //}

        //public async Task<IEnumerable<OrderDetailsMap>> GetPagedOrderDetailsAsync(int orderId)
        //{
        //    return await _orderRepository.GetPagedOrderDetailsAsync(orderId);
        //}

        //#endregion

        //#region OrderHistoryMap

        //public async Task<IEnumerable<OrderHistoryMap>> GetOrderHistoryAsync(int orderId)
        //{
        //    return await _orderRepository.GetOrderHistoryAsync(orderId);
        //}

        //public async Task<OrderHistoryMap> GetOrderHistoryDetailsAsync(int orderHistoryId)
        //{
        //    return await _orderRepository.GetOrderHistoryDetailsAsync(orderHistoryId);
        //}

        //public async Task<IEnumerable<OrderHistoryMap>> GetPagedOrderHistoryDetailsAsync(int orderId)
        //{
        //    return await _orderRepository.GetPagedOrderHistoryDetailsAsync(orderId);
        //}

        //public async Task<IEnumerable<string>> CreateOrderHistoryAsync(OrderHistoryMap request)
        //{
        //    _orderRepository.Add(request);
        //    await _orderRepository.SaveChangesAsync();
        //    List<string> resultList = new List<string>();
        //    resultList.Add("Created successfully");
        //    return resultList;
        //}

        //public async Task<IEnumerable<string>> UpdateOrderHistoryAsync(OrderHistoryMap request)
        //{
        //    var OrderPaymentMap = await _orderRepository.GetOrderHistoryDetailsAsync(request.OrderHistoryId);
        //    await _orderRepository.SaveChangesAsync();
        //    List<string> resultList = new List<string>();
        //    resultList.Add("Updated successfully");
        //    return resultList;
        //}

        //public async Task<IEnumerable<string>> DeleteOrderHistoryAsync(int orderHistoryId)
        //{
        //    var orderHistoryDetail = await _orderRepository.GetOrderHistoryDetailsAsync(orderHistoryId);
        //    orderHistoryDetail.IsActive = false;
        //    await _orderRepository.SaveChangesAsync();
        //    List<string> resultList = new List<string>();
        //    resultList.Add("Deleted successfully");
        //    return resultList;
        //}
        //#endregion

        //#region OrderPaymentMap

        //public async Task<IEnumerable<OrderPaymentMap>> GetOrderPaymentsAsync(int orderId)
        //{
        //    return await _orderRepository.GetOrderPaymentsAsync(orderId);
        //}

        //public async Task<OrderPaymentMap> GetOrderPaymentDetailsAsync(int orderPaymentDetailId)
        //{
        //    return await _orderRepository.GetOrderPaymentDetailsAsync(orderPaymentDetailId);
        //}

        //public async Task<IEnumerable<OrderPaymentMap>> GetPagedOrderPaymentsAsync(int orderId)
        //{
        //    return await _orderRepository.GetPagedOrderPaymentsAsync(orderId);
        //}


        //public async Task<IEnumerable<string>> CreateOrderPaymentAsync(OrderPaymentMap request)
        //{
        //    _orderRepository.Add(request);
        //    await _orderRepository.SaveChangesAsync();
        //    List<string> resultList = new List<string>();
        //    resultList.Add("Created successfully");
        //    return resultList;
        //}

        //public async Task<IEnumerable<string>> UpdateOrderPaymentAsync(OrderPaymentMap request)
        //{
        //    var OrderPaymentMap = await _orderRepository.GetOrderPaymentDetailsAsync(request.OrderPaymentId);
        //    await _orderRepository.SaveChangesAsync();
        //    List<string> resultList = new List<string>();
        //    resultList.Add("Updated successfully");
        //    return resultList;
        //}

        //public async Task<IEnumerable<string>> DeleteOrderPaymentAsync(int orderPaymentId)
        //{
        //    var orderHistoryDetail = await _orderRepository.GetOrderPaymentDetailsAsync(orderPaymentId);
        //    orderHistoryDetail.IsActive = false;
        //    await _orderRepository.SaveChangesAsync();
        //    List<string> resultList = new List<string>();
        //    resultList.Add("Deleted successfully");
        //    return resultList;
        //}

        //#endregion


        #region Private Methods

        private async Task<int> CreateOrder(OrderDetailsModel request)
        {
            var orderModel = new Order()
            {
                UserId = request.UserId,
                ShopId = request.ShopId,
                ItemTotal = request.ItemTotal,
                NetAmount = request.ItemTotal,
                VatAmount = request.VatAmount,
                DiscountAmount = request.DiscountAmount,
                DeliveryCharges = request.DeliveryCharges,
                TotalWithOutVATAmount = request.TotalWithOutVATAmount,
                TotalWithVATAmount = request.TotalWithVATAmount,
                VatPercentage = request.VatPercentage,
                DiscountPercentage = request.DiscountPercentage,
                CouponCode = request.CouponCode,
                PaymentMethod = request.PaymentMethod,
                OrderStatus = request.OrderStatus,
                ShippingMode = request.ShippingMode,
                TrackNumber = request.TrackNumber,
                ShippingAddress = request.ShippingAddress,
                CreatedDate = DateTime.Now,
                CreatedBy = 1
            };
            _orderRepository.Add(orderModel);
            await _orderRepository.SaveChangesAsync();

            return orderModel.OrderId;
        }

        private async Task UpdateOrder(OrderDetailsModel request)
        {
            var orderModel = await _orderRepository.GetByIdAsync(request.OrderId ?? 0);
            orderModel.ItemTotal = request.ItemTotal;
            orderModel.VatAmount = request.VatAmount;
            orderModel.DiscountAmount = request.DiscountAmount;
            orderModel.DeliveryCharges = request.DeliveryCharges;
            orderModel.TotalWithOutVATAmount = request.TotalWithOutVATAmount;
            orderModel.TotalWithVATAmount = request.TotalWithVATAmount;
            orderModel.VatPercentage = request.VatPercentage;
            orderModel.DiscountPercentage = request.DiscountPercentage;
            orderModel.CouponCode = request.CouponCode;
            orderModel.ModifiedDate = DateTime.Now;
            orderModel.ModifiedBy = 1;
            await _orderRepository.SaveChangesAsync();
        }

        private async Task CreateHistoryRecord(int orderId, string orderStatus, string paymentMethod, string comments)
        {
            OrderHistoryMap OrderHistoryMap = new OrderHistoryMap();
            OrderHistoryMap.OrderId = orderId;
            OrderHistoryMap.OrderStatus = orderStatus;
            OrderHistoryMap.PaymentMethod = paymentMethod;
            OrderHistoryMap.Comments = comments;
            OrderHistoryMap.IsActive = true;
            OrderHistoryMap.CreatedDate = DateTime.Now;
            OrderHistoryMap.CreatedBy = 1;

            _orderRepository.Add(OrderHistoryMap);
            _orderRepository.SaveChangesAsync();
        }

    }

    #endregion
}

