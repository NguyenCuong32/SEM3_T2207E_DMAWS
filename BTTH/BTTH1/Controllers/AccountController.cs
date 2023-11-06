using Microsoft.AspNetCore.Mvc;

namespace BTTH1.Controllers
{
	public class AccountController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Login()
		{
			return View();
		}
	}
}
