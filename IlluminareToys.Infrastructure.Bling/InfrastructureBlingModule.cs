using Autofac;
using System.Reflection;

namespace IlluminareToys.Infrastructure.Bling
{
    public class InfrastructureBlingModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(new[] { typeof(InfrastructureBlingModule).GetTypeInfo().Assembly })
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
