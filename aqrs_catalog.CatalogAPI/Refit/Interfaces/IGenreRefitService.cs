using aqrs_catalog.CatalogAPI.Entities;
using Refit;

namespace aqrs_catalog.CatalogAPI.Refit.Interfaces
{
    public interface IGenreRefitService
    {
        [Get("/api/Genre/{id}")]
        Task<ApiResponse<GenreRefit>> GetById(Guid id);
    }
}
