using BTTH1.Data;
using Microsoft.AspNetCore.Mvc;

namespace BTTH1.Controllers
{
	[ViewComponent(Name = "Category")]
	public class CategoryViewComponent: ViewComponent
	{
		private readonly BTTH1Context _context;

		public CategoryViewComponent(BTTH1Context context)
		{
			_context = context;
		}

		public IViewComponentResult Invoke() {
		
			var _category = _context.CategoryModels.ToList();
			return View("Category", _category);
		}
	}
}
