using Autofac;
using System.Reflection;

namespace IlluminareToys.Infrastructure.Data
{
    public class InfrastructureDataModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(new[] { typeof(InfrastructureDataModule).GetTypeInfo().Assembly })
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
