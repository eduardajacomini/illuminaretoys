using Autofac;
using IlluminareToys.Infrastructure.Data;

namespace IlluminareToys.Web
{
    public class MainModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().InstancePerLifetimeScope();
            builder.RegisterModule(new InfrastructureDataModule());
            //builder.RegisterModule(new ApplicationModule());
        }
    }
}
