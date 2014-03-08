using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using EntityFrameworkTutorial.Backend.Models;

namespace EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach02
{
	public class ProductRepository : IProductRepository
	{
		OrdersContext _context;
		
		DbSet<Product> DbSet
		{
			get { return _context.Set<Product>(); }
		}

		IQueryable<Product> All
		{
			get { return DbSet.AsQueryable(); }
			//get { return _context.Products; }
		}

		public ProductRepository(OrdersContext context)
		{
			_context = context;
			//_dbSet = context.Set<Product>();
		}

		IQueryable<Product> Include(IQueryable<Product> query, params Expression<Func<Product, object>>[] includedEntities)
		{
			includedEntities.ToList().ForEach(entity => query = query.Include(entity));
			return query;
		}

		public IQueryable<Product> GetAll(params Expression<Func<Product, object>>[] includedEntities)
		{
			return Include(All, includedEntities);
		}

		public IQueryable<Product> GetAll2()
		{
			return _context.Products;
		}

		public IQueryable<Product> GetMany(Expression<Func<Product, bool>> predicate, params Expression<Func<Product, object>>[] includedEntities)
		{
			return GetAll(includedEntities).Where(predicate);
		}

		public Product Get(Expression<Func<Product, bool>> predicate, params Expression<Func<Product, object>>[] includedEntities)
		{
			return GetMany(predicate, includedEntities).SingleOrDefault();
		}

		public Product Find(int productId)
		{
			return _context.Products.Find(productId);
		}


		public void Insert(Product product)
		{
			DbSet.Add(product);
		}

		public void Update(Product product)
		{
			//var x = _context.Entry(product).State;
			DbSet.Attach(product);
			//var y = _context.Entry(product).State;
			_context.Entry(product).State = EntityState.Modified;
			//var z = _context.Entry(product).State;
		}

		public void Delete(Product product)
		{
			if (_context.Entry(product).State == EntityState.Detached)
			{
				DbSet.Attach(product);
			}
			DbSet.Remove(product);
		}
	}

}
