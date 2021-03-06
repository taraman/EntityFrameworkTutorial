using System.Collections.Generic;
using System.Linq;
using EntityFrameworkTutorial.Backend.Models;

namespace EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach04.Data.EntityRepositories
{
	public class ProductRepository : BaseRepository<Product>, IProductRepository
	{
		public ProductRepository(IDbFactory dbFactory): base(dbFactory)
		{
		}

		public IEnumerable<Product> GetProductsBySupplierId(int supplierId)
		{
			var products = DataContext.Products.Where(x => x.SupplierId == supplierId).ToList();

			//to be enhanced by using decorate pattern
			// change GetAll to return IQuerable (deffered execution)
			//var products = base.GetAll().Where(x => x.SupplierId == supplierId).ToList();
			return products;
		}
	}

}
