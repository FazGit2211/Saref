using Microsoft.EntityFrameworkCore;
using Saref.Data;
using Saref.Exceptions;
using Saref.Models.Client;
using Saref.Models.Dtos;

namespace Saref.Services.ClientServices
{
    public class ClientService : IClient
    {
        private readonly ContextDB _contextDb;

        public ClientService(ContextDB contextDB)
        {
            _contextDb = contextDB;
        }

        public async Task<List<Client>> GetClients()
        {
            return await _contextDb.Clients.ToListAsync();
        }

        public async Task UpdateClientById(string id, DtoClient dtoClient)
        {
            Client clientExist = await _contextDb.Clients.FindAsync(id);
            if (clientExist == null)
            {
                throw new NotFoundException("Client not exist");
            }
            clientExist.Name = dtoClient.Name;
            clientExist.DocumentNumber = dtoClient.DocumentNumber;
            clientExist.Address = dtoClient.Address;
            _contextDb.Clients.Update(clientExist);
            await _contextDb.SaveChangesAsync();
        }

        public async Task DeleteClientById(string id)
        {
            Client clientExist = await _contextDb.Clients.FindAsync(id);
            if (clientExist == null)
            {
                throw new NotFoundException("Client not exist");
            }
            _contextDb.Remove(clientExist);
            await _contextDb.SaveChangesAsync();
        }
    }
}
