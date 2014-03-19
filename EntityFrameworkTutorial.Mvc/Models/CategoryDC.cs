using System.Collections.Generic;

namespace EntityFrameworkTutorial.Mvc.Models
{
	public class CategoryDC
	{
		public int CategoryId { get; set; }
		public string CategoryName { get; set; }
		public IEnumerable<ProductDC> Products { get; set; }
	}
}