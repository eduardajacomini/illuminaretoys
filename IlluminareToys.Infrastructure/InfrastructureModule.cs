using Autofac;
using System.Reflection;

namespace IlluminareToys.Infrastructure
{
    public class InfrastructureModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(new[] { typeof(InfrastructureModule).GetTypeInfo().Assembly })
              .AsImplementedInterfaces()
              .InstancePerLifetimeScope();
        }
    }
}
