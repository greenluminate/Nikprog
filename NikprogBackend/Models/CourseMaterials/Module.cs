using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using NikprogBackend.Models.CourseMaterials;

namespace NikprogBackend.Models
{
    [Table("module")]
    public class Module
    {
        [Key]
        [Column("id")]
        public string Id { get; set; }

        [Required]
        [Range(0, 100)]
        [Column("sequence_num")]
        public int SequenceNum { get; set; }
        [MaxLength(100)]
        [Column("name")]
        public string? Name { get; set; }

        [Required]
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<MaterialInfo> MaterialInfo { get; set; }

        public Module()
        {
            Id = Guid.NewGuid().ToString();
            SequenceNum = 0;
            MaterialInfo = new HashSet<MaterialInfo>();
        }
    }
}
