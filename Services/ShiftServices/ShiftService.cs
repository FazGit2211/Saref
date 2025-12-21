
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Saref.Data;
using Saref.Exceptions;
using Saref.Models.Client;
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
        public async Task CreateShift(DtoShift dtoShift)
        {
            //Consultar la existencia del estadio
            Stadium? stadiumExist = await _contextDB.Stadiums.FindAsync(dtoShift.StadiumId);
            if (stadiumExist == null){
                throw new NotFoundException("Stadium not exist");
            }
            Shift createShift = new Shift(dtoShift.Day,dtoShift.Time,dtoShift.Price,stadiumExist);            
            byte state = (byte) Shift.StateShift.available;
            createShift.State = Shift.ConvertStateShift(state);
            _contextDB.Shifts.Add(createShift);
            await _contextDB.SaveChangesAsync();
        }

        public async Task<List<Shift>> GetAllShift()
        {
            List<Shift> shifts = await _contextDB.Shifts.Include(shift => shift.Stadium).ToListAsync();
            if(shifts.Count == 0 || shifts == null)
            {
                throw new NotFoundException("Not Content"); ;
            }
            return shifts;
        }

        public async Task<Shift> GetShiftById(int idShift)
        {
            Shift shift = await _contextDB.Shifts.FindAsync(idShift);
            if (shift == null){ 
                throw new NotFoundException("Stadium not exist");
            }
            return shift;            
        }

        public async Task UpdateShift(DtoShift dtoShift, int shiftId, int clientId)
        {
            Shift shiftExist = await _contextDB.Shifts.FindAsync(shiftId);
            if (shiftExist == null){ 
                throw new NotFoundException("Stadium not exist");
            }
            //Consultar la existencia del estadio
            Stadium? stadiumExist = await _contextDB.Stadiums.FindAsync(dtoShift.StadiumId);
            if (stadiumExist == null)
            {
                throw new NotFoundException("Stadium not exist");
            }
            DtoClient dtoClient = new DtoClient();
            if(clientId != null || clientId > 0)
            {
                Client? client = await _contextDB.Clients.FindAsync(clientId);
                if (client != null) {
                    dtoClient.Name = client.Name;
                    dtoClient.Username = client.UserName;
                    dtoClient.Address = client.Address;
                    dtoClient.DocumentNumber = client.DocumentNumber;
                }
            }
            Shift updateShift = new Shift();
            updateShift.Day = dtoShift.Day;
            updateShift.Time = dtoShift.Time;
            updateShift.Price = dtoShift.Price;                        
            updateShift.State = dtoShift.State;
            updateShift.Stadium = stadiumExist;
            updateShift.Client.Name = dtoClient.Name;
            updateShift.Client.Address = dtoClient.Address;
            updateShift.Client.DocumentNumber = dtoClient.DocumentNumber;
            updateShift.Client.Address = dtoClient.Address;
            _contextDB.Shifts.Update(updateShift);
            await _contextDB.SaveChangesAsync();
        }

        public async Task DeleteShift(int id)
        {           
            Shift? shift = await _contextDB.Shifts.FindAsync(id);
            if (shift == null)
            {
                throw new NotFoundException("Stadium not exist");
            }
            _contextDB.Shifts.Remove(shift);
            await _contextDB.SaveChangesAsync();
        }        
    }
}
