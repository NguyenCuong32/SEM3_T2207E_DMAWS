using System.ComponentModel.DataAnnotations;
namespace BTTH1.Models
{
	public class CategoryModels
	{
		[Key]
		public int CateId { get; set; }
		[Required]
		public string CateName { get; set; }
		[Required]
		public string CateDesc { get; set; }

		[Required]
		public int CateOrder { get; set; }

		public virtual ICollection<ProductModels> Category { get; set; } = new List<ProductModels>();

	}
}
