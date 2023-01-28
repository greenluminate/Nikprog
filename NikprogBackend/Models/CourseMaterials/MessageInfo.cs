using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NikprogServerClient.Models.CourseMaterials
{
    public class MessageInfo : MaterialInfo
    {
        [MaxLength(3000)]
        [Column("message")]
        public string Message { get; set; }

        public MessageInfo()
        {
            Message = "";
        }
    }
}
