using Saref.Models.Shift;

namespace Saref.Services.ShiftServices
{
    public interface IShift
    {
        Task<Shift> CreateShift(Shift shift, int idStadium);
        Task<List<Shift>> GetAllShift();
        Task<Shift> GetShiftById(int idStadium);
    }
}
