using EntityFrameworkTutorial.Backend.Models;

namespace EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach01
{
	public class ProductRepository : BaseRepository<Product>
	{
		public ProductRepository(IUnitOfWork unit): base(unit)
		{

		}
	}

}
