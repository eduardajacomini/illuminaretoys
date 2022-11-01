using Autofac;
using AutoMapper;
using FluentValidation;
using IlluminareToys.Domain.Inputs;
using IlluminareToys.Domain.Validators;
using System.Reflection;

namespace IlluminareToys.Application
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(ApplicationModule).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(new[] { assembly })
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();



            RegisterMaps(builder);
            RegisterValidators(builder);
        }

        private void RegisterValidators(ContainerBuilder builder)
        {
            builder
                .RegisterType<CreateTagInputValidator>()
                .As<IValidator<CreateTagInput>>()
                .SingleInstance();
        }

        private void RegisterMaps(ContainerBuilder builder)
        {
            var assemblyNames = Assembly.GetExecutingAssembly().GetReferencedAssemblies();
            var assembliesTypes = assemblyNames
                .Where(a => a.Name.Equals("Com.Davidsekar.Models", StringComparison.OrdinalIgnoreCase))
                .SelectMany(an => Assembly.Load(an).GetTypes())
                .Where(p => typeof(Profile).IsAssignableFrom(p) && p.IsPublic && !p.IsAbstract)
                .Distinct();

            var autoMapperProfiles = assembliesTypes
                .Select(p => (Profile)Activator.CreateInstance(p)).ToList();

            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                foreach (var profile in autoMapperProfiles)
                {
                    cfg.AddProfile(profile);
                }
            }));

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();
        }
    }
}
