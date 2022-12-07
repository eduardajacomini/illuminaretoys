using Autofac;
using IlluminareToys.Application;
using IlluminareToys.Infrastructure;
using IlluminareToys.Infrastructure.Bling;
using IlluminareToys.Infrastructure.Data;

namespace IlluminareToys.Web
{
    public class MainModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().InstancePerLifetimeScope();
            builder.RegisterModule(new InfrastructureDataModule());
            builder.RegisterModule(new InfrastructureBlingModule());
            builder.RegisterModule(new InfrastructureModule());
            builder.RegisterModule(new ApplicationModule());
        }
    }
}
