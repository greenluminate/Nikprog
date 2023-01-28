using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NikprogServerClient.Models.CourseMaterials
{
    [Table("material_info")]
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

        [NotMapped]
        [JsonIgnore]
        public virtual Module Module { get; set; }

        [Required]
        [ForeignKey(nameof(Module))]
        public string ModuleId { get; set; }

        public MaterialInfo()
        {
            Id = Guid.NewGuid().ToString();
            Url = "";
            Title = "";
        }
    }
}
