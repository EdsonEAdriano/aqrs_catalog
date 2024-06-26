using aqrs_catalog.CatalogAPI.Data;
using aqrs_catalog.CatalogAPI.Entities;
using aqrs_catalog.CatalogAPI.Enums;
using aqrs_catalog.CatalogAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace aqrs_catalog.CatalogAPI.Repositories
{
    public class CatalogRepository : ICatalogRepository
    {
        private readonly ContextDbApplication _context;

        public CatalogRepository(ContextDbApplication context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Catalog>> GetAllAsync()
        {
            return await _context
                        .Set<Catalog>()
                        .Where(c => c.Status == EStatus.ACTIVE)
                        .Include(c => c.Participants)
                        .ToListAsync();
        }

        public async Task<Catalog> GetByIdAsync(Guid id)
        {
            return await _context
                        .Set<Catalog>()
                        .Where(c => c.Id == id && c.Status == EStatus.ACTIVE)
                        .Include(c => c.Participants)
                        .AsNoTracking()
                        .SingleOrDefaultAsync();
        }

        public async Task<Catalog> CreateAsync(Catalog catalog)
        {
            _context
                .Set<Catalog>()
                .Add(catalog);

            await _context
                    .SaveChangesAsync();

            return catalog;
        }

        public async Task<Catalog> DeleteAsync(Catalog catalog)
        {
            catalog.InactivatedDate = DateTime.Now;
            catalog.Status = EStatus.INACTIVE;

            _context
                .Entry(catalog)
                .Property(e => e.InactivatedDate).IsModified = true;

            _context
                .Entry(catalog)
                .Property(e => e.Status).IsModified = true;

            await _context
                    .SaveChangesAsync();

            return catalog;
        }

        public async Task<Catalog> UpdateAsync(Catalog catalog)
        {
            var catalogParticipants = await _context
                .Set<CatalogParticipant>()
                .Where(e => e.CatalogId == catalog.Id)
                .ToListAsync();

            _context
                .Set<CatalogParticipant>()
                .RemoveRange(catalogParticipants);

            _context
                 .Set<Catalog>()
                 .Update(catalog);

            await _context
                    .SaveChangesAsync();

            return catalog;
        }
    }
}
