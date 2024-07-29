
using AutoMapper;
using Moq;
using SmartHint.Application.DTOs.ClientDTO;
using SmartHint.Application.Services;
using SmartHint.Domain.Entities;
using SmartHint.Domain.Interfaces;

namespace SmartHint.Tests.Tests
{
    public class ServiceClientTests
    {
        private readonly Mock<IClientRepository> _clientRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ServiceClient _serviceClient;

        public ServiceClientTests()
        {
            _clientRepositoryMock = new Mock<IClientRepository>();
            _mapperMock = new Mock<IMapper>();
            _serviceClient = new ServiceClient(_clientRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task TestAddClientAsync()
        {
            // Arrange
            var createClientDTO = new CreateClientDTO
            {
                NomeRazaoSocial = "teste",
                Telefone = "teste",
                TipoPessoa = "teste",
                Genero = "teste",
                DateNascimento = DateTime.Now,
                Email = "test@example.com",
                CpfCnpj = "12345678901",
                InscricaoEstadual = "123456",
                Senha = "password",
                ConfirmarSenha = "password"
            };

            var client = new Client();
            var readClientDTO = new ReadClientDTO();

            _clientRepositoryMock.Setup(repo => repo.GetEmail(It.IsAny<string>())).ReturnsAsync((Client)null);
            _clientRepositoryMock.Setup(repo => repo.GetCpfCnpj(It.IsAny<string>())).ReturnsAsync((Client)null);
            _clientRepositoryMock.Setup(repo => repo.GetInscricaoEstadual(It.IsAny<string>())).ReturnsAsync((Client)null);
            _mapperMock.Setup(mapper => mapper.Map<Client>(It.IsAny<CreateClientDTO>())).Returns(client);
            _clientRepositoryMock.Setup(repo => repo.AddClient(It.IsAny<Client>())).ReturnsAsync(client);
            _mapperMock.Setup(mapper => mapper.Map<ReadClientDTO>(It.IsAny<Client>())).Returns(readClientDTO);

            // Act
            var result = await _serviceClient.AddClientAsync(createClientDTO);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(readClientDTO, result);
            _clientRepositoryMock.Verify(repo => repo.GetEmail(createClientDTO.Email), Times.Once);
            _clientRepositoryMock.Verify(repo => repo.GetCpfCnpj(createClientDTO.CpfCnpj), Times.Once);
            _clientRepositoryMock.Verify(repo => repo.GetInscricaoEstadual(createClientDTO.InscricaoEstadual), Times.Once);
            _clientRepositoryMock.Verify(repo => repo.AddClient(client), Times.Once);
            _mapperMock.Verify(mapper => mapper.Map<Client>(createClientDTO), Times.Once);
            _mapperMock.Verify(mapper => mapper.Map<ReadClientDTO>(client), Times.Once);
        }

        [Fact]
        public async Task TestGetClientByIdAsync()
        {
            // Arrange
            var clientId = Guid.NewGuid();
            var client = new Client();
            var readClientDTO = new ReadClientDTO();

            _clientRepositoryMock.Setup(repo => repo.GetClientById(clientId)).ReturnsAsync(client);
            _mapperMock.Setup(mapper => mapper.Map<ReadClientDTO>(client)).Returns(readClientDTO);

            // Act
            var result = await _serviceClient.GetClientByIdAsync(clientId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(readClientDTO, result);
            _clientRepositoryMock.Verify(repo => repo.GetClientById(clientId), Times.Once);
            _mapperMock.Verify(mapper => mapper.Map<ReadClientDTO>(client), Times.Once);
        }

        [Fact]
        public async Task TestGetCpfCnpjAsync()
        {
            // Arrange
            var cpfCnpj = "12345678901";
            var client = new Client();
            var readClientDTO = new ReadClientDTO();

            _clientRepositoryMock.Setup(repo => repo.GetCpfCnpj(cpfCnpj)).ReturnsAsync(client);
            _mapperMock.Setup(mapper => mapper.Map<ReadClientDTO>(client)).Returns(readClientDTO);

            // Act
            var result = await _serviceClient.GetCpfCnpjAsync(cpfCnpj);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(readClientDTO, result);
            _clientRepositoryMock.Verify(repo => repo.GetCpfCnpj(cpfCnpj), Times.Once);
            _mapperMock.Verify(mapper => mapper.Map<ReadClientDTO>(client), Times.Once);
        }

        [Fact]
        public async Task TestGetEmailAsync()
        {
            // Arrange
            var email = "test@example.com";
            var client = new Client();
            var readClientDTO = new ReadClientDTO();

            _clientRepositoryMock.Setup(repo => repo.GetEmail(email)).ReturnsAsync(client);
            _mapperMock.Setup(mapper => mapper.Map<ReadClientDTO>(client)).Returns(readClientDTO);

            // Act
            var result = await _serviceClient.GetEmailAsync(email);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(readClientDTO, result);
            _clientRepositoryMock.Verify(repo => repo.GetEmail(email), Times.Once);
            _mapperMock.Verify(mapper => mapper.Map<ReadClientDTO>(client), Times.Once);
        }

        [Fact]
        public async Task TestGetInscricaoEstadualAsync()
        {
            // Arrange
            var inscricaoEstadual = "123456";
            var client = new Client();
            var readClientDTO = new ReadClientDTO();

            _clientRepositoryMock.Setup(repo => repo.GetInscricaoEstadual(inscricaoEstadual)).ReturnsAsync(client);
            _mapperMock.Setup(mapper => mapper.Map<ReadClientDTO>(client)).Returns(readClientDTO);

            // Act
            var result = await _serviceClient.GetInscricaoEstadualAsync(inscricaoEstadual);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(readClientDTO, result);
            _clientRepositoryMock.Verify(repo => repo.GetInscricaoEstadual(inscricaoEstadual), Times.Once);
            _mapperMock.Verify(mapper => mapper.Map<ReadClientDTO>(client), Times.Once);
        }
    }
}
