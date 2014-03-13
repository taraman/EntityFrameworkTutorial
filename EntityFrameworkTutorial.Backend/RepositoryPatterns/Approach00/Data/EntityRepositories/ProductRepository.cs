using System.Collections.Generic;
using System.Linq;
using EntityFrameworkTutorial.Backend.Models;

namespace EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach00.Data.EntityRepositories
{
	public class ProductRepository : BaseRepository<Product>, IProductRepository
	{
		public ProductRepository(IUnitOfWork uow): base(uow)
		{
		}

		public IQueryable<Product> GetProductsBySupplierId(int supplierId)
		{
			var products = GetMany(x => x.SupplierId == supplierId); 
			return products;
		}
	}

}
