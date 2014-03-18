using System.Data.Entity;

namespace EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach00.Data
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly IContextFactory _contextFactory;

		DbContext _dataContext;
		public DbContext DataContext
		{
			get { return _dataContext ?? (_dataContext = _contextFactory.Get()); }
		}

		public UnitOfWork(IContextFactory contextFactory)
		{
			_contextFactory = contextFactory;
		}

		public void Commit()
		{
			DataContext.SaveChanges();
		}
	}
}
