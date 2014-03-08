﻿using System.Data.Entity;
using EntityFrameworkTutorial.Data.Models;

namespace EntityFrameworkTutorial.Data.RepositoryPatterns.Approach04.Data
{
	public class UnitOfWork : IUnitOfWork
	{
		//private readonly IDbFactory _dbFactory;

		//private OrdersContext _dataContext;
		//protected OrdersContext DataContext
		//{
		//	get { return _dataContext ?? (_dataContext = _dbFactory.Get()); }
		//}

		//public UnitOfWork(IDbFactory dbFactory)
		//{
		//	_dbFactory = dbFactory;
		//}
		
		//public void Commit()
		//{
		//	DataContext.Commit();
		//}



		private readonly IDbFactory _dbFactory;

		private DbContext _dataContext;
		protected DbContext DataContext
		{
			get { return _dataContext ?? (_dataContext = _dbFactory.Get()); }
		}

		public UnitOfWork(IDbFactory dbFactory)
		{
			_dbFactory = dbFactory;
		}

		public void Commit()
		{
			DataContext.SaveChanges();
		}


	}
}
