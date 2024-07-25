using SmartHint.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHint.Domain.Interfaces
{
    public interface IClientRepository
    {
        Task<Client> AddClient(Client client);
        Task<Client> GetClientById(Guid id);
        Task<Client> GetAllClient();
        Task DeleteClient(Guid id);
        Task<Client> UpdateClient(Client client);
    }
}
