using System.Data.Entity;
using System.Transactions;
using EntityFrameworkTutorial.Backend.Models;

//C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0

namespace EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach01
{
	public class UnitOfWork : IUnitOfWork
	{
		private TransactionScope _transaction;
		
		private readonly OrdersContext _context;
		public DbContext Context
		{
			get { return _context; }
		}
		
		public UnitOfWork()
		{
			_context = new OrdersContext();
		}
		
		public void StartTransaction()
		{
			_transaction = new TransactionScope();
		}
		
		public void Commit()
		{
			_context.SaveChanges();
			_transaction.Complete();
		}
		
		public void Dispose()
		{

		}
	}
}
