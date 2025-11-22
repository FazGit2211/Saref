using Saref.Models.Product;

namespace Saref.Services.ProductServices.ShoesService
{
    public interface IShoes
    {
        Task<Shoes> CreateShoes(Shoes shoes);
        Task<List<Shoes>> GetShoes();
    }
}
