using Microsoft.EntityFrameworkCore;
using Saref.Data;
using Saref.Models.Product;

namespace Saref.Services.ProductServices.ShoesService
{
    public class ShoesService : IShoes
    {
        private readonly ContextDB _contextDb;

        public ShoesService(ContextDB contextDb)
        {
            _contextDb = contextDb;
        }
        public async Task<Shoes> CreateShoes(Shoes shoes)
        {
            try
            {
                if (shoes.Name.Trim().Equals("") && shoes.Price <= 0)
                {
                    return null;
                }
                _contextDb.Add(shoes);
                await _contextDb.SaveChangesAsync();
                return shoes;
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public async Task<List<Shoes>> GetShoes()
        {
            try
            {
                return await _contextDb.Shoes.ToListAsync();
            }
            catch (Exception ex) {
                throw ex;
            }
        }
    }
}
