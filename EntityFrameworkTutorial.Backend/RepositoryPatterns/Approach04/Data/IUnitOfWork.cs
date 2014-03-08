namespace EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach04.Data
{
	public interface IUnitOfWork
	{
		void Commit();
	}
}
