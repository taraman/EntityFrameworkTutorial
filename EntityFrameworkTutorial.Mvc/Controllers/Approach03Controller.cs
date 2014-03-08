using System.Linq;
using System.Web.Mvc;
using EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach03;
using EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach03.Services;

namespace EntityFrameworkTutorial.Mvc.Controllers
{
	public class Approach03Controller : Controller
	{
		ICatalogService service;

		
		public Approach03Controller(ICatalogService srv)
		{
			service = srv;
		}


		public Approach03Controller() : this(new CatalogService(new UnitOfWork()))
        {

        }
		

		public JsonResult Index()
		{
			var products = service.GetProducts();

			var data = products.Select(x => new
				{
					x.ProductId,
					x.ProductName,
					Category = new
						{
							x.Category.CategoryId,
							x.Category.CategoryName
						}

				}).ToList();

			return Json(data, JsonRequestBehavior.AllowGet);
		}


	}
}
