namespace aqrs_catalog.CatalogAPI.DTOs
{
    public record ParticipantDTO
    {
        public Guid ParticipantId { get; set; }
        public string Name { get; set; }
    }
}
