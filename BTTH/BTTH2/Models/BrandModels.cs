using System.ComponentModel.DataAnnotations;
namespace BTTH2.Models
{
	public class BrandModels
	{
		[Key] public int BrandId { get; set; }
		[Required] public string BrandName { get; set; }
		[Required]
		public string BrandDesc { get; set; }

		[Required]
		public int BrandOrder { get; set; }

		public virtual ICollection<ProductModels> Brand { get; set; } = new List<ProductModels>();
	}
}
