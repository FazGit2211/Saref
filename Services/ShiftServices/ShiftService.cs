using Microsoft.EntityFrameworkCore;
using Saref.Data;
using Saref.Models.Shift;
using Saref.Models.Stadium;

namespace Saref.Services.ShiftServices
{
    public class ShiftService : IShift
    {
        //Inyectar contexto de la base de datos
        private readonly ContextDB _contextDB;
        public ShiftService(ContextDB contextDB)
        {
            _contextDB = contextDB;
        }
        public async Task<Shift> CreateShift(Shift shift, int idStadium)
        {
            try
            {
                if (shift.Day.Equals(null) || shift.Price.Equals(null))
                {
                    return null;
                }
                /*
                //Consultar la existencia del estadio
                Stadium stadium = await _contextDB.Stadiums.FindAsync(idStadium);
                if (stadium == null)
                {
                    return null;
                }*/
                shift.StadiumId = idStadium;
                _contextDB.Shifts.Add(shift);
                await _contextDB.SaveChangesAsync();
                return shift;
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<Shift>> GetAllShift()
        {
            try
            {
                List<Shift> shifts = await _contextDB.Shifts.Include(st => st.Stadium).ToListAsync();
                return shifts;
            }
            catch
            {
                return null;
            }
        }

        Task<Shift> IShift.GetShiftById(int idStadium)
        {
            throw new NotImplementedException();
        }
    }
}
