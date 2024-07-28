using SmartHint.Application.DTOs.ClientDTO;
using SmartHint.Domain.Entities;


namespace SmartHint.Application.Interfaces
{
    public interface IClientService
    {
        Task<ReadClientDTO> AddClientAsync(CreateClientDTO client);
        Task<ReadClientDTO> GetClientByIdAsync(Guid id);
        Task<PageResult<ReadClientDTO>> GetAllClientsAsync(int pageNumber, int pageSize);
        Task<ReadClientDTO> UpdateClientAsync(Guid id, UpdateClientDTO client);
        Task DeleteClientAsync(Guid id);
    }
}
