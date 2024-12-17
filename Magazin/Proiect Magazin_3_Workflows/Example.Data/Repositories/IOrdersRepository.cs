using ProjectMagazin_3_Workflows.Data.Models;

namespace ProjectMagazin_3_Workflows.Data.Repositories
{
    public interface IOrdersRepository
    {
        Task SaveAsync(OrderDto order);
        Task<OrderDto?> GetByIdAsync(string orderId);

        // Add method to fetch all orders
        Task<IEnumerable<OrderDto>> GetAllAsync();
    }
}