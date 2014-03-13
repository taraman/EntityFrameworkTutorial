using System.Data.Entity;

namespace EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach04.Data
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly IDbFactory _dbFactory;

		DbContext _dataContext;
		protected DbContext DataContext
		{
			get { return _dataContext ?? (_dataContext = _dbFactory.Get()); }
		}

		public UnitOfWork(IDbFactory dbFactory)
		{
			_dbFactory = dbFactory;
		}

		public void Commit()
		{
			DataContext.SaveChanges();
		}


		//private readonly IDbContextFactory _dbFactory;

		//private OrdersContext _dataContext;
		//protected OrdersContext DataContext
		//{
		//	get { return _dataContext ?? (_dataContext = _dbFactory.Get()); }
		//}

		//public UnitOfWork(IDbContextFactory dbFactory)
		//{
		//	_dbFactory = dbFactory;
		//}

		//public void Commit()
		//{
		//	DataContext.Commit();
		//}


	}
}
