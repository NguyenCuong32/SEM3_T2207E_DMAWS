using System.ComponentModel.DataAnnotations;

namespace BTTH2.Models
{
	public class User
	{
		[Key]
		public int UserId { get; set; }
		[Required, MinLength(3, ErrorMessage = "Required to enter Username (minlength = 3).")]
		[Display(Name = "User Name")]
		public string UserName { get; set; }
		[Required]

		public string UserEmail { get; set; }

		[Required, MinLength(3, ErrorMessage = "Required to enter Password (minlength = 3).")]
		[Display(Name = "Password")]
		public string UserPassword { get; set; }
		[Required]

		public string UserRole { get; set; }
	}
}
