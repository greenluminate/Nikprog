using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NikprogBackend.Models.CourseMaterials
{
    public class MaterialInfo
    {
        [Key]
        [Column("id")]
        public string Id { get; set; }

        [MaxLength(100)]
        [Column("title")]
        public string Title { get; set; }

        [Required]
        [Range(0, 100)]
        [Column("sequence_num")]
        // Sequence in the module
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SequenceNum { get; set; }

        [Required]
        [MaxLength(200)]
        [Column("url")]
        public string Url { get; set; }

        [ForeignKey(nameof(Module))]
        public int ModuleId { get; set; }

        public MaterialInfo()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
