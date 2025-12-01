using Saref.Models.Dtos;
using Saref.Models.Product;

namespace Saref.Services.ProductServices.TshirtService
{
    public interface ITshirt
    {
        Task<Tshirt> CreateTshirt(DtoProduct tshirt);
        Task<List<Tshirt>> GetTshirts();

        Task<Tshirt> UpdateTshirt(DtoProduct tshirt, int id);

        Task<Tshirt> DeleteTshirt(int id);
    }
}
