using Saref.Models.Dtos;
using Saref.Models.Shift;

namespace Saref.Services.ShiftServices
{
    public interface IShift
    {
        Task<DtoShift> CreateShift(Shift shift);
        Task<List<Shift>> GetAllShift();
        Task<DtoShift> GetShiftById(int idShift);

        Task<Shift> UpdateShift(Shift shift, int idShift);
    }
}
