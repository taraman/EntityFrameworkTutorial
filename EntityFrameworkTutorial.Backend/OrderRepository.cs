using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using EntityFrameworkTutorial.Backend.Models;

namespace EntityFrameworkTutorial.Backend
{
	public class OrderRepository : IOrderRepository
	{
		OrdersContext context = new OrdersContext();
		
		IQueryable<Order> All
		{
			get { return context.Orders; }
		}


		IQueryable<Order> Include(IQueryable<Order> query, params Expression<Func<Order, object>>[] includedEntities)
		{
			//foreach (var entity in includedEntities)
			//{
			//	query = query.Include(entity);
			//}
			
			//doesn't work
			//includedEntities.Aggregate(query, (current, entity) => current.Include(entity));

			includedEntities.ToList().ForEach(entity => query = query.Include(entity));
			return query;
		}


		public IQueryable<Order> GetAll(params Expression<Func<Order, object>>[] includedEntities)
		{
			return Include(All, includedEntities);
		}


		public IQueryable<Order> GetMany(Expression<Func<Order, bool>> predicate, params Expression<Func<Order, object>>[] includedEntities)
		{
			return GetAll(includedEntities).Where(predicate);
		}
		


		public Order Find(int id)
		{
			return context.Orders.Find(id);
		}


		public void InsertOrUpdate(Order Order)
		{
			if (Order.OrderId == default(int))
			{
				// New entity
				context.Orders.Add(Order);
			}
			else
			{
				// Existing entity
				context.Entry(Order).State = EntityState.Modified;
			}
		}


		public void Delete(int id)
		{
			var Order = context.Orders.Find(id);
			context.Orders.Remove(Order);
		}


		public void Save()
		{
			context.SaveChanges();
		}


		public void Dispose()
		{
			context.Dispose();
		}




	}
}