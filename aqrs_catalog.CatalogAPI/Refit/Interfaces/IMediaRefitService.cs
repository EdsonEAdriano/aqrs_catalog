using aqrs_catalog.CatalogAPI.Entities;
using Refit;

namespace aqrs_catalog.CatalogAPI.Refit.Interfaces
{
    public interface IMediaRefitService
    {
        [Get("/api/Media/{id}")]
        Task<ApiResponse<MediaRefit>> GetById(Guid id);
    }
}
