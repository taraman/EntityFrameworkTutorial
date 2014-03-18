using System.Linq;
using System.Web.Mvc;
using EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach04.Data;
using EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach04.Data.EntityRepositories;
using EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach04.Services;
using EntityFrameworkTutorial.Backend.Models;

namespace EntityFrameworkTutorial.Mvc.Controllers
{
	public class Approach04Controller : Controller
	{
		private readonly IProductService _productService;
		

		//we must use IoC to have one instance of ContextFactory
		static readonly IDbFactory dbFactory = new DbFactory();
		public Approach04Controller()
			: this(new ProductService(new ProductRepository(dbFactory), new UnitOfWork(dbFactory)))
		{

		}


		//This will not work correctly, because we have two different Instances of DataContext
		//public Approach04Controller()
		//	: this(new ProductService(new ProductRepository(new ContextFactory()), new UnitOfWork(new ContextFactory())))
		//{

		//}


		public Approach04Controller(IProductService productService)
		{
			_productService = productService;
		}


		[HttpGet]
		public JsonResult Details(int productId)
		{
			var product = _productService.GetProductById(productId);
			var data = new
			{
				product.ProductId,
				product.ProductName,
				product.CategoryId,
				product.SupplierId,
				Category = new
				{
					product.Category.CategoryId,
					product.Category.CategoryName
				}

			};
			return Json(data, JsonRequestBehavior.AllowGet);
		}


		public JsonResult List()
		{
			var products = _productService.GetProducts();

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
		

		[HttpPost]
		public void Update(Product product)
		{
			//http://localhost:13746/Approach04/Update
			//{"ProductId":80,"ProductName":"XXXXX","CategoryId":1,"SupplierId":1}
			_productService.UpdateProduct(product);
		}


		[HttpPost]
		public void Create(Product product)
		{
			//http://localhost:13746/Approach04/Create
			//{"ProductName":"XXXXX","CategoryId":1,"SupplierId":1}
			_productService.CreateProduct(product);
		}


		public void Delete(int productId)
		{
			//http://localhost:13746/Approach04/Delete?productId=78
			_productService.DeleteProduct(productId);
		}

	}
}