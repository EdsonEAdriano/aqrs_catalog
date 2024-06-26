using aqrs_catalog.CatalogAPI.Entities;
using Refit;

namespace aqrs_catalog.CatalogAPI.Refit.Interfaces
{
    public interface IRatingRefitService
    {
        [Get("/api/Rating/{id}")]
        Task<ApiResponse<RatingRefit>> GetById(Guid id);
    }
}
