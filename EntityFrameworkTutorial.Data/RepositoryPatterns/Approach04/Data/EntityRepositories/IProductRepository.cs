using System;
using System.Collections.Generic;
using EntityFrameworkTutorial.Data.Models;

namespace EntityFrameworkTutorial.Data.RepositoryPatterns.Approach04.Data.EntityRepositories
{
	public interface IProductRepository : IBaseRepository<Product>
	{
		IEnumerable<Product> GetProductsBySupplierId(int supplierId);
	}

}
