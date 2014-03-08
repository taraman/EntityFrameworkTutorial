using System.Data.Entity;

namespace EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach04.Data
{
	public interface IDbFactory
	{
		//OrdersContext Get();

		DbContext Get();
	}
}
