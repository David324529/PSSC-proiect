using ProjectMagazin_3_Workflows.Data.Models;

namespace ProjectMagazin_3_Workflows.Data.Repositories
{
    public interface IInvoicesRepository
    {
        Task SaveAsync(InvoiceDto invoice);
        Task<InvoiceDto?> GetByOrderIdAsync(string orderId);

        // Add method to fetch all invoices
        Task<IEnumerable<InvoiceDto>> GetAllAsync();
    }
}