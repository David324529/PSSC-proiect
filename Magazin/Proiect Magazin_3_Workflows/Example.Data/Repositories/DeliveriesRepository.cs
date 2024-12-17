using Microsoft.EntityFrameworkCore;
using ProjectMagazin_3_Workflows.Data.Models;

namespace ProjectMagazin_3_Workflows.Data.Repositories
{
    public class DeliveriesRepository : IDeliveriesRepository
    {
        private readonly AppDbContext _context;

        public DeliveriesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task SaveAsync(DeliveryDto delivery)
        {
            await _context.Deliveries.AddAsync(delivery);
            await _context.SaveChangesAsync();
        }

        public async Task<DeliveryDto?> GetByOrderIdAsync(string orderId)
        {
            return await _context.Deliveries.FirstOrDefaultAsync(d => d.OrderId == orderId);
        }

        // Implement the GetAllAsync method to retrieve all deliveries
        public async Task<IEnumerable<DeliveryDto>> GetAllAsync()
        {
            return await _context.Deliveries.ToListAsync();
        }
    }
}