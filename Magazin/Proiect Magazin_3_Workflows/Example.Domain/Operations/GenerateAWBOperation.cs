using ProjectMagazin_3_Workflows.Domain.Models;

namespace ProjectMagazin_3_Workflows.Domain.Operations
{
    public class GenerateAWBOperation
    {
        public string Generate(Order order)
        {
            return $"AWB-{Guid.NewGuid()}"; // Example: Generate a unique AWB
        }
    }
}