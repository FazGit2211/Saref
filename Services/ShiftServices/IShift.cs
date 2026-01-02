using Saref.Models.Dtos;
using Saref.Models.Shift;

namespace Saref.Services.ShiftServices
{
    public interface IShift
    {
        Task CreateShift(DtoShift shift);
        Task<List<Shift>> GetAllShift();
        Task<Shift> GetShiftById(int id);
        Task UpdateShift(DtoShift shift, int shiftId);
        Task DeleteShift(int id);
        Task<Shift> AddClientToShift(int shiftId, string clientId);
    }
}
