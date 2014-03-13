using System.Data.Entity;

namespace EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach00.Data
{
	public interface IUnitOfWork
	{
		DbContext DataContext { get; }
		void Commit();
	}
}
