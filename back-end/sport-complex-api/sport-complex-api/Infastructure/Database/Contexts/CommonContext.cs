using Microsoft.EntityFrameworkCore;
using sport_complex_api.Features.Atlets.Models;
using sport_complex_api.Features.Competitons.Models;
using sport_complex_api.Features.Places.Models;


namespace sport_complex_api.Infastructure.Database.Contexts
{
    public class CommonContext : DbContext
    {
        public CommonContext(DbContextOptions<CommonContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<AtletDto> Atlets { get; set; }

        public DbSet<CompetitonDto> Competitons { get; set; }

        public DbSet<PlaceDto> Places { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AtletDto>()
                .ToTable("Atlets")
                .HasKey(k => k.AtletDtoId);
            modelBuilder.Entity<CompetitonDto>().ToTable("Competitons");
            modelBuilder.Entity<PlaceDto>()
                .ToTable("Places")
                .HasKey(k => k.PlaceDtoId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
