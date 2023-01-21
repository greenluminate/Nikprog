using System.ComponentModel.DataAnnotations;

namespace NikprogBackend.Models.UserHandling
{
    public class LocalUserRegister
    {
        public DateTime? BirthDate { get; set; }

        [StringLength(100)]
        public string? Email { get; set; }

        [StringLength(100)]
        public string? FirstName { get; set; }

        [StringLength(100)]
        public string? LastName { get; set; }

        [StringLength(100)]
        public string? Location { get; set; }

        [StringLength(100)]
        public string? Password { get; set; }

        public Sex? Sex { get; set; }

    }
}
