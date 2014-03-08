using System.Linq;
using System.Web.Mvc;
using EntityFrameworkTutorial.Data.Models;
using EntityFrameworkTutorial.Data.RepositoryPatterns.Approach01;

namespace EntityFrameworkTutorial.Mvc.Controllers
{
	public class Approach01Controller : Controller
	{
		IUnitOfWork uow;
		ProductRepository productRepository;

		public Approach01Controller()
		{
			uow = new UnitOfWork();
			productRepository = new ProductRepository(uow);
		}


		public ActionResult Index()
		{
			var products = productRepository.GetAll();

			var data = products.Select(x => new
			{
				x.ProductId,
				x.ProductName
			}).ToList();

			return Json(data, JsonRequestBehavior.AllowGet);
		}


		public ActionResult Details(int id = 0)
		{
			var product = productRepository.SingleOrDefault(id);
			if (product == null)
			{
				return HttpNotFound();
			}
			return Json(product, JsonRequestBehavior.AllowGet);
		}
		

		[HttpPost]
		public void Create(Product product)
		{
			if (ModelState.IsValid)
			{
				productRepository.Insert(product);
			}
		}


		[HttpPost]
		public void Update(Product product)
		{
			if (ModelState.IsValid)
			{
				productRepository.Update(product);
			}
		}
		
		
		public void Delete(int id)
		{
			var product = productRepository.SingleOrDefault(id);
			productRepository.Delete(product);
		}


		protected override void Dispose(bool disposing)
		{
			uow.Dispose();
			base.Dispose(disposing);
		}
	}
}
