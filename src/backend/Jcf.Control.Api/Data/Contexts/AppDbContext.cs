using Jcf.Control.Api.Applications.ClientApp.Entities;
using Jcf.Control.Api.Applications.UserApp.Entities;
using Jcf.Control.Api.Core.Entities;
using Jcf.Control.Api.Core.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Jcf.Control.Api.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
