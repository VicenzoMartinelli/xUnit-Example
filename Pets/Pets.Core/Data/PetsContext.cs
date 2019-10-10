using Microsoft.EntityFrameworkCore;
using Pets.Core.Model;

namespace Pets.Core.Data
{
  public class PetsContext : DbContext
  {
    public DbSet<Pet> Pets { get; set; }

    public PetsContext(DbContextOptions<PetsContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      var petBuilder = modelBuilder.Entity<Pet>();

      petBuilder
        .HasKey(c => c.Id);
      petBuilder
        .Property(p => p.Descricao)
        .HasMaxLength(255)
        .IsRequired();
      petBuilder
        .Property(p => p.Nome)
        .HasMaxLength(100)
        .IsRequired();
      petBuilder
        .Property(p => p.DataEntrada)
        .IsRequired();
      petBuilder
        .Property(p => p.Raca)
        .IsRequired(false);
    }
  }
}
