using aqrs_catalog.CatalogAPI.DTOs;
using aqrs_catalog.CatalogAPI.Entities;
using aqrs_catalog.CatalogAPI.Interfaces;
using aqrs_catalog.CatalogAPI.Refit.Interface;
using aqrs_catalog.CatalogAPI.Refit.Interfaces;
using AutoMapper;

namespace aqrs_catalog.CatalogAPI.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly ICatalogRepository _repo;
        private readonly ICategoryRefitService _categoryRefit;
        private readonly IMediaRefitService _mediaRefit;
        private readonly IMediaTypeRefitService _mediaTypeRefit;
        private readonly IGenreRefitService _genreRefit;
        private readonly IParticipantRefitService _participantRefit;
        private readonly IRatingRefitService _ratingRefit;
        private readonly IMapper _mapper;

        public CatalogService(ICatalogRepository repo,
                ICategoryRefitService categoryRefit,
                IMediaRefitService mediaRefit,
                IMediaTypeRefitService mediaTypeRefit,
                IGenreRefitService genreRefit,
                IParticipantRefitService participantRefit,
                IRatingRefitService ratingRefit,
                IMapper mapper)
        {
            _repo = repo;
            _categoryRefit = categoryRefit;
            _mediaRefit = mediaRefit;
            _mediaTypeRefit = mediaTypeRefit;
            _genreRefit = genreRefit;
            _participantRefit = participantRefit;
            _ratingRefit = ratingRefit;
            _mapper = mapper;
        }



        public async Task<IEnumerable<CatalogDTO>> GetAllAsync()
        {
            var catalogs = await _repo.GetAllAsync();

            return _mapper.Map<IEnumerable<CatalogDTO>>(catalogs);
        }

        public async Task<CatalogDTO> GetByIdAsync(Guid id)
        {
            var catalog = await _repo.GetByIdAsync(id);

            return _mapper.Map<CatalogDTO>(catalog);
        }


        public async Task<CatalogDTO> CreateAsync(CatalogInsDTO catalogInsDTO)
        {
            var errors = await ValidateRequestModel(catalogInsDTO.MediaId, catalogInsDTO.MediaTypeId, catalogInsDTO.CategoryId, catalogInsDTO.GenreId, catalogInsDTO.RatingId, catalogInsDTO.Participants);

            if (errors != "")
                throw new Exception(errors);


            var catalog = _mapper.Map<Catalog>(catalogInsDTO);
            await _repo.CreateAsync(catalog);

            return _mapper.Map<CatalogDTO>(catalog);
        }


        public async Task<CatalogDTO> UpdateAsync(CatalogPutDTO catalogPutDTO)
        {
            await ValidataIdCatalog(catalogPutDTO.Id);


            var errors = await ValidateRequestModel(catalogPutDTO.MediaId, catalogPutDTO.MediaTypeId, catalogPutDTO.CategoryId, catalogPutDTO.GenreId, catalogPutDTO.RatingId, catalogPutDTO.Participants);

            if (errors != "")
                throw new Exception(errors);

            var catalog = _mapper.Map<Catalog>(catalogPutDTO);
            await _repo.UpdateAsync(catalog);

            return _mapper.Map<CatalogDTO>(catalog);
        }


        public async Task<CatalogDTO> DeleteAsync(Guid id)
        {
            var catalog = await ValidataIdCatalog(id);

            await _repo.DeleteAsync(catalog);

            return _mapper.Map<CatalogDTO>(catalog);
        }
    

        private async Task<Catalog> ValidataIdCatalog(Guid id)
        {
            var catalog = await _repo.GetByIdAsync(id);

            if (catalog is null)
                throw new Exception($"Invalid Catalog Id");

            return catalog;
        }

        private async Task<string> ValidateRequestModel(Guid MediaId, Guid MediaTypeId, Guid CategoryId, Guid GenreId, Guid RatingId, List<Guid> ParticipantIds)
        {
            string result = "";


            var mediaResult = await _mediaRefit.GetById(MediaId);

            if (mediaResult.Content == null)
                result += "Invalid Media\n";


            var mediaTypeResult = await _mediaTypeRefit.GetById(MediaTypeId);

            if (mediaTypeResult.Content == null)
                result += "Invalid Media Type\n";


            var categoryResult = await _categoryRefit.GetById(CategoryId);

            if (categoryResult.Content == null)
                result += $"Invalid Category\n";

            
            var genreResult = await _genreRefit.GetById( GenreId);

            if (genreResult.Content == null)
                result += $"Invalid Genre\n";


            var ratingResult = await _ratingRefit.GetById(RatingId);

            if (ratingResult.Content == null)
                result += $"Invalid Rating\n";

            int counter = 0;

            foreach (var participantID in ParticipantIds)
            {
                var participantResult = await _participantRefit.GetById(participantID);
                
                counter++;

                if (participantResult.Content == null)
                {                  
                    result += $"{counter}º Participant is invalid\n";
                }
            }

            return result;
        }
    }
}
