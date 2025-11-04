using Microsoft.EntityFrameworkCore;
using Saref.Data;
using Saref.Models.Client;
using Saref.Models.User;

namespace Saref.Services.ClientServices
{
    public class ClientService : IClient
    {
        private readonly ContextDB _contextDb;

        public ClientService(ContextDB contextDB)
        {
            _contextDb = contextDB;
        }
        public async Task<Client> CreateClient(Client paramClient, int paramUserId)
        {
            try
            {
                if (paramClient.Name.Trim().Equals("") || paramClient.Email.Trim().Equals("") || paramUserId <= 0)
                {
                    return null;
                }
                User userExist = await _contextDb.Users.FindAsync(paramUserId);
                if (userExist == null)
                {
                    return null;
                }
                paramClient.UsuarioId = paramUserId;
                _contextDb.Clients.Add(paramClient);
                await _contextDb.SaveChangesAsync();
                return paramClient;
            }
            catch (Exception ex) {
                throw new Exception();
            }
        }

        public Task<List<Client>> GetClients()
        {
            throw new NotImplementedException();
        }
    }
}
