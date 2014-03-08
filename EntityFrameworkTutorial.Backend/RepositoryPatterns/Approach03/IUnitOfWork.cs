using System;

namespace EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach03
{
	public interface IUnitOfWork : IDisposable
	{
		ICategoryRepository Categories { get; }
		IProductRepository Products { get; }

		int SaveChanges();
	};


	
}
