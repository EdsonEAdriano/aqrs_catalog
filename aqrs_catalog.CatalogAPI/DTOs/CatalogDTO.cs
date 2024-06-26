using System.ComponentModel.DataAnnotations.Schema;

namespace aqrs_catalog.CatalogAPI.DTOs
{
    public record CatalogDTO
    {
        public Guid Id { get; set; }
        public Guid MediaId { get; set; }
        public string MediaName { get; set; }
        public string Description { get; set; }
        public string MediaURL { get; set; }
        public double Price { get; set; }
        public string PriceInWords { get; set; } 
        public Guid MediaTypeId { get; set; }
        public string Type {  get; set; }
        public Guid CategoryId { get; set; }
        public string Category { get; set; }
        public Guid GenreId { get; set; }
        public string Genre {  get; set; }
        public Guid RatingId { get; set; }
        public string Rating { get; set; } 
        public List<ParticipantDTO> Participants { get; set; }
    }
}
