using System.Data.Entity;
using EntityFrameworkTutorial.Backend.Models;

namespace EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach03
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