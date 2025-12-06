using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webApi.Models
{
    public class ItemLocation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Item")]
        public int ItemId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Longitude { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Latitude { get; set; } = string.Empty;

        public virtual Item? Item { get; set; }
    }
}
