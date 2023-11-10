using System.ComponentModel.DataAnnotations;

namespace Azure_MVC.Models
{
    public class BookModel
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string CustName { get; set; }
        [MaxLength(100)]
        public string CustAdress { get; set; }
    }
}
