using System;
using System.Collections.Generic;

namespace EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach04.Data
{
	public interface IBaseRepository<T> where T : class
	{
		void Add(T entity);
		void Update(T entity);
		void Delete(T entity);
		void Delete(Func<T, bool> predicate);
		T GetById(object pk);
		T Get(Func<T, Boolean> where);
		IEnumerable<T> GetAll();
		IEnumerable<T> GetMany(Func<T, bool> where);
	}
}
