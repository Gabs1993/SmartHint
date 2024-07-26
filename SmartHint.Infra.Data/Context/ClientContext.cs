using Microsoft.EntityFrameworkCore;
using SmartHint.Domain.Entities;


namespace SmartHint.Infra.Data.Context
{
    public class ClientContext : DbContext
    {
        public ClientContext(DbContextOptions<ClientContext> options) : base(options) { }
        
        public DbSet<Client> Clients { get; set; }
    }
}
