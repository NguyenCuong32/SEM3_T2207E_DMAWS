using System.ComponentModel.DataAnnotations;

namespace WebMVC.Models
{
	public class Product
	{
		[Key]
        public int Id { get; set; }
		public string ProductName { get; set; } = string.Empty;
    }
}
