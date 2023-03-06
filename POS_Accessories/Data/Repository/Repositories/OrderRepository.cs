using Microsoft.EntityFrameworkCore;
using POS_Accessories.Data.Repository.Interfaces;
using POS_Accessories.Models;
using POS_Accessories.Models.Request;

namespace POS_Accessories.Data.Repository.Repositories
{
    public class OrderRepository : Repository, IOrderRepository
    {
        public OrderRepository(AccessoriesDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<Order>> GetPagedOrdersAsync(GetPagedSearch request)
        {
            var result = await _context.Set<Order>().ToListAsync();
            return result;
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _context.Set<Order>()
                .Where(w => w.OrderId == id)
                .FirstOrDefaultAsync();
        }



        public async Task<IEnumerable<Order>> GetByPagingAsync(GetPagedSearch request)
        {
            var query = _context.Set<Order>();


            var result = await query
                .OrderByDescending(o => o.CreatedDate)
                .Skip((request.pageNo - 1) * request.pageSize)
                .Take(request.pageSize)
                .ToListAsync();

            return result;
        }

        public async Task<int> GetTotalCountAsync(GetPagedSearch request)
        {
            var query = _context.Set<Order>();

            return await query.CountAsync();
        }

        public async Task<IEnumerable<OrderDetailsMap>> GetOrderDetailsAsync(int orderId)
        {
            var result = await _context.Set<OrderDetailsMap>().Where(w => w.OrderId == orderId && w.IsActive == true).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<OrderHistoryMap>> GetOrderHistoryAsync(int orderId)
        {
            var result = await _context.Set<OrderHistoryMap>().Where(w => w.OrderId == orderId).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<OrderPaymentMap>> GetOrderPaymentsAsync(int orderId)
        {
            var result = await _context.Set<OrderPaymentMap>().Where(w => w.OrderId == orderId).ToListAsync();
            return result;
        }

        public async Task<OrderDetailsMap> GetOrderDetailAsync(int orderDetailId)
        {
            var result = await _context.Set<OrderDetailsMap>().Where(w => w.OrderId == orderDetailId).FirstOrDefaultAsync();
            return result;
        }

        public async Task<OrderHistoryMap> GetOrderHistoryDetailsAsync(int orderHistoryId)
        {
            var result = await _context.Set<OrderHistoryMap>().Where(w => w.OrderId == orderHistoryId).FirstOrDefaultAsync();
            return result;
        }

        public async Task<OrderPaymentMap> GetOrderPaymentDetailsAsync(int orderPaymentDetailId)
        {
            var result = await _context.Set<OrderPaymentMap>().Where(w => w.OrderId == orderPaymentDetailId).FirstOrDefaultAsync();
            return result;
        }

        public async Task<IEnumerable<OrderDetailsMap>> GetPagedOrderDetailsAsync(int orderId)
        {
            var result = await _context.Set<OrderDetailsMap>().Where(w => w.OrderId == orderId).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<OrderHistoryMap>> GetPagedOrderHistoryDetailsAsync(int orderId)
        {
            var result = await _context.Set<OrderHistoryMap>().Where(w => w.OrderId == orderId).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<OrderPaymentMap>> GetPagedOrderPaymentsAsync(int orderId)
        {
            var result = await _context.Set<OrderPaymentMap>().Where(w => w.OrderId == orderId).ToListAsync();
            return result;
        }
    }
}
