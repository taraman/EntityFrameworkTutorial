using System.Data.Entity;

namespace EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach00.Data
{
	public interface IContextFactory
	{
		DbContext Get();
	}
}
