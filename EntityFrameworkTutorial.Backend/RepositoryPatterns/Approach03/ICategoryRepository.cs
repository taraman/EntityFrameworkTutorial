using EntityFrameworkTutorial.Backend.Models;

namespace EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach03
{
	public interface ICategoryRepository : IRepository<Category>
	{
		string GetUrl();
	}
}