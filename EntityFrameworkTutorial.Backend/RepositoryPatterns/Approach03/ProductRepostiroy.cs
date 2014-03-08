using System.Data.Entity;
using EntityFrameworkTutorial.Backend.Models;

namespace EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach03
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