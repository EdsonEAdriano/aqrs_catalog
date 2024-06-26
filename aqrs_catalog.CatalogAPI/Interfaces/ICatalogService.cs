using aqrs_catalog.CatalogAPI.DTOs;
using aqrs_catalog.CatalogAPI.Entities;

namespace aqrs_catalog.CatalogAPI.Interfaces
{
    public interface ICatalogService
    {
        public Task<IEnumerable<CatalogDTO>> GetAllAsync();
        public Task<CatalogDTO> GetByIdAsync(Guid id);

        public Task<CatalogDTO> CreateAsync(CatalogInsDTO catalog);
        public Task<CatalogDTO> UpdateAsync(CatalogPutDTO catalog);
        public Task<CatalogDTO> DeleteAsync(Guid id);
    }
}
