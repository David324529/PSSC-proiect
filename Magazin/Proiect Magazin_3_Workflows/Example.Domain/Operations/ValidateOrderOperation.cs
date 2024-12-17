using ProjectMagazin_3_Workflows.Domain.Models;

namespace ProjectMagazin_3_Workflows.Domain.Operations
{
    public class ValidateOrderOperation
    {
        public bool Validate(Order order)
        {
            return order.Items.Any() && order.TotalAmount > 0;
        }
    }
}