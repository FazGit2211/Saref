using Saref.Models.Product;

namespace Saref.Services.ProductServices.TshirtService
{
    public interface ITshirt
    {
        Task<Tshirt> CreateTshirt(Tshirt tshirt);
        Task<List<Tshirt>> GetTshirts();
    }
}
