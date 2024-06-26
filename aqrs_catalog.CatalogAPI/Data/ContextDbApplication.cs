using aqrs_catalog.CatalogAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace aqrs_catalog.CatalogAPI.Data
{
    public class ContextDbApplication : DbContext
    {
        public ContextDbApplication(DbContextOptions<ContextDbApplication> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Catalog>()
                .Property(e => e.Status)
                .HasConversion<string>();

            modelBuilder.Entity<Catalog>().HasData(
                new Catalog
                {
                    Id = new Guid("fdda6ab1-eed4-4856-9e55-b9e96eb2f163"),
                    MediaId = new Guid("c427b2e1-deeb-45cd-9b84-1d66f90bcb75"),
                    Description = "Descrição do catalogo 1",
                    MediaURL = "https://localhost:7001/api/Catalog/fdda6ab1-eed4-4856-9e55-b9e96eb2f163",
                    Price = 98.58,
                    MediaTypeId = new Guid("ce6875b7-efcb-4da3-bd0e-7813fbd1c479"),
                    CategoryId = new Guid("c313fa89-0025-4d9d-bbd9-d83b29ad72df"),
                    GenreId = new Guid("db1d5df5-8176-4032-be18-9b3329dc16e9"),
                    RatingId = new Guid("fb923c80-e9f7-4098-b8d6-5ebc2dd32315"),
                    Status = Enums.EStatus.ACTIVE,
                    CreatedDate = DateTime.Now,
                    InactivatedDate = null
                }
            );

            modelBuilder.Entity<CatalogParticipant>().HasData(
                new CatalogParticipant { Id = Guid.NewGuid(), CatalogId = new Guid("fdda6ab1-eed4-4856-9e55-b9e96eb2f163"), ParticipantId = new Guid("c0d8deac-b6b9-489b-b6e3-afab399ed3a5") },
                new CatalogParticipant { Id = Guid.NewGuid(), CatalogId = new Guid("fdda6ab1-eed4-4856-9e55-b9e96eb2f163"), ParticipantId = new Guid("537f6d12-6d9e-4a82-ae1e-ce734eea6c70") }
            );
        }

        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<CatalogParticipant> CatalogParticipants { get; set; }
    }
}