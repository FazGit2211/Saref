using Saref.Models.Stadium;

namespace Saref.Services.StadiumServices
{
    public interface IStadium
    {
        Task<Stadium> CreateNew(Stadium stadium);
        Task<List<Stadium>> GetAllStadiums();
        Task<Stadium> GetStadiumById(int id);
    }
}
