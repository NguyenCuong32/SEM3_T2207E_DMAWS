using Microsoft.AspNetCore.Mvc;

namespace BTTH1.Controllers
{
	public class CartController : Controller
	{
		public IActionResult Addtocart(int productid)
		{
			return View("Cart");
		}
	}
}
