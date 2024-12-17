using Microsoft.EntityFrameworkCore;
using ProjectMagazin_3_Workflows.Data.Models;

namespace ProjectMagazin_3_Workflows.Data.Repositories
{
    public class InvoicesRepository : IInvoicesRepository
    {
        private readonly AppDbContext _context;

        public InvoicesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task SaveAsync(InvoiceDto invoice)
        {
            await _context.Invoices.AddAsync(invoice);
            await _context.SaveChangesAsync();
        }

        public async Task<InvoiceDto?> GetByOrderIdAsync(string orderId)
        {
            return await _context.Invoices.FirstOrDefaultAsync(i => i.OrderId == orderId);
        }

        // Implement the GetAllAsync method to retrieve all invoices
        public async Task<IEnumerable<InvoiceDto>> GetAllAsync()
        {
            return await _context.Invoices.ToListAsync();
        }
    }
}