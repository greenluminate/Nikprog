using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NikprogServerClient.Models.CourseMaterials
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
        // Sequence in the course
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SequenceNum { get; set; }
        [MaxLength(100)]
        [Column("name")]
        public string? Name { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Course Course { get; set; }

        [Required]
        [ForeignKey(nameof(Course))]
        public string CourseId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<MaterialInfo> MaterialInfos { get; set; }

        public Module()
        {
            Id = Guid.NewGuid().ToString();
            SequenceNum = 0;
            MaterialInfos = new HashSet<MaterialInfo>();
        }
    }
}
