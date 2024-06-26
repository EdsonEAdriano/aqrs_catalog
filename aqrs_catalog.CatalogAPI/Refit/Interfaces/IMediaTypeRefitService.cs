using aqrs_catalog.CatalogAPI.Entities;
using Refit;

namespace aqrs_catalog.CatalogAPI.Refit.Interfaces
{
    public interface IMediaTypeRefitService
    {
        [Get("/api/MediaType/{id}")]
        Task<ApiResponse<MediaTypeRefit>> GetById(Guid id);
    }
}
