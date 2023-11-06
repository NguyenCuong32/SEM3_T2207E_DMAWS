using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
	public class Product
	{
		[Key]
		public int Id { get; set; }
		public string ProductName { get; set; } = string.Empty;
    }
}
