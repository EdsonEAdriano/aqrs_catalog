using aqrs_catalog.CatalogAPI.Entities;
using Refit;

namespace aqrs_catalog.CatalogAPI.Refit.Interfaces
{
    public interface IParticipantRefitService
    {
        [Get("/api/Participant/{id}")]
        Task<ApiResponse<ParticipantRefit>> GetById(Guid id);
    }
}
