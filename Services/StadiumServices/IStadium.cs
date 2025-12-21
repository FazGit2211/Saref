using Saref.Models.Dtos;
using Saref.Models.Stadium;

namespace Saref.Services.StadiumServices
{
    public interface IStadium
    {
        Task CreateNew(DtoStadium dtoStadium);
        Task<List<Stadium>> GetAllStadiums();
        Task<Stadium> GetStadiumById(int id);

        Task UpdateStadium(DtoStadium dtoStadium, int id);
        Task DeleteStadium(int id);
    }
}
