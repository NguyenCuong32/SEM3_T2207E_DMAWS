using BTTH1.Data;
using Microsoft.AspNetCore.Mvc;

namespace BTTH1.Controllers
{
	[ViewComponent(Name = "Categoryside")]
	public class Categorysideviewcomponent : ViewComponent
	{
		private readonly BTTH1Context _context;
		public Categorysideviewcomponent(BTTH1Context context)
		{
			_context = context;
		}

		public IViewComponentResult Invoke()
		{

			var _category = _context.CategoryModels.ToList();
			return View("_Categoryside", _category);
		}
	}
}
