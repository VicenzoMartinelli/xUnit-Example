using Microsoft.EntityFrameworkCore;
using Pets.Core.Model;

namespace Pets.Core.Data
{
  public class PetsContext : DbContext
  {
    public DbSet<Pet> Pets { get; set; }
    public DbSet<BanhoPet> Banhos { get; set; }

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

      var banhoPetBuilder = modelBuilder.Entity<BanhoPet>();

      banhoPetBuilder
        .HasKey(c => c.Id);
      banhoPetBuilder.Property(x => x.Data).IsRequired();
      banhoPetBuilder.Property(x => x.Valor).IsRequired();
      banhoPetBuilder.HasOne(x => x.Pet).WithMany(x => x.Banhos).HasForeignKey(x => x.PetId);
    }
  }
}
