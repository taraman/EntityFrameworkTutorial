using System;
using System.Data.Entity;
using EntityFrameworkTutorial.Data.Models;

namespace EntityFrameworkTutorial.Data.RepositoryPatterns.Approach03
{
	public class UnitOfWork : IUnitOfWork
	{
		private DbContext dbContext;

		private ICategoryRepository categories;
		public ICategoryRepository Categories
		{
			get
			{
				if (categories == null)
					categories = new CategoryRepository(dbContext);
				return categories;
			}
		}

		private IProductRepository products;
		public IProductRepository Products
		{
			get
			{
				if (products == null)
					products = new ProductRepostiroy(dbContext);
				return products;
			}
		}

		public UnitOfWork()
		{
			dbContext = new OrdersContext();
		}
		

		public int SaveChanges()
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			if (categories != null)
				categories.Dispose();

			if (products != null)
				products.Dispose();

			if (dbContext != null)
				dbContext.Dispose();

			GC.SuppressFinalize(this);
		}

		
	}
}