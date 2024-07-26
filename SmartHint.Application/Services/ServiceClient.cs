using AutoMapper;
using SmartHint.Application.DTOs.ClientDTO;
using SmartHint.Application.Interfaces;
using SmartHint.Domain.Entities;
using SmartHint.Domain.Interfaces;


namespace SmartHint.Application.Services
{
    public class ServiceClient : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ServiceClient(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<ReadClientDTO> AddClientAsync(CreateClientDTO clientDTO)
        {
            var client = _mapper.Map<Client>(clientDTO);
            var addedClient = await _clientRepository.AddClient(client);
            return _mapper.Map<ReadClientDTO>(addedClient);
        }

        public async Task DeleteClientAsync(Guid id)
        {
            await _clientRepository.DeleteClient(id);
        }

        public async Task<List<ReadClientDTO>> GetAllClientsAsync()
        {
            var client = await _clientRepository.GetAllClient();
            return _mapper.Map<List<ReadClientDTO>>(client);
        }

        public async Task<ReadClientDTO> GetClientByIdAsync(Guid id)
        {
            var client = await _clientRepository.GetClientById(id);
            return _mapper.Map<ReadClientDTO>(client);
        }

        public async Task<ReadClientDTO> UpdateClientAsync(Guid id, UpdateClientDTO clientDTO)
        {
            var existingClient = await _clientRepository.GetClientById(id);

            if(existingClient == null)
            {
                throw new KeyNotFoundException($"Client with id {id}");
            }

            _mapper.Map(clientDTO, existingClient);
            var updateClient = await _clientRepository.UpdateClient(existingClient);
            return _mapper.Map<ReadClientDTO>(updateClient);
        }
    }
}
