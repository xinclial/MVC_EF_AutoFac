using Autofac;
using Autofac.Integration.Mvc;
using CTMMIS.BLL.Service;
using CTMMIS.IBLL.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Web.App_Start
{
    public class AutoFacConfig
    {
        public static IContainer container = null;
        public static void IocRegister()
        {
            ContainerBuilder builder = new ContainerBuilder();

            Assembly controllerAss = Assembly.Load("Web");
            builder.RegisterControllers(controllerAss);

            builder.RegisterType<Service_T_Case_Main>().As<IService_T_Case_Main>().InstancePerLifetimeScope();
            container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            
        }

        public static T Resolve<T>()
        {
            //try
            //{
            //    if (container == null)
            //    {
            //        Initialise();
            //    }
            //}
            //catch (System.Exception ex)
            //{
            //    throw new System.Exception("IOC实例化出错!" + ex.Message);
            //}

            return container.Resolve<T>();
        }
    }
}