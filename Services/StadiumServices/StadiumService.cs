using Microsoft.EntityFrameworkCore;
using Saref.Data;
using Saref.Models.Dtos;
using Saref.Models.Stadium;
using Saref.Services.Tads;

namespace Saref.Services.StadiumServices
{
    public class StadiumService : IStadium
    {
        //Inyectar contexto de la base de datos
        private readonly ContextDB _contextDB;
        private bool EmptyStadium = true;
        private bool EmptyIdStadium = true;
        public StadiumService(ContextDB context)
        {
            _contextDB = context;
        }
        public async Task<Stadium> CreateNew(DtoStadium dtoStadium)
        {
            try
            {
                EmptyStadium = EmptyValues(dtoStadium);
                if (EmptyStadium)
                {
                    throw new Exception("Empty values");
                }
                Stadium createStadium = new Stadium(dtoStadium.Name, dtoStadium.Address);
                _contextDB.Stadiums.Add(createStadium);
                await _contextDB.SaveChangesAsync();
                return createStadium;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Stadium> DeleteStadium(int id)
        {
            try
            {
                EmptyIdStadium = EmptyValueId(id);
                if (EmptyIdStadium)
                {
                    throw new Exception("ID not valid");
                }
                Stadium stadiumDelete = await _contextDB.Stadiums.FindAsync(id);
                if (stadiumDelete == null)
                {
                    throw new Exception("Stadium not found");
                }
                _contextDB.Stadiums.Remove(stadiumDelete);
                await _contextDB.SaveChangesAsync();
                return stadiumDelete;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Stadium>> GetAllStadiums()
        {
            try
            {
                List<Stadium> list = await _contextDB.Stadiums.Include(shift => shift.Shifts).ToListAsync();
                if(list.Count == 0 || list == null)
                {
                    throw new Exception("Not content");
                }
                return list;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Stadium> GetStadiumById(int id)
        {
            try
            {
                EmptyIdStadium = EmptyValueId(id);
                if (EmptyIdStadium)
                {
                    throw new Exception("ID not valid");
                }
                return await _contextDB.Stadiums.FindAsync(id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Stadium> UpdateStadium(DtoStadium dtoStadium, int id)
        {
            try
            {
                EmptyStadium = EmptyValues(dtoStadium);
                if (EmptyStadium)
                {
                    throw new Exception("Empty values");
                }
                EmptyIdStadium = EmptyValueId(id);
                if (EmptyIdStadium)
                {
                    throw new Exception("ID not valid");
                }
                Stadium stadiumUpdate = await _contextDB.Stadiums.FindAsync(id);
                if(stadiumUpdate == null)
                {
                    throw new Exception("Stadium not found");
                }
                stadiumUpdate.Name = dtoStadium.Name;
                stadiumUpdate.Address = dtoStadium.Address;
                _contextDB.Stadiums.Update(stadiumUpdate);
                await _contextDB.SaveChangesAsync();
                return stadiumUpdate;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        private bool EmptyValues(DtoStadium dtoStadium)
        {
            if (dtoStadium.Name.Trim() == "" || dtoStadium.Address.Trim() == "")
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
