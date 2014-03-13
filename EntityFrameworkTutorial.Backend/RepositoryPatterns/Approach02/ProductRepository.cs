using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using EntityFrameworkTutorial.Backend.Models;

namespace EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach02
{
	public class ProductRepository : IProductRepository
	{
		DbContext Context { get; set; }
		IDbSet<Product> Dbset {get; set;}

		IQueryable<Product> All
		{
			get { return Dbset.AsQueryable(); }
		}

		public ProductRepository(DbContext context)
		{
			Context = context;
			Dbset = context.Set<Product>();
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
			return Dbset.Find(productId);
		}


		public void Insert(Product product)
		{
			Dbset.Add(product);
		}

		public void Update(Product product)
		{
			//var x = Context.Entry(product).State;
			Dbset.Attach(product);
			//var y = Context.Entry(product).State;
			Context.Entry(product).State = EntityState.Modified;
			//var z = Context.Entry(product).State;
		}

		public void Delete(Product product)
		{
			if (Context.Entry(product).State == EntityState.Detached)
			{
				Dbset.Attach(product);
			}
			Dbset.Remove(product);
		}
	}

}
