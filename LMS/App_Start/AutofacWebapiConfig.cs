using Autofac;
using Autofac.Integration.WebApi;
using BL;
using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace LMS.App_Start
{
	public class AutofacWebapiConfig
	{
		public static Autofac.IContainer Container;

		public static void Initialize(HttpConfiguration config)
		{
			Initialize(config, RegisterServices(new ContainerBuilder()));
		}


		public static void Initialize(HttpConfiguration config, Autofac.IContainer container)
		{
			config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
		}

		private static Autofac.IContainer RegisterServices(ContainerBuilder builder)
		{
			//Register your Web API controllers.  
			builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

			RepositoryCompositionRoot.RegisterTypes(builder);
			BusinessLogicCompositionRoot.RegisterTypes(builder);

			//Set the dependency resolver to be Autofac.  
			Container = builder.Build();

			return Container;
		}
	}


}