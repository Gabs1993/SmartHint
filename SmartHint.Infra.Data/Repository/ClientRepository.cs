using Microsoft.EntityFrameworkCore;
using SmartHint.Domain.Entities;
using SmartHint.Domain.Interfaces;
using SmartHint.Infra.Data.Context;


namespace SmartHint.Infra.Data.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly ClientContext _context;

        public ClientRepository(ClientContext context)
        {
            _context = context;
        }

        public async Task<Client> AddClient(Client client)
        {

            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task DeleteClient(Guid id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client != null)
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<PageResult<Client>> GetAllClient(int pageNumber, int pageSize)
        {
            var clients = await _context.Clients
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var totalRecords = await _context.Clients.CountAsync();

            return new PageResult<Client>
            {
                Items = clients,
                TotalRecords = totalRecords
            };
        }

        public async Task<Client?> GetClientById(Guid id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public async Task<Client> UpdateClient(Client client)
        {
            _context.Clients.Update(client);
            await _context.SaveChangesAsync();
            return client;
        }
    }
}
