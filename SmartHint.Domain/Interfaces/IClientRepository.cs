﻿using SmartHint.Domain.Entities;


namespace SmartHint.Domain.Interfaces
{
    public interface IClientRepository
    {
        Task<Client> AddClient(Client client);
        Task<Client> GetClientById(Guid id);
        Task<PageResult<Client>> GetAllClient(int pageNumber, int pageSize);
        Task DeleteClient(Guid id);
        Task<Client> UpdateClient(Client client);

        Task<Client> GetEmail(string email);

        Task<Client> GetCpfCnpj(string cpfCnpj);

        Task<Client> GetInscricaoEstadual(string inscricaoEstadual);
    }
}
