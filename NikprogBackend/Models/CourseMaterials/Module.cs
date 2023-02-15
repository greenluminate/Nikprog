using Microsoft.EntityFrameworkCore;
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
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Index(IsUnique = true)]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //public int SequenceNum { get { return SequenceNum; } set { _ = SequenceNum > 0 ? value : Course?.Modules.Count; } }
        public int SequenceNum { get; set; }

        [MaxLength(100)]
        [Column("name")]
        public string? Name { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Course? Course { get; set; }

        [Required]
        [ForeignKey(nameof(Course))]
        public string CourseId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<MaterialInfo> MaterialInfos { get; set; }

        public Module()
        {
            Id = Guid.NewGuid().ToString();
            MaterialInfos = new HashSet<MaterialInfo>();
        }
    }
}
