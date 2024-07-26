using SmartHint.Application.DTOs.ClientDTO;


namespace SmartHint.Application.Interfaces
{
    public interface IClientService
    {
        Task<ReadClientDTO> AddClientAsync(CreateClientDTO client);
        Task<ReadClientDTO> GetClientByIdAsync(Guid id);
        Task<List<ReadClientDTO>> GetAllClientsAsync();
        Task<ReadClientDTO> UpdateClientAsync(Guid id, UpdateClientDTO client);
        Task DeleteClientAsync(Guid id);
    }
}
