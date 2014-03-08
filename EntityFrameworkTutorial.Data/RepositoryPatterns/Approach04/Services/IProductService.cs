using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityFrameworkTutorial.Data.Models;

namespace EntityFrameworkTutorial.Data.RepositoryPatterns.Approach04.Services
{
	public interface IProductService
	{
		IEnumerable<Product> GetProducts();
		Product GetProductById(int id);
		void CreateProduct(Product product);
		void UpdateProduct(Product product);
		void DeleteProduct(int id);
		void SaveProduct();
	}
}
