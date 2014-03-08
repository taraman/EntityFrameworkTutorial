using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityFrameworkTutorial.Data.Models;

namespace EntityFrameworkTutorial.Data.RepositoryPatterns.Approach01
{
	public class ProductRepository : BaseRepository<Product>
	{
		public ProductRepository(IUnitOfWork unit): base(unit)
		{

		}
	}

}
