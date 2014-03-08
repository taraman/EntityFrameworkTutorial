using System;
using System.Data.Entity;
using EntityFrameworkTutorial.Backend.Models;

namespace EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach04.Data
{
	public class DbFactory : IDbFactory, IDisposable
	{
		//OrdersContext _dataContext;
		//public OrdersContext Get()
		//{
		//	return _dataContext ?? (_dataContext = new OrdersContext());
		//}

		DbContext _dataContext;
		public DbContext Get()
		{
			return _dataContext ?? (_dataContext = new OrdersContext());
		}

		~DbFactory()
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
			if (!_isDisposed && disposing && _dataContext != null)
			{
				_dataContext.Dispose();
				_dataContext = null;
			}
			_isDisposed = true;
		}
		#endregion
	}
}
