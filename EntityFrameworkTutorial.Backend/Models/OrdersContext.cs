using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using EntityFrameworkTutorial.Backend.Models.Mapping;

namespace EntityFrameworkTutorial.Backend.Models
{
    public class OrdersContext : DbContext
    {
		static OrdersContext()
		{
			Database.SetInitializer<OrdersContext>(null);
		}

		public OrdersContext()
			: base("Name=OrdersContext")
		{
			//Database.SetInitializer(new MigrateDatabaseToLatestVersion<OrdersContext, SchoolDataLayer.Migrations.Configuration>("OrdersContext"));
			//Database.SetInitializer<OrdersContext>(null);
		}

		//public virtual void Commit() //Used in  Aopproac04
		//{
		//	base.SaveChanges();
		//}

        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new EmployeeMap());
            modelBuilder.Configurations.Add(new OrderDetailMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new ShipperMap());
            modelBuilder.Configurations.Add(new SupplierMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
        }
    }
}
