namespace EntityFrameworkTutorial.Mvc.Models
{
	public class ProductDC
	{
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public CategoryDC Category { get; set; }
		public SupplierDC Supplier { get; set; }
	}
}