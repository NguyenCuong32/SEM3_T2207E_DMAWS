using System.ComponentModel.DataAnnotations;

namespace MVC_Azure02.Models
{
    public class Student
    {
        [Key]
        public int IdStudent { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }


    }
}
