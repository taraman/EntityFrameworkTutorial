using System.Linq;
using EntityFrameworkTutorial.Backend.Models;

namespace EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach00.Data.EntityRepositories
{
	public interface IProductRepository : IBaseRepository<Product>
	{
		IQueryable<Product> GetProductsBySupplierId(int supplierId);
	}

}
