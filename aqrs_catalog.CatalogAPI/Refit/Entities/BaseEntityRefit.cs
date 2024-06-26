namespace aqrs_catalog.CatalogAPI.Entities
{
    public abstract class BaseEntityRefit
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? InactivatedDate { get; set; }
    }
}
