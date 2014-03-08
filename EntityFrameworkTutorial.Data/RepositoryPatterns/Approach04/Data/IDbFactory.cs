using System.Data.Entity;
using EntityFrameworkTutorial.Data.Models;

namespace EntityFrameworkTutorial.Data.RepositoryPatterns.Approach04.Data
{
	public interface IDbFactory
	{
		//OrdersContext Get();

		DbContext Get();
	}
}
