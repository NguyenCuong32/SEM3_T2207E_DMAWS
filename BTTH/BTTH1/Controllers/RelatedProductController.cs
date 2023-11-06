using BTTH1.Data;
using Microsoft.AspNetCore.Mvc;

namespace BTTH1.Controllers
{
	[ViewComponent(Name = "RelatedProduct")]
	public class RelatedProductController : ViewComponent
	{
 
			private readonly BTTH1Context _context;

			public RelatedProductController(BTTH1Context context)
			{
				_context = context;
			}

			public IViewComponentResult Invoke()
			{

				var _Product = _context.ProductModels.ToList();
				return View("RelatedProduct", _Product);
			}
		
	}


}
