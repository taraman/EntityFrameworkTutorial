using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using EntityFrameworkTutorial.Data.Models;

namespace EntityFrameworkTutorial.Data.RepositoryPatterns.Approach04.Data
{
	public abstract class BaseRepository<T>:IBaseRepository<T> where T : class
	{
		protected IDbFactory DbFactory { get; private set; }

		private OrdersContext _dataContext;
		//protected OrdersContext DataContext
		//{
		//	get { return _dataContext ?? (_dataContext = DbFactory.Get()); }
		//}

		protected OrdersContext DataContext
		{
			get { return _dataContext ?? (_dataContext = (OrdersContext) DbFactory.Get()); } //need to be tested carefully
		}

		private readonly IDbSet<T> dbset;

		protected BaseRepository(IDbFactory dbFactory)
		{
			DbFactory = dbFactory;
			dbset = DataContext.Set<T>();
		}
		
		public virtual void Add(T entity)
		{
			dbset.Add(entity);
		}

		public virtual void Update(T entity)
		{
			_dataContext.Entry(entity).State = EntityState.Modified;
		}

		public virtual void Delete(T entity)
		{
			dbset.Remove(entity);
		}

		public void Delete(Func<T, Boolean> where)
		{
			IEnumerable<T> objects = dbset.Where<T>(where).AsEnumerable();
			foreach (T obj in objects)
				dbset.Remove(obj);
		}

		public virtual T GetById(object id)
		{
			return dbset.Find(id);
		}

		public T Get(Func<T, Boolean> where)
		{
			return dbset.Where(where).FirstOrDefault<T>();
		}

		public virtual IEnumerable<T> GetAll() //neet to return IQuerable
		{
			return dbset.ToList();
		}

		public virtual IEnumerable<T> GetMany(Func<T, bool> where)
		{
			return dbset.Where(where).ToList();
		}
	}
}
