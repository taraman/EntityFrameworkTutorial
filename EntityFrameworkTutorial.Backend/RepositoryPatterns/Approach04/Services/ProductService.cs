using System.Collections.Generic;
using EntityFrameworkTutorial.Backend.Models;
using EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach04.Data;
using EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach04.Data.EntityRepositories;

namespace EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach04.Services
{
	public class ProductService: IProductService
	{
		private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        #region IProductService Members
		public IEnumerable<Product> GetProducts()
        {
            var products = _productRepository.GetAll();
            return products;
        }

        public Product GetProductById(int id)
        {
            var product = _productRepository.GetById(id);
            return product;
        }

        public void CreateProduct(Product product)
        {
            _productRepository.Add(product);
            _unitOfWork.Commit();
        }

        public void DeleteProduct(int id)
        {
            var product = _productRepository.GetById(id);
            _productRepository.Delete(product);
            _unitOfWork.Commit();
        }

        public void UpdateProduct(Product product)
        {
            _productRepository.Update(product);
            _unitOfWork.Commit();
        }

        public void SaveProduct()
        {
            _unitOfWork.Commit();
        }

        #endregion

	}
}
