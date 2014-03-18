using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach00.Data;
using EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach00.Data.EntityRepositories;
using EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach00.Services;
using EntityFrameworkTutorial.Backend.Models;

namespace EntityFrameworkTutorial.Mvc.Controllers
{
    public class Approach00Controller : Controller
    {
		private readonly IProductService _productService;
		private readonly IService _service;

		static readonly IUnitOfWork UoW = new UnitOfWork(new DbContextFactory());
		
		public Approach00Controller()
			: this(new ProductService(new ProductRepository(UoW), UoW), new Service(new GenericRepository(UoW),UoW))
		{

		}


		public Approach00Controller(IProductService productService, IService service)
		{
			_productService = productService;
			_service = service;
		}


		public ActionResult Index()
		{
			return View();
		}


	    static dynamic MapCategory(Product product)
		{
			return (product.Category != null)
					   ? new
					   {
						   product.Category.CategoryId,
						   product.Category.CategoryName
					   }
					   : null;
		}

	    static dynamic MapProduct(Product product)
		{
			return new
			{
				product.ProductId,
				product.ProductName,
				Category = MapCategory(product)
			};
		}

	    static dynamic MapProducts(IEnumerable<Product> products)
		{
			return products.Select(x => MapProduct(x)).ToList();
		}

		

		#region All Products
		public JsonResult GetAllProducts()
		{
			var products = _service.GetAllProducts();
			var data = MapProducts(products);
			//var data = products.Select(x => new
			//	{
			//		x.ProductId,
			//		x.ProductName,
			//	}).ToList();
			return Json(data, JsonRequestBehavior.AllowGet);
		}
		
		public JsonResult GetAllProductsWithCategories()
		{
			var products = _service.GetAllProductsWithCategories();
			var data = MapProducts(products);
			//var data = products.Select(x => new
			//{
			//	x.ProductId,
			//	x.ProductName,
			//	Category = new
			//	{
			//		x.Category.CategoryId,
			//		x.Category.CategoryName
			//	}
			//}).ToList();
			return Json(data, JsonRequestBehavior.AllowGet);
		}
		
		public JsonResult GetAllProductsOrdredByProductName()
		{
			var products = _service.GetAllProductsOrdredByProductName();
			var data = products.Select(x => new
			{
				x.ProductId,
				x.ProductName,
			}).ToList();
			return Json(data, JsonRequestBehavior.AllowGet);
		}
		
		public JsonResult GetAllProductsWithCategoriesOrdredByProductName()
		{
			var products = _service.GetAllProductsWithCategoriesOrdredByProductName();
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
		#endregion


		#region Second 10 Products Ordred By Product Name
		public JsonResult GetSecond10ProductsOrdredByProductName()
		{
			var products = _service.GetSecond10ProductsOrdredByProductName();
			var data = products.Select(x => new
			{
				x.ProductId,
				x.ProductName,
			}).ToList();
			return Json(data, JsonRequestBehavior.AllowGet);
		}

		public JsonResult GetSecond10ProductsWithCategoriesOrdredByProductName()
		{
			var products = _service.GetSecond10ProductsWithCategoriesOrdredByProductName();
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
		#endregion


		#region Get Products With Condition
		public JsonResult GetProductsWithCondition()
		{
			var products = _service.GetProductsWithCondition();
			var data = products.Select(x => new
			{
				x.ProductId,
				x.ProductName,
			}).ToList();
			return Json(data, JsonRequestBehavior.AllowGet);
		}

		public JsonResult GetProductsWithConditionWithCategories()
		{
			var products = _service.GetProductsWithConditionWithCategories();
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

		public JsonResult GetProductsWithConditionOrdredByProductName()
		{
			var products = _service.GetProductsWithConditionOrdredByProductName();
			var data = products.Select(x => new
			{
				x.ProductId,
				x.ProductName,
			}).ToList();
			return Json(data, JsonRequestBehavior.AllowGet);
		}

		public JsonResult GetProductsWithConditionWithCategoriesOrdredByProductName()
		{
			var products = _service.GetProductsWithConditionWithCategoriesOrdredByProductName();
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
		#endregion

		
		#region Get Second 10 Products With Condition Ordred By Product Name
		public JsonResult GetSecond10ProductsWithConditionOrdredByProductName()
		{
			var products = _service.GetSecond10ProductsWithConditionOrdredByProductName();
			var data = products.Select(x => new
			{
				x.ProductId,
				x.ProductName,
			}).ToList();
			return Json(data, JsonRequestBehavior.AllowGet);
		}

		public JsonResult GetSecond10ProductsWithConditionWithCategoriesOrdredByProductName()
		{
			var products = _service.GetSecond10ProductsWithConditionWithCategoriesOrdredByProductName();
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
		#endregion


		#region Get By Key
		public JsonResult GetProductUsingPredicate()
		{
			var product = _service.GetProductUsingPredicate();
			var data = new
			{
				product.ProductId,
				product.ProductName,
				Category = new
				{
					product.Category.CategoryId,
					product.Category.CategoryName
				}

			};
			return Json(data, JsonRequestBehavior.AllowGet);
		}
		
		public JsonResult GetProductUsingFind()
		{
			var product = _service.GetProductUsingFind();
			var data = new
			{
				product.ProductId,
				product.ProductName,
			};
			return Json(data, JsonRequestBehavior.AllowGet);
		}
		
		public JsonResult GetOrderDetailUsingFind()
		{
			var orderDetail = _service.GetOrderDetailUsingFind();
			var data = new
			{
				orderDetail.OrderId,
				orderDetail.ProductId,
				orderDetail.UnitPrice,
				orderDetail.Quantity,
				orderDetail.Discount
			};
			return Json(data, JsonRequestBehavior.AllowGet);
		}
		#endregion


		#region Insert
		public int Insert()
		{
			var product = new Product
			{
				ProductName = "New Product",
				Category = new Category
				{
					CategoryName = "New Category"
				}
			};

			var productId = _service.Insert(product);
			return productId;
		}

		public int InsertAndCommit()
		{
			var product = new Product
			{
				ProductName = "Other New Product",
				Category = new Category
				{
					CategoryName = "New Category"
				}
			};

			var productId = _service.InsertAndCommit(product);
			return productId;
		}
		#endregion


		#region Update
		public void Update()
		{
			var product = new Product
			{
				ProductId = 89,
				ProductName = "Updated Product"
			};

			_service.Update(product);
		}

		public void UpdateAndCommit()
		{
			var product = new Product
			{
				ProductId = 90,
				ProductName = "Updated Other Product"
			};

			_service.UpdateAndCommit(product);
		}
		#endregion


		#region Delete
		public void Delete()
		{
			var product = new Product
			{
				ProductId = 89,
			};

			_service.Delete(product);
		}

		public void DeleteAndCommit()
		{
			var product = new Product
			{
				ProductId = 90,
			};

			_service.DeleteAndCommit(product);
		}

		public void DeleteManyProducts()
		{
			var products = new List<Product>
				{
					new Product
						{
							ProductId = 86,
						},
					new Product
						{
							ProductId = 87,
						},
					new Product
						{
							ProductId = 88,
						}
				};
			
			_service.DeleteManyProducts(products);
		}
		#endregion



		public JsonResult GetProductsBySupplierId()
		{
			var products = _productService.GetProductsBySupplierId(1);
			var data = products.Select(x => new
			{
				x.ProductId,
				x.ProductName,
			}).ToList();
			return Json(data, JsonRequestBehavior.AllowGet);
		}
		


    }
}
