using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NikprogServerClient.Models.CourseMaterials
{
    [Table("course")]
    public class Course
    {
        [Key]
        [Column("id")]
        public string Id { get; set; }
        [MaxLength(100)]
        [Column("name")]
        public string? Name { get; set; }
        [Column("difficulty")]
        public DifficultyEnum? Difficulty { get; set; }
        [MaxLength(1500)]
        [Column("description")]
        public string? Description { get; set; }

        [MaxLength(200)]
        [Column("photo_url")]
        public string PhotoUrl { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Module> Modules { get; set; }
        [Required]
        [Column("is_hidden")]
        public bool IsHidden { get; set; }

        public Course()
        {
            Id = Guid.NewGuid().ToString();
            Modules = new HashSet<Module>();
            IsHidden = false;
        }

        // "Client does not want to strore who created it,
        // but it wouldbe nicer due to authorization.
        // Ex.: Delete only your own course"
        //[Required]
        //[ForeignKey(nameof(NikprogUser))]
        //public string UserId { get; set; }
    }
}
