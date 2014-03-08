﻿using System;
using System.Linq;
using System.Linq.Expressions;
using EntityFrameworkTutorial.Data.Models;

namespace EntityFrameworkTutorial.Data
{
	public interface IOrderRepository
	{
		IQueryable<Order> GetAll(params Expression<Func<Order, object>>[] includedEntities);
		IQueryable<Order> GetMany(Expression<Func<Order, bool>> predicate, params Expression<Func<Order, object>>[] includedEntities);
		Order Find(int id);
		void InsertOrUpdate(Order Order);
		void Delete(int id);
		void Save();
	}
}
