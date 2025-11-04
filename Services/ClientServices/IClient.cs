using Saref.Models.Client;

namespace Saref.Services.ClientServices
{
    public interface IClient
    {
        Task<Client> CreateClient(Client paramClient, int paramUserId);
        Task<List<Client>> GetClients();
    }
}
