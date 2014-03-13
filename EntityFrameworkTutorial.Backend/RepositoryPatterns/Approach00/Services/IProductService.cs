using System.Collections.Generic;
using EntityFrameworkTutorial.Backend.Models;

namespace EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach00.Services
{
	public interface IProductService
	{
		IEnumerable<Product> GetProductsBySupplierId(int supplierId);
		IEnumerable<Product> GetProducts();
		Product GetProduct(int id);
		void CreateProduct(Product product);
		void UpdateProduct(Product product);
		void DeleteProduct(int id);
	}
}
