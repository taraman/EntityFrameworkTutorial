using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;

using EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach00.Data;
using EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach00.Data.EntityRepositories;
using EntityFrameworkTutorial.Backend.RepositoryPatterns.Approach00.Services;

namespace EntityFrameworkTutorial.Mvc.App_Start
{
	public class IocConfig
	{
		public static void RegisterDependencies()
		{
			var builder = new ContainerBuilder();
			builder.RegisterControllers(typeof(MvcApplication).Assembly);

			builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerHttpRequest();
			builder.RegisterType<DbContextFactory>().As<IContextFactory>().InstancePerHttpRequest();
			builder.RegisterType<GenericRepository>().As<IGenericRepository>().InstancePerHttpRequest();
			builder.RegisterType<ProductRepository>().As<IProductRepository>().InstancePerHttpRequest();
			builder.RegisterType<ProductService>().As<IProductService>().InstancePerHttpRequest();
			builder.RegisterType<Service>().As<IService>().InstancePerHttpRequest();

			IContainer container = builder.Build();
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
		}
	}
}