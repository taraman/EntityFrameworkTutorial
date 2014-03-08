using EntityFrameworkTutorial.Data.Models;

namespace EntityFrameworkTutorial.Data.RepositoryPatterns.Approach03
{
	public interface IProductRepository : IRepository<Product>
	{
		string ResolvePicture();
	}
}