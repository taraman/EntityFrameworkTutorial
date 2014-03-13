using System;
using System.Linq;
using System.Linq.Expressions;

namespace EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach00.Data
{
	public interface IBaseRepository<T>
	{
		IQueryable<T> GetAll(params Expression<Func<T, object>>[] includedEntities);
		IQueryable<T> GetMany(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includedEntities);
		T Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includedEntities);
		T Find(params object[] keys);
		void Insert(T entity);
		void Update(T entity);
		void Delete(T entity);
	}
}
