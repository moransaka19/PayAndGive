using Autofac;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BLL
{
    public class Bootstrapper
    {
        public static void Bootstrap(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(x => x.Name.EndsWith("Service"))
                .AsSelf()
                .InstancePerDependency();
        }
    }
}
