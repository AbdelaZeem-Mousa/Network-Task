using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Network.API.Model
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(250)")]
        public string Name { get; set; } = "";
        public string ContactNumber { get; set; }
        public int Age { get; set; }
    }
}
