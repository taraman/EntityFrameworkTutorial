using System.Data.Entity;
using EntityFrameworkTutorial.Data.Models;

namespace EntityFrameworkTutorial.Data.RepositoryPatterns.Approach03
{
	public class CategoryRepository : Repository<Category>, ICategoryRepository
	{
		public CategoryRepository(DbContext context) : base(context) { }

		public string GetUrl()
		{
			return "";
		}
	}
}