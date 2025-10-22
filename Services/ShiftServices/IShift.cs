using Saref.Models.Dtos;
using Saref.Models.Shift;

namespace Saref.Services.ShiftServices
{
    public interface IShift
    {
        Task<Shift> CreateShift(Shift shift, int idStadium);
        Task<List<Shift>> GetAllShift();
        Task<DtoShift> GetShiftById(int idShift);
        Task<List<Shift>> GetShiftByStadium(int stadiumId);
    }
}
