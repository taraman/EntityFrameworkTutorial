using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFrameworkTutorial.Data.RepositoryPatterns.Approach03
{
	public interface IUnitOfWork : IDisposable
	{
		ICategoryRepository Categories { get; }
		IProductRepository Products { get; }

		int SaveChanges();
	};


	
}
