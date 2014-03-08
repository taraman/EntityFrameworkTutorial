using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using EntityFrameworkTutorial.Backend;
using EntityFrameworkTutorial.Backend.Models;


using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;



namespace EntityFrameworkTutorial.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
		{
			return View();
		}


		public string GetConnectionString()
		{
			using (var ctx = new OrdersContext())
			{
				var strConnection = ctx.Database.Connection.ConnectionString;
				return strConnection;
			}
		}


		public JsonResult EagerLoadingAll()
		{
			var repo = new OrderRepository();
			var orders = repo.GetAll(x => x.Shipper, x => x.Customer, x => x.Employee).Take(25).ToList();
			
			var data = orders.Select(x => new
			{
				x.OrderId,
				x.OrderDate,
				Shipper = new
				{
					x.Shipper.ShipperId,
					x.Shipper.CompanyName
				},
				Customer = new
				{
					x.Customer.CustomerId,
					x.Customer.CompanyName
				},
				Employee = new
				{
					x.Employee.EmployeeId,
					x.Employee.FirstName,
					x.Employee.LastName
				}

			}).ToList();
			
			return Json(data, JsonRequestBehavior.AllowGet);
		}


		public JsonResult EagerLoadingMany()
		{
			var repo = new OrderRepository();
			var orders = repo.GetMany(x => x.ShipperId == 1, x => x.Shipper, x => x.Customer, x => x.Employee).Take(25).ToList();

			var data = orders.Select(x => new
			{
				x.OrderId,
				x.OrderDate,
				Customer = new
				{
					x.Customer.CustomerId,
					x.Customer.CompanyName
				},
				Employee = new
				{
					x.Employee.EmployeeId,
					x.Employee.FirstName,
					x.Employee.LastName
				}

			}).ToList();

			return Json(data, JsonRequestBehavior.AllowGet);
		}



		public JsonResult LazyLoading()
		{
			var repo = new OrderRepository();
			var orders = repo.GetAll().Take(25).ToList();

			var data = orders.Select(x => new
			{
				x.OrderId,
				x.OrderDate,
				Shipper = new
				{
					x.Shipper.ShipperId,
					x.Shipper.CompanyName
				},
				Customer = new
				{
					x.Customer.CustomerId,
					x.Customer.CompanyName
				},
				Employee = new
				{
					x.Employee.EmployeeId,
					x.Employee.FirstName,
					x.Employee.LastName
				}

			}).ToList();

			return Json(data, JsonRequestBehavior.AllowGet);
		}




		public JsonResult Include1()
		{
			var context = new OrdersContext();
			var products = context.Products.Where(x => x.SupplierId == 1).Include(x=>x.Category).ToList();
			
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


		public JsonResult Include2()
		{
			var context = new OrdersContext();
			var products = context.Products.Include(x => x.Category).Where(x => x.SupplierId == 1).ToList();

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


		public JsonResult Test()
		{
			var context = new OrdersContext();
			var categories = context.Categories.Select(x => x.CategoryName).ToList();
			return Json(categories, JsonRequestBehavior.AllowGet);
		}


		public JsonResult Test2()
		{
			var context = new OrdersContext();
			var categories = context.Categories;
			return Json(categories, JsonRequestBehavior.AllowGet);
		}



		public void InsertCategory()
		{
			var category = new Category
			{
				CategoryName = "Tempxxxxxx",
				Description = "Temp Descxxxxxx"
			};

			using (var ctx = new OrdersContext())
			{
				ctx.Categories.Add(category);
				ctx.SaveChanges();
			}
		}



		//http://romiller.com/2012/04/20/what-tables-are-in-my-ef-model-and-my-database/
		public JsonResult GetTableAndColumns()
		{
			var tableNames = new List<string>();
			using (var db = new OrdersContext())
			{
				var metadata = ((IObjectContextAdapter)db).ObjectContext.MetadataWorkspace;

				var tables = metadata.GetItemCollection(DataSpace.SSpace)
				  .GetItems<EntityContainer>()
				  .Single()
				  .BaseEntitySets
				  .OfType<EntitySet>()
				  .Where(s => !s.MetadataProperties.Contains("Type") || s.MetadataProperties["Type"].ToString() == "Tables");

				

				foreach (var table in tables)
				{
					var tableName = table.MetadataProperties.Contains("Table") && table.MetadataProperties["Table"].Value != null
					  ? table.MetadataProperties["Table"].Value.ToString()
					  : table.Name;

					var tableSchema = table.MetadataProperties["Schema"].Value.ToString();
					tableNames.Add(tableSchema + "." + tableName);
					//System.Console.WriteLine(tableSchema + "." + tableName);
				}

			}

			return Json(tableNames, JsonRequestBehavior.AllowGet);
		}


		

    }
}
