using System;
using EntityFrameworkTutorial.Data.Models;

namespace EntityFrameworkTutorial.Data.RepositoryPatterns.Approach02
{
	public class UnitOfWork : IDisposable
	{
		OrdersContext _context;

		public IProductRepository ProductRepository
		{
			get;
			private set;
		}
		
		public UnitOfWork()
		{
			_context = new OrdersContext();
			ProductRepository = new ProductRepository(_context);
		}
		
		public void Commit()
		{
			_context.SaveChanges();
		}
		
		~UnitOfWork()
		{
			Dispose(false);
		}
		
		#region IDisposable Members
		bool _isDisposed;

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		void Dispose(bool disposing)
		{
			if (!_isDisposed && disposing && _context != null)
			{
				_context.Dispose();
				_context = null;
			}
			_isDisposed = true;
		}
		#endregion
	}
}
