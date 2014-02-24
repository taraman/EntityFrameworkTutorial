using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityFrameworkTutorial.Data.Models;

namespace EntityFrameworkTutorial.Mvc.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

		public ActionResult Index()
		{
			return View();
		}

		//public int Index()
		//{
		//	return 5;
		//}


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

		public JsonResult TestLazyLoading()
		{
			var repo = new Data.Test.Test1.OrderRepository();
			var orders = repo.All.ToList();

			

			return Json(orders, JsonRequestBehavior.AllowGet);


		}


		public JsonResult TestEagerLoading()
		{
			var repo = new Data.Test.Test1.OrderRepository();
			var orders = repo.AllIncluding(x => x.Shipper).ToList();
			

			return Json(orders, JsonRequestBehavior.AllowGet);
		}

    }
}
