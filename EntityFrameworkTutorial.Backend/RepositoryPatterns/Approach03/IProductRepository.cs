using EntityFrameworkTutorial.Backend.Models;

namespace EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach03
{
	public interface IProductRepository : IRepository<Product>
	{
		string ResolvePicture();
	}
}