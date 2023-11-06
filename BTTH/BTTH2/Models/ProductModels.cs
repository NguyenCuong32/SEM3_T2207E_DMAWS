using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTTH2.Models
{
	public class ProductModels
	{
		[Key] public int ProductId { get; set; }
		[Required] public string ProductName { get; set; }
		[Required] public string ProductDescription { get; set;}
		[Required] public decimal ProductPrice { get; set;}
		[Required] public int ProductQuantity { get; set; }
		[Required] public string ProductImg { get; set; }

		[Required, Range(1, int.MaxValue, ErrorMessage = "Required to choose Category.")]
		//Giá trị chọn từ 1 đến giá trị tối đa của kiểu dữ liệu int
		 
		public int CateId { get; set; }

		[ForeignKey("CateId")]  //Chỉ định khoá ngoại
		[Display(Name = "Category type")] //Xác định tên hiển thị trên Web(html)
		public virtual CategoryModels Category { get; set; }

		[Required, Range(1, int.MaxValue, ErrorMessage = "Required to choose Category.")]
		//Giá trị chọn từ 1 đến giá trị tối đa của kiểu dữ liệu int

		public int BrandId { get; set; }

		[ForeignKey("BrandId")]  //Chỉ định khoá ngoại
		[Display(Name = "Brand type")] //Xác định tên hiển thị trên Web(html)
		public virtual BrandModels Brand { get; set; }

	}
}
