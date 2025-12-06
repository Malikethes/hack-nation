using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webApi.Models
{
    [Table("Items")]
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(500)]
        public string? Data { get; set; }

        [Required]
        public int Int { get; set; }

        [Required]
        public float Float { get; set; }

        [MaxLength(255)]
        public string? Mieszane { get; set; }

        [MaxLength(100)]
        public string? Czas { get; set; }

        [MaxLength(100)]
        public string? Dataczas { get; set; }

        [MaxLength(50)]
        public string? Pusta { get; set; }

        [MaxLength(255)]
        public string? Mieszane2 { get; set; }

        [Required]
        public bool Boolean { get; set; }

        public int? DuzoMissingowInt { get; set; }
    }
}
