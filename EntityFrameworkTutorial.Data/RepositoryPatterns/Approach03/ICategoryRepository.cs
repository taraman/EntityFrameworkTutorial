using EntityFrameworkTutorial.Data.Models;

namespace EntityFrameworkTutorial.Data.RepositoryPatterns.Approach03
{
	public interface ICategoryRepository : IRepository<Category>
	{
		string GetUrl();
	}
}