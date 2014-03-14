using System;
using System.Linq;
using System.Linq.Expressions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach00.Data
{
	public interface IBaseRepository<TEntity> where TEntity : class
	{
		//IQueryable<T> GetAll(params Expression<Func<T, object>>[] includedEntities);
		//IQueryable<T> GetMany(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includedEntities);
		//T Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includedEntities);
		//T Find(params object[] keys);
		//void Insert(T entity);
		//void Update(T entity);
		//void Delete(T entity);

		IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includedEntities);

		IQueryable<TEntity> GetAll(
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, 
			params Expression<Func<TEntity, object>>[] includedEntities);

		IQueryable<TEntity> GetAll(
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
			ref int? totalRows, int index, int size,
			params Expression<Func<TEntity, object>>[] includedEntities);


		IQueryable<TEntity> GetMany(
			Expression<Func<TEntity, bool>> predicate,
			params Expression<Func<TEntity, object>>[] includedEntities);

		IQueryable<TEntity> GetMany(
			Expression<Func<TEntity, bool>> predicate,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
			params Expression<Func<TEntity, object>>[] includedEntities);

		IQueryable<TEntity> GetMany(
			Expression<Func<TEntity, bool>> predicate,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
			ref int? totalRows, int index, int size,
			params Expression<Func<TEntity, object>>[] includedEntities);


		TEntity Get(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includedEntities);

		TEntity Get(params object[] keys);

		void Insert(TEntity entity, bool commit = false);

		void Update(TEntity entity, bool commit = false);

		void Delete(TEntity entity, bool commit = false);
	}
}
