using Microsoft.AspNetCore.Identity;

namespace BTTH1.Areas.login
{
	public class AppUser : IdentityUser
	{
		//add your custom properties which have not included in IdentityUser before
		public string MyExtraProperty { get; set; }
	}
}
