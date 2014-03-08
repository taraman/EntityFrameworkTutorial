using System.Collections.Generic;
using EntityFrameworkTutorial.Backend.Models;

namespace EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach04.Data.EntityRepositories
{
	public interface IProductRepository : IBaseRepository<Product>
	{
		IEnumerable<Product> GetProductsBySupplierId(int supplierId);
	}

}
