namespace aqrs_catalog.CatalogAPI.DTOs
{
    public record CatalogInsDTO
    {
        public Guid MediaId { get; set; }
        public string Description { get; set; }
        public string MediaURL { get; set; }
        public double Price { get; set; }
        public Guid MediaTypeId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid GenreId { get; set; }
        public Guid RatingId { get; set; }
        public List<Guid> Participants { get; set; }
    }
}
