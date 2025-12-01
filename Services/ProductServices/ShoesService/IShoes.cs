using Saref.Models.Dtos;
using Saref.Models.Product;

namespace Saref.Services.ProductServices.ShoesService
{
    public interface IShoes
    {
        Task<Shoes> CreateShoes(DtoProduct dtoProduct);
        Task<List<Shoes>> GetShoes();
        Task<Shoes> UpdateShoes(DtoProduct dtoProduct, int id);
        Task<Shoes> DeleteShoes(int id);
    }
}
