
using Microsoft.EntityFrameworkCore;
using Saref.Data;
using Saref.Models.Client;
using Saref.Models.Dtos;
using Saref.Models.Shift;
using Saref.Models.Stadium;
using Saref.Services.StadiumServices;

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
        public async Task<DtoShift> CreateShift(Shift shift, int idStadium, int idClient)
        {
            try
            {
                if (shift.Day.Equals(null) || shift.Price.Equals(null) || idStadium <= 0 || idClient <= 0)
                {
                    return null;
                }
                
                //Consultar la existencia del estadio
                Stadium stadiumExist = await _contextDB.Stadiums.FindAsync(idStadium);
                Client clientExist = await _contextDB.Clients.FindAsync(idClient);
                if (stadiumExist == null || clientExist == null)
                {
                    return null;
                }
                shift.StadiumId = idStadium;
                shift.ClientId = idClient;
                _contextDB.Shifts.Add(shift);
                await _contextDB.SaveChangesAsync();
                return new DtoShift(shift.Id,shift.Day,shift.Time,Convert.ToInt16(shift.Price),stadiumExist,clientExist);
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
                List<Shift> shifts = await _contextDB.Shifts.ToListAsync();
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
                Stadium stadiumExist = await _contextDB.Stadiums.FindAsync(shift.StadiumId);
                Client clientExist = await _contextDB.Clients.FindAsync(shift.ClientId);
                DtoShift dtoShift = new DtoShift(shift.Id, shift.Day, shift.Time, shiftPrice,stadiumExist,clientExist);
                return dtoShift;
            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task<Shift> UpdateShift(Shift shift, int idShift)
        {
            try
            {
                if (shift.Day.Equals(null) || shift.Price.Equals(null) || idShift <= 0)
                {
                    return null;

                }
                Shift shiftExist = await _contextDB.Shifts.FindAsync(idShift);
                if (shiftExist == null)
                {
                    return null;
                }
                shiftExist.Day = shift.Day;
                shiftExist.Time = shift.Time;
                shiftExist.Price = shift.Price;
                await _contextDB.SaveChangesAsync();
                return shiftExist;
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
