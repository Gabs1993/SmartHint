using AutoMapper;
using SmartHint.Application.DTOs.ClientDTO;
using SmartHint.Application.Exceptions;
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
            if (clientDTO.Senha != clientDTO.ConfirmarSenha)
            {
                throw new CustomValidationException("A senha e a confirmação de senha precisam ser iguais.");
            }

            var existingEmail = await _clientRepository.GetEmail(clientDTO.Email);
            if (existingEmail != null)
            {
                throw new CustomValidationException("O e-mail já está em uso.");
            }

            var existingCpfCnpj = await _clientRepository.GetCpfCnpj(clientDTO.CpfCnpj);
            if (existingCpfCnpj != null)
            {
                throw new CustomValidationException("O CPF/CNPJ já está em uso.");
            }

            var existingInscricaoEstadual = await _clientRepository.GetInscricaoEstadual(clientDTO.InscricaoEstadual);
            if (existingInscricaoEstadual != null)
            {
                throw new CustomValidationException("A Inscrição Estadual já está em uso.");
            }

            var client = _mapper.Map<Client>(clientDTO);
            var addedClient = await _clientRepository.AddClient(client);
            return _mapper.Map<ReadClientDTO>(addedClient);
        }

        public async Task DeleteClientAsync(Guid id)
        {
            await _clientRepository.DeleteClient(id);
        }

        public async Task<PageResult<ReadClientDTO>> GetAllClientsAsync(int pageNumber, int pageSize)
        {
            var clientPageResult = await _clientRepository.GetAllClient(pageNumber, pageSize);
            return _mapper.Map<PageResult<ReadClientDTO>>(clientPageResult);
        }

        public async Task<ReadClientDTO> GetClientByIdAsync(Guid id)
        {
            var client = await _clientRepository.GetClientById(id);
            return _mapper.Map<ReadClientDTO>(client);
        }

        public async Task<ReadClientDTO> GetCpfCnpjAsync(string cpfCnpj)
        {
            var info = await _clientRepository.GetCpfCnpj(cpfCnpj);
            return _mapper.Map<ReadClientDTO>(info);
        }

        public async Task<ReadClientDTO> GetEmailAsync(string email)
        {
            var info = await _clientRepository.GetEmail(email);
            return _mapper.Map<ReadClientDTO>(info);
        }

        public async Task<ReadClientDTO> GetInscricaoEstadualAsync(string inscricaoEstadual)
        {
            var info = await _clientRepository.GetInscricaoEstadual(inscricaoEstadual);
            return _mapper.Map<ReadClientDTO>(info);
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
