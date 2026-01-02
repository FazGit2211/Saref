using Saref.Models.Client;
using Saref.Models.Dtos;

namespace Saref.Services.ClientServices
{
    public interface IClient
    {
        Task<List<Client>> GetClients();
        Task UpdateClientById(string id, DtoClient dtoClient);
        Task DeleteClientById(string id);
    }
}
