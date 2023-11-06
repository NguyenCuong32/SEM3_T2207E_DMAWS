using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class StudentModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
