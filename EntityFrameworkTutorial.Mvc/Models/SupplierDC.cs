using System.Collections.Generic;

namespace EntityFrameworkTutorial.Mvc.Models
{
	public class SupplierDC
	{
		public int SupplierId { get; set; }
		public string CompanyName { get; set; }
		public IEnumerable<ProductDC> Products { get; set; }

	}
}