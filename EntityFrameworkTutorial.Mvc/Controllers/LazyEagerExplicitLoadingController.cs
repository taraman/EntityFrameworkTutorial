using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

using EntityFrameworkTutorial.Backend.Models;
using EntityFrameworkTutorial.Mvc.Models;

namespace EntityFrameworkTutorial.Mvc.Controllers
{
	public class LazyEagerExplicitLoadingController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}



		#region Lazy Loading vs. Eager Loading (Immediate Execution)
		//Lazy Loading (Immediate Execution)
		public JsonResult LazyLoading()
		{
			var context = new OrdersContext();
			var products = context.Products.ToList(); //Immediate Execution

			//check SQL Profiler here
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

			//check SQL Profiler here
			return Json(data, JsonRequestBehavior.AllowGet);
		}

		//Eager Loading (Immediate Execution)
		public JsonResult EagerLoading()
		{
			var context = new OrdersContext();
			var products = context.Products.Include(x => x.Category).ToList(); //Immediate Execution

			//check SQL Profiler here
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

			//check SQL Profiler here
			return Json(data, JsonRequestBehavior.AllowGet);
		}
		#endregion




		#region Eager Loading Cases
		public JsonResult EagerLoadingWithLessIncludes()
		{
			var context = new OrdersContext();
			var products = context.Products.Include(x => x.Category).ToList();

			//check SQL Profiler here
			var data = products.Select(x => new
			{
				x.ProductId,
				x.ProductName,
				Category = new
				{
					x.Category.CategoryId,
					x.Category.CategoryName
				},
				Supplier = new //Supplier is not exist in "include"
				{
					x.Supplier.SupplierId,
					x.Supplier.CompanyName
				}

			}).ToList();

			//check SQL Profiler here

			return Json(data, JsonRequestBehavior.AllowGet);
		}
		
		public JsonResult EagerLoadingWithExactIncludes()
		{
			var context = new OrdersContext();
			var products = context.Products.Include(x => x.Category).Include(x => x.Supplier).ToList(); //Immediate Execution

			//check SQL Profiler here

			var data = products.Select(x => new
			{
				x.ProductId,
				x.ProductName,
				Category = new
				{
					x.Category.CategoryId,
					x.Category.CategoryName
				},
				Supplier = new
				{
					x.Supplier.SupplierId,
					x.Supplier.CompanyName
				}

			}).ToList();

			//check SQL Profiler here
			return Json(data, JsonRequestBehavior.AllowGet);
		}
		
		public JsonResult EagerLoadingWithMoreIncludes()
		{
			var context = new OrdersContext();
			var products = context.Products.Include(x => x.Category).Include(x => x.Supplier).ToList(); //Immediate Execution

			//check SQL Profiler here

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

			//check SQL Profiler here
			return Json(data, JsonRequestBehavior.AllowGet);
		}
		#endregion




		#region Best Practices: Lazy Loading and Deferred Execution to combine/extend multiple queries
		public JsonResult LazyLoadingDeferredExecution(bool getSuppliers)
		{
			var context = new OrdersContext();
			var products = context.Products; //Deffered Execution

			//check SQL Profiler here

			List<ProductDC> productDCs;

			if (getSuppliers)
			{
				productDCs = products.Select(x => new ProductDC
				{
					ProductId = x.ProductId,
					ProductName = x.ProductName,
					Supplier = new SupplierDC
					{
						SupplierId = x.Supplier.SupplierId,
						CompanyName = x.Supplier.CompanyName
					}

				}).ToList();
			}
			else
			{
				productDCs = products.Select(x => new ProductDC
				{
					ProductId = x.ProductId,
					ProductName = x.ProductName,
					Category = new CategoryDC
					{
						CategoryId = x.Category.CategoryId,
						CategoryName = x.Category.CategoryName
					}

				}).ToList();
			}

			//check SQL Profiler here
			return Json(productDCs, JsonRequestBehavior.AllowGet);
		}
		#endregion




		#region Using Iteration with Deffered Execution
		//Problem: Lazy Loading, Iteration using Foreach loop (Deffered Execution)
		public JsonResult LazyLoadingWithForeach()
		{
			var context = new OrdersContext();
			var products = context.Products;

			//check SQL Profiler here
			var productDcs = new List<ProductDC>();

			foreach (var x in products)
			{
				var product = new ProductDC
				{
					ProductId = x.ProductId,
					ProductName = x.ProductName,
					Category = new CategoryDC
					{
						CategoryId = x.Category.CategoryId,
						CategoryName = x.Category.CategoryName
					}
				};

				productDcs.Add(product);
				//check SQL Profiler here
			}

			return Json(productDcs, JsonRequestBehavior.AllowGet);
		}


		//Fixing: Eager Loading, Iteration using Foreach loop (Deffered Execution)
		public JsonResult EagerLoadingForeach()
		{
			var context = new OrdersContext();
			var products = context.Products.Include(x => x.Category);

			//check SQL Profiler here

			var productDcs = new List<ProductDC>();
			foreach (var x in products)
			{
				var product = new ProductDC
				{
					ProductId = x.ProductId,
					ProductName = x.ProductName,
					Category = new CategoryDC
					{
						CategoryId = x.Category.CategoryId,
						CategoryName = x.Category.CategoryName
					}
				};
				productDcs.Add(product);
				//check SQL Profiler here
			}

			return Json(productDcs, JsonRequestBehavior.AllowGet);
		}


		//Better Fixing: Lazy Loading, Iteration using Linq Expression (Deffered Execution)
		public JsonResult LazyLoadingLinqExpression()
		{
			var context = new OrdersContext();
			var products = context.Products;

			//check SQL Profiler here
			var productDcs = products.Select(x => new ProductDC
			{
				ProductId = x.ProductId,
				ProductName = x.ProductName,
				Category = new CategoryDC
				{
					CategoryId = x.Category.CategoryId,
					CategoryName = x.Category.CategoryName
				}
			}).ToList();

			return Json(productDcs, JsonRequestBehavior.AllowGet);
		}
		#endregion




		#region Queries that return a singleton value are executed immediately
		//Lazy Loading: return a singleton value
		public JsonResult LazyLoadingSingletonValue()
		{
			var context = new OrdersContext();

			//Queries that return a singleton value are executed immediately
			//e.g: Average, Count, First, Single, and Max
			var supplier = context.Suppliers.First();

			//check SQL Profiler here
			var supplierDC = new SupplierDC
			{
				SupplierId = supplier.SupplierId,
				CompanyName = supplier.CompanyName,
				Products = supplier.Products.Select(p => new ProductDC
				{
					ProductId = p.ProductId,
					ProductName = p.ProductName
				})
			};
			//check SQL Profiler here
			return Json(supplierDC, JsonRequestBehavior.AllowGet);
		}


		//Eager Loading: return a singleton value
		public JsonResult EagerLoadingSingletonValue()
		{
			var context = new OrdersContext();

			var supplier = context.Suppliers.Include(s => s.Products).First();

			//check SQL Profiler here
			var supplierDC = new SupplierDC
			{
				SupplierId = supplier.SupplierId,
				CompanyName = supplier.CompanyName,
				Products = supplier.Products.Select(p => new ProductDC
				{
					ProductId = p.ProductId,
					ProductName = p.ProductName
				})
			};
			//check SQL Profiler here
			return Json(supplierDC, JsonRequestBehavior.AllowGet);
		}
		#endregion




		#region Using Find() method or FirstOrDefault() method
		//Using Find() Method
		public JsonResult UsingFindMethod()
		{
			var context = new OrdersContext();

			var supplier1 = context.Suppliers.Find(1);

			var supplier = context.Suppliers.Find(1);

			var supplier2 = context.Suppliers.Find(2);


			var supplierDC = new
			{
				supplier.SupplierId,
				supplier.CompanyName
			};

			return Json(supplierDC, JsonRequestBehavior.AllowGet);
		}

		//Using FirstOrDefault() method
		public JsonResult UsingFirstOrDefault()
		{
			var context = new OrdersContext();

			var supplierX = context.Suppliers.FirstOrDefault(x => x.SupplierId == 1);

			var supplierY = context.Suppliers.FirstOrDefault(x => x.SupplierId == 1);

			var supplierXDc = new
			{
				supplierX.SupplierId,
				supplierX.CompanyName
			};

			var supplierYDc = new
			{
				supplierY.SupplierId,
				supplierY.CompanyName
			};

			return Json(new
			{
				supplierXDc,
				supplierYDc
			}, JsonRequestBehavior.AllowGet);
		}



		//Find() method Versus FirstOrDefault() method
		public JsonResult FindVersusFirstOrDefault()
		{
			var context = new OrdersContext();

			//Using Find()
			var supplierX1 = context.Suppliers.Find(1); // it will be cached
			var supplierX2 = context.Suppliers.Find(1);

			var supplierXDC = new SupplierDC
			{
				SupplierId = supplierX2.SupplierId,
				CompanyName = supplierX2.CompanyName,
				Products = supplierX2.Products.Select(p => new ProductDC
				{
					ProductId = p.ProductId,
					ProductName = p.ProductName
				})
			};


			//Using FirstOrDefault()
			var supplierY = context.Suppliers.Include(x => x.Products).FirstOrDefault(x => x.SupplierId == 1);

			var supplierYDC = new SupplierDC
			{
				SupplierId = supplierY.SupplierId,
				CompanyName = supplierY.CompanyName,
				Products = supplierX2.Products.Select(p => new ProductDC
				{
					ProductId = p.ProductId,
					ProductName = p.ProductName
				})
			};

			return Json(new
			{
				supplierXDC,
				supplierYDC
			}, JsonRequestBehavior.AllowGet);
		}
		#endregion




		#region Explicitly Loading
		public JsonResult ExplicitlyLoadingForSingleEntity()
		{
			var context = new OrdersContext();

			var product = context.Products.Find(1);
			context.Entry(product).Reference(p => p.Category).Load();

			var productDc = new ProductDC
			{
				ProductId = product.ProductId,
				ProductName = product.ProductName,
				Category = new CategoryDC()
				{
					CategoryId = product.Category.CategoryId,
					CategoryName = product.Category.CategoryName
				}
			};

			return Json(productDc, JsonRequestBehavior.AllowGet);
		}


		public JsonResult ExplicitlyLoadingForManyEntities()
		{
			var context = new OrdersContext();

			var category = context.Categories.Find(1);
			context.Entry(category).Collection(c => c.Products).Load();

			var categoryDC = new CategoryDC
			{
				CategoryId = category.CategoryId,
				CategoryName = category.CategoryName,
				Products = category.Products.Select(p => new ProductDC
				{
					ProductId = p.ProductId,
					ProductName = p.ProductName
				})
			};

			return Json(categoryDC, JsonRequestBehavior.AllowGet);
		}
		#endregion

	}

}
