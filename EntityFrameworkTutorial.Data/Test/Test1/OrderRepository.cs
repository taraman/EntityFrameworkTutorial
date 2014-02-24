using System;
using System.Linq;
using EntityFrameworkTutorial.Data.Models;


using System.Data.Entity;
using System.Linq.Expressions;

namespace EntityFrameworkTutorial.Data.Test.Test1
{
	public class OrderRepository : IOrderRepository
	{
		OrdersContext context = new OrdersContext();

		public IQueryable<Order> All
		{
			get { return context.Orders; }
		}

		public IQueryable<Order> AllIncluding(params Expression<Func<Order, object>>[] includeProperties)
		{
			IQueryable<Order> query = context.Orders;
			foreach (var includeProperty in includeProperties)
			{
				query = query.Include(includeProperty);
			}
			return query;
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
	}

	public interface IOrderRepository
	{
		IQueryable<Order> All { get; }
		IQueryable<Order> AllIncluding(params Expression<Func<Order, object>>[] includeProperties);
		Order Find(int id);
		void InsertOrUpdate(Order Order);
		void Delete(int id);
		void Save();
	}
}
