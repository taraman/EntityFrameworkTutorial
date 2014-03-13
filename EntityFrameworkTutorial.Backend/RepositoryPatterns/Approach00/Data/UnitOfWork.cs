using System.Data.Entity;

namespace EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach00.Data
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly IDbContextFactory _dbContextFactory;

		DbContext _dataContext;
		public DbContext DataContext
		{
			get { return _dataContext ?? (_dataContext = _dbContextFactory.Get()); }
		}

		public UnitOfWork(IDbContextFactory dbContextFactory)
		{
			_dbContextFactory = dbContextFactory;
		}

		public void Commit()
		{
			DataContext.SaveChanges();
		}
	}
}
