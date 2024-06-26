using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aqrs_catalog.CatalogAPI.Entities
{
    [Table("t_catalog_participant")]
    public class CatalogParticipant
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Column("catalog_id")]
        public Guid CatalogId { get; set; }
        [Column("participant_id")]
        public Guid ParticipantId { get; set; }
    }
}
