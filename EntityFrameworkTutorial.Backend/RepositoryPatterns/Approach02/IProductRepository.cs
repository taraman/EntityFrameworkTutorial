using System;
using System.Linq;
using System.Linq.Expressions;
using EntityFrameworkTutorial.Backend.Models;

namespace EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach02
{
	public interface IProductRepository
	{
		IQueryable<Product> GetAll(params Expression<Func<Product, object>>[] includedEntities);
		IQueryable<Product> GetMany(Expression<Func<Product, bool>> predicate, params Expression<Func<Product, object>>[] includedEntities);
		Product Get(Expression<Func<Product, bool>> predicate, params Expression<Func<Product, object>>[] includedEntities);
		Product Find(int productId);
		void Insert(Product product);
		void Update(Product product);
		void Delete(Product product);
	}
}
