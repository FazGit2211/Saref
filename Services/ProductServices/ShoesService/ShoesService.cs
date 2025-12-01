using Microsoft.EntityFrameworkCore;
using Saref.Data;
using Saref.Models.Product;

namespace Saref.Services.ProductServices.ShoesService
{
    public class ShoesService : IShoes
    {
        private readonly ContextDB _contextDb;
        private bool EmptyShoes = true;
        private bool EmptyIdShoes = true;

        public ShoesService(ContextDB contextDb)
        {
            _contextDb = contextDb;
        }
        public async Task<Shoes> CreateShoes(Shoes shoes)
        {
            try
            {
                EmptyShoes = EmptyValuesShoes(shoes);
                if (EmptyShoes)
                {
                    throw new Exception("Empty Values");
                }
                _contextDb.Add(shoes);
                await _contextDb.SaveChangesAsync();
                return shoes;
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public async Task<Shoes> DeleteShoes(int id)
        {
            try
            {
                EmptyIdShoes = EmptyValueId(id);
                if (EmptyIdShoes)
                {
                    throw new Exception("Empty Values");
                }
                var shoesExist = await _contextDb.Shoes.FindAsync(id);
                if (shoesExist == null)
                {
                    throw new Exception("ID not valid");
                }
                _contextDb.Remove(shoesExist);
                await _contextDb.SaveChangesAsync();
                return shoesExist;
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

        public async Task<Shoes> UpdateShoes(Shoes shoes, int id)
        {
            try
            {
                EmptyShoes = EmptyValuesShoes(shoes);
                if (EmptyShoes)
                {
                    throw new Exception("Empty Values");
                }
                EmptyIdShoes = EmptyValueId(id);
                if (EmptyIdShoes)
                {
                    throw new Exception("ID not valid");
                }
                var shoesExist = await _contextDb.Shoes.FindAsync(id);
                if (shoesExist == null)
                {
                    throw new Exception("Tshirt not found");
                }
                shoesExist.Name = shoes.Name;
                shoesExist.Price = shoes.Price;
                shoesExist.Description = shoes.Description;
                _contextDb.Update(shoesExist);
                await _contextDb.SaveChangesAsync();
                return shoesExist;
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        private bool EmptyValuesShoes(Shoes shoes) {
            if (shoes.Name.Trim().Equals("") && shoes.Price <= 0)
            {
                return true;
            }
            return false;
        }

        private bool EmptyValueId(int id)
        {
            if(id <= 0)
            {
                return true;
            }
            return false;
        }
    }
}
