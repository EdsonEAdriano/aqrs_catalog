using aqrs_catalog.CatalogAPI.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aqrs_catalog.CatalogAPI.Entities
{
    [Table("t_catalog")]
    public class Catalog
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Column("media_id")]
        public Guid MediaId { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("media_url")]
        public string MediaURL{ get; set; }
        [Column("price")]
        public double Price { get; set; }
        [Column("media_type_id")]
        public Guid MediaTypeId { get; set; }
        [Column("category_id")]
        public Guid CategoryId { get; set; }
        [Column("genre_id")]
        public Guid GenreId { get; set; }
        [Column("rating_id")]
        public Guid RatingId { get; set; }
        public List<CatalogParticipant> Participants { get; set; } = new List<CatalogParticipant>();

        [Column("status")]
        public EStatus Status { get; set; }
        [Column("created_date")]
        public DateTime CreatedDate { get; set; }
        [Column("inactivated_date")]
        public DateTime? InactivatedDate { get; set; }
    }
}
