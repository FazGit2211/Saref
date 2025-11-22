using Microsoft.EntityFrameworkCore;
using Saref.Data;
using Saref.Models.Product;

namespace Saref.Services.ProductServices.TshirtService
{
    public class TshirtService : ITshirt
    {
        private readonly ContextDB _contextDb;
        public TshirtService(ContextDB contextDb)
        {
            _contextDb = contextDb;
        }
        public async Task<Tshirt> CreateTshirt(Tshirt tshirt)
        {
            try
            {
                if (tshirt.Name.Trim().Equals("") && tshirt.Price <= 0)
                {
                    return null;
                }
                _contextDb.Add(tshirt);
                await _contextDb.SaveChangesAsync();
                return tshirt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Tshirt>> GetTshirts()
        {
            try
            {
                return await _contextDb.Tshirts.ToListAsync();
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
