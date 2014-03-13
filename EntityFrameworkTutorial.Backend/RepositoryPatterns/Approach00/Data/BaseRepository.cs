using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach00.Data
{
	public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
	{
		protected DbContext Context { get; set; }
		IDbSet<T> Dbset { get; set; }
		IQueryable<T> All
		{
			get { return Dbset.AsQueryable(); }
		}
		
		protected BaseRepository(IUnitOfWork uow)
		{
			Context = uow.DataContext;
			Dbset = Context.Set<T>();
		}
		
		static IQueryable<T> Include(IQueryable<T> query, params Expression<Func<T, object>>[] includedEntities)
		{
			includedEntities.ToList().ForEach(entity => query = query.Include(entity));
			return query;
		}

		public IQueryable<T> GetAll(params Expression<Func<T, object>>[] includedEntities)
		{
			return Include(All, includedEntities);
		}

		public IQueryable<T> GetMany(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includedEntities)
		{
			return GetAll(includedEntities).Where(predicate);
		}

		public T Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includedEntities)
		{
			return GetMany(predicate, includedEntities).SingleOrDefault();
		}

		public T Find(params object[] keys)
		{
			return Dbset.Find(keys);
		}

		//public virtual T GetById(object id)
		//{
		//	return Dbset.Find(id);
		//}
		
		public void Insert(T entity)
		{
			Dbset.Add(entity);
		}

		public void Update(T entity)
		{
			Dbset.Attach(entity);
			Context.Entry(entity).State = EntityState.Modified;
		}

		public void Delete(T entity)
		{
			if (Context.Entry(entity).State == EntityState.Detached)
			{
				Dbset.Attach(entity);
			}
			Dbset.Remove(entity);
		}

	}
}
