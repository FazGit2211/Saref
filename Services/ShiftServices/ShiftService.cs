
using Microsoft.AspNetCore.Identity;
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

        //Inyectar UserManager
        private readonly UserManager<Client> _userManager;
        public ShiftService(ContextDB contextDB, UserManager<Client> userManager)
        {
            _contextDB = contextDB;
            _userManager = userManager;
        }
        public async Task<DtoShift> CreateShift(Shift shift)
        {
            try
            {
                if (shift.Day == null || shift.Price <= 0 || shift.Client == null && shift.Stadium == null )
                {
                    return null;
                }

                //Consultar la existencia del estadio
                Stadium stadiumExist = await _contextDB.Stadiums.FindAsync(shift.Stadium.Id);
                Client clientExist = await _userManager.FindByIdAsync(shift.Client.Id);
                if (stadiumExist == null && clientExist == null)
                {
                    return null;
                }
                Shift newShift = new Shift(shift.Day,shift.Time,shift.Price,stadiumExist,clientExist);
                _contextDB.Shifts.Add(newShift);
                await _contextDB.SaveChangesAsync();
                return new DtoShift(shift.Day, shift.Time, Convert.ToInt16(shift.Price), stadiumExist);
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
                Stadium stadiumExist = await _contextDB.Stadiums.FindAsync(shift.Stadium.Id);
                Client clientExist = await _userManager.FindByIdAsync(shift.Client.Id);
                DtoShift dtoShift = new DtoShift(shift.Day, shift.Time, shiftPrice, stadiumExist, clientExist);
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
