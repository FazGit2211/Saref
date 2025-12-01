using Microsoft.EntityFrameworkCore;
using Saref.Data;
using Saref.Models.Dtos;
using Saref.Models.Product;

namespace Saref.Services.ProductServices.TshirtService
{
    public class TshirtService : ITshirt
    {
        private readonly ContextDB _contextDb;
        private bool EmptyTshirt = true;
        private bool EmptyIdTshirt = true;
        public TshirtService(ContextDB contextDb)
        {
            _contextDb = contextDb;
        }
        public async Task<Tshirt> CreateTshirt(DtoProduct dtoProduct)
        {
            try
            {
                EmptyTshirt = EmptyValueTshirt(dtoProduct);
                if (EmptyTshirt) {
                    throw new Exception("Empty Values");
                }
                Tshirt createTshirt = new Tshirt(dtoProduct.Name, dtoProduct.Description,dtoProduct.Price);               
                _contextDb.Tshirts.Add(createTshirt);
                await _contextDb.SaveChangesAsync();
                return createTshirt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Tshirt> DeleteTshirt(int id)
        {
            try
            {
                EmptyIdTshirt = EmptyValueId(id);
                if (EmptyIdTshirt)
                {
                    throw new Exception("ID not valid");
                }
                var tshirtExist = await _contextDb.Tshirts.FindAsync(id);
                if (tshirtExist == null)
                {
                    throw new Exception("Tshirt not found");
                }
                _contextDb.Tshirts.Remove(tshirtExist);
                await _contextDb.SaveChangesAsync();
                return tshirtExist;
            }
            catch (Exception ex) { 
                throw ex;
            }
        }

        public async Task<List<Tshirt>> GetTshirts()
        {
            try
            {
                return await _contextDb.Tshirts.Where(tsh => tsh.TypeDiscriminator.Equals("Tshirt")).ToListAsync();
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<Tshirt> UpdateTshirt(DtoProduct dtoProduct, int id)
        {
            try
            {
                EmptyTshirt = EmptyValueTshirt(dtoProduct);
                if (EmptyTshirt)
                {
                    throw new Exception("Empty Values");
                }
                EmptyIdTshirt = EmptyValueId(id);
                if (EmptyIdTshirt)
                {
                    throw new Exception("ID not valid");
                }
                var tshirtExist = await _contextDb.Tshirts.FindAsync(id);
                if (tshirtExist == null) {
                    throw new Exception("Tshirt not found");
                }
                Tshirt updateTshirt = new Tshirt(dtoProduct.Name, dtoProduct.Description, dtoProduct.Price);                
                _contextDb.Tshirts.Add(updateTshirt);
                await _contextDb.SaveChangesAsync();
                return tshirtExist;
            }catch (Exception ex) { throw ex; }
        }

        private bool EmptyValueTshirt(DtoProduct tshirt)
        {
            if (tshirt.Name.Trim().Equals("") || tshirt.Price <= 0)
            {
                return true;
            }
            return false;
        }
        private bool EmptyValueId(int id)
        {
            if (id <= 0)
            {
                return true;
            }
            return false;
        }
    }
}


