using Microsoft.EntityFrameworkCore;
using Saref.Data;
using Saref.Models.Dtos;
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
        public async Task<Shoes> CreateShoes(DtoProduct dtoProduct)
        {
            try
            {
                EmptyShoes = EmptyValuesShoes(dtoProduct);
                if (EmptyShoes)
                {
                    throw new Exception("Empty Values");
                }
                Shoes createShoes = new Shoes(dtoProduct.Name,dtoProduct.Description,dtoProduct.Price);
                _contextDb.Shoes.Add(createShoes);
                await _contextDb.SaveChangesAsync();
                return createShoes;
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
                var shoesDelete = await _contextDb.Shoes.FindAsync(id);
                if (shoesDelete == null)
                {
                    throw new Exception("ID not valid");
                }
                _contextDb.Shoes.Remove(shoesDelete);
                await _contextDb.SaveChangesAsync();
                return shoesDelete;
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

        public async Task<Shoes> UpdateShoes(DtoProduct dtoProduct, int id)
        {
            try
            {
                EmptyShoes = EmptyValuesShoes(dtoProduct);
                if (EmptyShoes)
                {
                    throw new Exception("Empty Values");
                }
                EmptyIdShoes = EmptyValueId(id);
                if (EmptyIdShoes)
                {
                    throw new Exception("ID not valid");
                }
                var shoesUpdate = await _contextDb.Shoes.FindAsync(id);
                if (shoesUpdate == null)
                {
                    throw new Exception("Tshirt not found");
                }
                shoesUpdate.Name = dtoProduct.Name;
                shoesUpdate.Price = dtoProduct.Price;
                shoesUpdate.Description = dtoProduct.Description;
                _contextDb.Shoes.Update(shoesUpdate);
                await _contextDb.SaveChangesAsync();
                return shoesUpdate;
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        private bool EmptyValuesShoes(DtoProduct dtoProduct) {
            if (dtoProduct.Name.Trim().Equals("") && dtoProduct.Price <= 0)
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
