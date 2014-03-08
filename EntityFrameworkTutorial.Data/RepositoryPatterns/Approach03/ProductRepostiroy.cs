using System.Data.Entity;
using EntityFrameworkTutorial.Data.Models;

namespace EntityFrameworkTutorial.Data.RepositoryPatterns.Approach03
{
	public class ProductRepostiroy : Repository<Product>, IProductRepository
	{
		public ProductRepostiroy(DbContext context) : base(context) { }

		public string ResolvePicture()
		{
			return "";
		}
	}
}