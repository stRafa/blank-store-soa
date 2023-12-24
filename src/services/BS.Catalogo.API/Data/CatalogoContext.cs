using BS.Catalogo.API.Models;
using BS.Core.Data;
using BS.Core.Messages;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace BS.Catalogo.API.Data
{
    public class CatalogoContext(DbContextOptions<CatalogoContext> options) : DbContext(options), IUnitOfWork
    {
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Event>();
            modelBuilder.Ignore<ValidationResult>();

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogoContext).Assembly);
        }

        public async Task<bool> Commit() => await base.SaveChangesAsync() > 0;
    }
}
