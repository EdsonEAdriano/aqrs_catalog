using aqrs_catalog.CatalogAPI.Entities;
using Refit;

namespace aqrs_catalog.CatalogAPI.Refit.Interface
{
    public interface ICategoryRefitService
    {
        [Get("/api/Category/{id}")]
        Task<ApiResponse<CategoryRefit>> GetById(Guid id);
    }
}
