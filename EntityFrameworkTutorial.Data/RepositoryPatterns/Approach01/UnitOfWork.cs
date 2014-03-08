using System.Data.Entity;
using System.Transactions; //C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0

using EntityFrameworkTutorial.Data.Models;

namespace EntityFrameworkTutorial.Data.RepositoryPatterns.Approach01
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
