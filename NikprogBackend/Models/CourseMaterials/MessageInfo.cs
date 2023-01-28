using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
