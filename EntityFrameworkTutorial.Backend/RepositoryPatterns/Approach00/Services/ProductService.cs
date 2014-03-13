using System.Collections.Generic;
using System.Linq;
using EntityFrameworkTutorial.Backend.Models;
using EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach00.Data;
using EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach00.Data.EntityRepositories;

namespace EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach00.Services
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _productRepository;
		private readonly IUnitOfWork _unitOfWork;

		public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
		{
			_productRepository = productRepository;
			_unitOfWork = unitOfWork;
		}


		#region IProductService Members
		public IEnumerable<Product> GetProductsBySupplierId(int supplierId)
		{
			var products = _productRepository.GetProductsBySupplierId(supplierId).ToList();
			return products;
		}

		public IEnumerable<Product> GetProducts()
		{
			var products = _productRepository.GetAll();
			return products;
		}

		public Product GetProduct(int id)
		{
			var product = _productRepository.Find(id);
			return product;
		}

		public void CreateProduct(Product product)
		{
			_productRepository.Insert(product);
			_unitOfWork.Commit();
		}

		public void DeleteProduct(int id)
		{
			var product = _productRepository.Find(id);
			_productRepository.Delete(product);
			_unitOfWork.Commit();
		}

		public void UpdateProduct(Product product)
		{
			_productRepository.Update(product);
			_unitOfWork.Commit();
		}
		#endregion
	}
}
