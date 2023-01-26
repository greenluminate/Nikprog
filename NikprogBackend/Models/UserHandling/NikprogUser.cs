using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace NikprogBackend.Models.UserHandling
{
    public enum LoginMode
    {
        microsoft, local //facebook, google,
    }
    public enum Sex
    {
        male, notSpecified, female
    }

    public class NikprogUser : IdentityUser
    {
        public DateTime? BirthDate { get; set; }

        // Email is inherited

        [StringLength(100)]
        public string? FirstName { get; set; }

        [StringLength(100)]
        public string? LastName { get; set; }

        [StringLength(100)]
        public string? Location { get; set; }

        [StringLength(100)]
        public LoginMode LoginMode { get; set; }

        [StringLength(100)]
        public Sex? Sex { get; set; }
    }
}