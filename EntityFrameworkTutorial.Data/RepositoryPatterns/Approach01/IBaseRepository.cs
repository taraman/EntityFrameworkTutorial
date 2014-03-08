using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFrameworkTutorial.Data.RepositoryPatterns.Approach01
{
	public interface IBaseRepository<T>
	{
		IUnitOfWork UnitOfWork { get; }
		
		T Single(object primaryKey);
		
		T SingleOrDefault(object primaryKey);
		
		IEnumerable<T> GetAll();
		
		bool Exists(object primaryKey);
		
		int Insert(T entity);
		
		void Update(T entity);
		
		int Delete(T entity);
	}
}
