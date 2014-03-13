using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EntityFrameworkTutorial.Backend.Models;
using EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach02;

namespace EntityFrameworkTutorial.Mvc.Controllers
{
    public class Approach02Controller : Controller
    {
		private UnitOfWork unitOfWork = null;

        public Approach02Controller(): this(new UnitOfWork())
        {

        }
		
		public Approach02Controller(UnitOfWork uow)
        {
            unitOfWork = uow;
        }
		
		public ActionResult Index()
		{
			return View();
		}
		
		dynamic getCategory(Product product)
		{
			return (product.Category != null)
					   ? new
					   {
						   product.Category.CategoryId,
						   product.Category.CategoryName
					   }
					   : null;
		}

		dynamic GetProduct(Product product)
		{
			return new
			{
				product.ProductId,
				product.ProductName,
				Category = getCategory(product)
			};
		}

		dynamic GetProducts(IEnumerable<Product> products)
		{
			return products.Select(x => GetProduct(x)).ToList();
		}
		

		public JsonResult GetAll()
		{
			var products = unitOfWork.ProductRepository.GetAll(x=>x.Category).ToList();
			var data = GetProducts(products);
			return Json(data, JsonRequestBehavior.AllowGet);
		}

		
	    public JsonResult GetMany()
		{
			var products = unitOfWork.ProductRepository.GetMany(x => x.SupplierId == 1, x => x.Category).ToList();
			var data = GetProducts(products);
			return Json(data, JsonRequestBehavior.AllowGet);
		}

		public JsonResult Get()
		{
			var product = unitOfWork.ProductRepository.Get(x => x.ProductId == 1, x => x.Category);
			var data = GetProduct(product);
			return Json(data, JsonRequestBehavior.AllowGet);
		}


		public JsonResult Find()
		{
			var product = unitOfWork.ProductRepository.Find(productId:1);
			//var product = unitOfWork.ProductRepository.Find(productId: 80); // null category
			var data = GetProduct(product);
			return Json(data, JsonRequestBehavior.AllowGet);
		}
		

	    public void Insert()
	    {
		    var product = new Product
			    {
				    ProductName = "Product555",
				    SupplierId = 1,
				    CategoryId = 1,
				    UnitPrice = 100,
				    UnitsInStock = 25,
				    Discontinued = false
			    };
		    unitOfWork.ProductRepository.Insert(product);
			//unitOfWork.ProductRepository.Commit();
			unitOfWork.Commit();
	    }


		public void Update()
		{
			var product1 = new Product
			{
				ProductId = 82,
				ProductName = "XXXXXX",
				SupplierId = 1,
				CategoryId = 1,
				UnitPrice = 100,
				UnitsInStock = 25,
				Discontinued = false
			};
			unitOfWork.ProductRepository.Update(product1);


			//var product2 = new Product
			//{
			//	ProductId = 84,
			//	ProductName = "zzzzzzzzzzzz",
			//	SupplierId = 1,
			//	CategoryId = 1,
			//	UnitPrice = 100,
			//	UnitsInStock = 25,
			//	Discontinued = false
			//};
			//unitOfWork.ProductRepository.Update(product2);
			
			unitOfWork.Commit();
		}


		public void Delete()
		{
			var product = new Product
			{
				ProductId = 84,
			};
			unitOfWork.ProductRepository.Delete(product);
			unitOfWork.Commit();
		}
    }
}
