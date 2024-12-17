using Microsoft.EntityFrameworkCore;
using ProjectMagazin_3_Workflows.Data.Models;

namespace ProjectMagazin_3_Workflows.Data.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly AppDbContext _context;

        public OrdersRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task SaveAsync(OrderDto order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task<OrderDto?> GetByIdAsync(string orderId)
        {
            return await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == orderId);
        }

        // Implement the GetAllAsync method to retrieve all orders
        public async Task<IEnumerable<OrderDto>> GetAllAsync()
        {
            return await _context.Orders.ToListAsync();
        }
    }
}