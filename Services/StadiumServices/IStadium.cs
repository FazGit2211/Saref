using Saref.Models.Dtos;
using Saref.Models.Stadium;

namespace Saref.Services.StadiumServices
{
    public interface IStadium
    {
        Task<Stadium> CreateNew(DtoStadium dtoStadium);
        Task<List<Stadium>> GetAllStadiums();
        Task<Stadium> GetStadiumById(int id);

        Task<Stadium> UpdateStadium(DtoStadium dtoStadium, int id);
        Task<Stadium> DeleteStadium(int id);
    }
}
