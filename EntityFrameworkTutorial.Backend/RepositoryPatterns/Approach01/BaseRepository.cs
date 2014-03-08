using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach01
{

	public class BaseRepository<T> : IBaseRepository<T> where T : class
	{
		private readonly IUnitOfWork _unitOfWork;
		public IUnitOfWork UnitOfWork
		{
			get { return _unitOfWork; }
		}

		internal DbSet<T> dbSet;
		
		public BaseRepository(IUnitOfWork unitOfWork)
		{
			if (unitOfWork == null) throw new ArgumentNullException("unitOfWork");
			_unitOfWork = unitOfWork;
			dbSet = _unitOfWork.Context.Set<T>();
		}
		
		public T Single(object primaryKey)
		{
			var dbResult = dbSet.Find(primaryKey);
			return dbResult;
		}
		
		public T SingleOrDefault(object primaryKey)
		{
			var dbResult = dbSet.Find(primaryKey);
			return dbResult;
		}

		public IEnumerable<T> GetAll()
		{
			return dbSet.AsEnumerable().ToList();
		}

		public bool Exists(object primaryKey)
		{
			return dbSet.Find(primaryKey) != null;
		}
		
		public virtual int Insert(T entity)
		{
			dynamic obj = dbSet.Add(entity);
			_unitOfWork.Context.SaveChanges(); //Not Good
			return obj.Id;

		}
		
		public virtual void Update(T entity)
		{
			dbSet.Attach(entity);
			_unitOfWork.Context.Entry(entity).State = EntityState.Modified;
			_unitOfWork.Context.SaveChanges(); //Not Good
		}
		
		public int Delete(T entity)
		{
			if (_unitOfWork.Context.Entry(entity).State == EntityState.Detached)
			{
				dbSet.Attach(entity);
			}
			dynamic obj = dbSet.Remove(entity);
			this._unitOfWork.Context.SaveChanges();
			return obj.Id;
		}
	}

}
