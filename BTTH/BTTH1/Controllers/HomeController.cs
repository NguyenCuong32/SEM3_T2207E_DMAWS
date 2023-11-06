using BTTH1.Data;
using BTTH1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
//using System.Web.Mvc;

namespace BTTH1.Controllers
{
	public class HomeController : Controller
	{
		//private readonly ILogger<HomeController> _logger;
		private readonly BTTH1Context _context;

		public HomeController(BTTH1Context context)
		{
			_context = context;
		}

		//[ChildActionOnly]
		//public IActionResult RenderMenu()
		//{
			//return PartialView("_Menubar");
		//}
		public  IActionResult Index()
		{
			var _product = _context.ProductModels.Include(p => p.Brand).Include(p => p.Category);

			return View(_product.ToList());
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}