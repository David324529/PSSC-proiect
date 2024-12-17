using ProjectMagazin_3_Workflows.Data.Models;

namespace ProjectMagazin_3_Workflows.Data.Repositories
{
    public interface IDeliveriesRepository
    {
        Task SaveAsync(DeliveryDto delivery);
        Task<DeliveryDto?> GetByOrderIdAsync(string orderId);

        // Add method to fetch all deliveries
        Task<IEnumerable<DeliveryDto>> GetAllAsync();
    }
}