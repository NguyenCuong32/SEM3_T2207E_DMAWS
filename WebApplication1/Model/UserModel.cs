using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model
{
    
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }

}
