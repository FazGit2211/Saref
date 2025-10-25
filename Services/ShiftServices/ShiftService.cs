
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Saref.Data;
using Saref.Models.Dtos;
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

        public async Task<DtoShift> GetShiftById(int idShift)
        {
            try
            {
                if (idShift <= 0)
                {
                    return null;
                }
                Shift shift = await _contextDB.Shifts.FindAsync(idShift);
                if (shift == null)
                {
                    return null;
                }
                float shiftPrice = (float)shift.Price;
                DtoShift dtoShift = new DtoShift(shift.Id, shift.Day, shift.Time, shiftPrice);
                return dtoShift;
            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task<List<Shift>> GetShiftByStadium(int stadiumId)
        {
            try
            {
                if (stadiumId <= 0) { return null; }
                var list = from shift in _contextDB.Shifts where shift.StadiumId.Equals(stadiumId) select shift;
                if (list.IsNullOrEmpty()) { return new List<Shift>(); }
                DtoShift dtoShift = new DtoShift();
                foreach (var shift in list)
                {
                    dtoShift.shifts.Add(shift);
                }
                return dtoShift.shifts;
            }
            catch { throw new Exception(); }
        }
    }
}
