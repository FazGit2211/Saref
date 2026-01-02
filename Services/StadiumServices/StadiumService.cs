using Microsoft.EntityFrameworkCore;
using Saref.Data;
using Saref.Exceptions;
using Saref.Models.Dtos;
using Saref.Models.Stadium;

namespace Saref.Services.StadiumServices
{
    public class StadiumService : IStadium
    {
        //Inyectar contexto de la base de datos
        private readonly ContextDB _contextDB;

        public StadiumService(ContextDB context)
        {
            _contextDB = context;
        }
        public async Task CreateNew(DtoStadium dtoStadium)
        {
            Stadium createStadium = new Stadium(dtoStadium.Name, dtoStadium.Address);
            _contextDB.Stadiums.Add(createStadium);
            await _contextDB.SaveChangesAsync();
        }

        public async Task DeleteStadium(int id)
        {
            Stadium stadiumDelete = await _contextDB.Stadiums.FindAsync(id);
            if (stadiumDelete == null)
            {
                throw new NotFoundException("Stadium not exist");
            }
            _contextDB.Stadiums.Remove(stadiumDelete);
            await _contextDB.SaveChangesAsync();
        }

        public async Task<List<Stadium>> GetAllStadiums()
        {
            List<Stadium> list = await _contextDB.Stadiums.Include(shift => shift.Shifts).ToListAsync();
            if (list.Count == 0 || list == null)
            {
                throw new BadRequestException("Not Content");
            }
            return list;
        }

        public async Task<Stadium> GetStadiumById(int id)
        {
            return await _contextDB.Stadiums.FindAsync(id);
        }

        public async Task UpdateStadium(DtoStadium dtoStadium, int id)
        {
            Stadium stadiumUpdate = await _contextDB.Stadiums.FindAsync(id);
            if (stadiumUpdate == null)
            {
                throw new NotFoundException("Stadium not exist");
            }
            stadiumUpdate.Name = dtoStadium.Name;
            stadiumUpdate.Address = dtoStadium.Address;
            _contextDB.Stadiums.Update(stadiumUpdate);
            await _contextDB.SaveChangesAsync();
        }
    }
}
