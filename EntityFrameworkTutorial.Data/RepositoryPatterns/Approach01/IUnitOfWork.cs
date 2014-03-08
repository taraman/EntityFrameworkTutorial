using System;
using System.Data.Entity;

namespace EntityFrameworkTutorial.Data.RepositoryPatterns.Approach01
{
	public interface IUnitOfWork : IDisposable
	{
		DbContext Context { get; }
		void Commit();
		void StartTransaction();
	}
}
