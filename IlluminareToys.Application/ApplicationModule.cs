using Autofac;
using AutoMapper;
using FluentValidation;
using IlluminareToys.Application.Workers;
using IlluminareToys.Domain.Inputs.Ages;
using IlluminareToys.Domain.Inputs.Groups;
using IlluminareToys.Domain.Inputs.Products;
using IlluminareToys.Domain.Inputs.Tags;
using IlluminareToys.Domain.Validators;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace IlluminareToys.Application
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(new[] { typeof(ApplicationModule).GetTypeInfo().Assembly })
              .AsImplementedInterfaces()
              .InstancePerLifetimeScope();

            RegisterMaps(builder);
            RegisterValidators(builder);
            //RegisterBackgroundServices(builder);
        }

        private void RegisterValidators(ContainerBuilder builder)
        {
            builder
                .RegisterType<CreateTagInputValidator>()
                .As<IValidator<CreateTagInput>>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<UpdateTagInputValidator>()
                .As<IValidator<UpdateTagInput>>()
                .InstancePerLifetimeScope();

            builder
               .RegisterType<DeleteTagInputValidator>()
               .As<IValidator<DeleteTagInput>>()
               .InstancePerLifetimeScope();

            builder
             .RegisterType<DeleteProductInputValidator>()
             .As<IValidator<DeleteProductInput>>()
             .InstancePerLifetimeScope();

            builder
             .RegisterType<AssociateTagsToProductInputValidator>()
             .As<IValidator<AssociateTagsToProductInput>>()
             .InstancePerLifetimeScope();

            builder
             .RegisterType<AddImageProductInputValidator>()
             .As<IValidator<AddImageProductInput>>()
             .InstancePerLifetimeScope();

            builder
             .RegisterType<CreateGroupInputValidator>()
             .As<IValidator<CreateGroupInput>>()
             .InstancePerLifetimeScope();

            builder
            .RegisterType<CreateTagsGroupsInputValidator>()
            .As<IValidator<CreateTagsGroupsInput>>()
            .InstancePerLifetimeScope();

            builder
            .RegisterType<UpdateGroupInputValidator>()
            .As<IValidator<UpdateGroupInput>>()
            .InstancePerLifetimeScope();

            builder
            .RegisterType<CreateAgeInputValidator>()
            .As<IValidator<CreateAgeInput>>()
            .InstancePerLifetimeScope();

            builder
           .RegisterType<UpdateAgeInputValidator>()
           .As<IValidator<UpdateAgeInput>>()
           .InstancePerLifetimeScope();

            builder
           .RegisterType<AssociateAgesToProductInputValidator>()
           .As<IValidator<AssociateAgesToProductInput>>()
           .InstancePerLifetimeScope();
        }

        private void RegisterMaps(ContainerBuilder builder)
        {
            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(new[] { typeof(ApplicationModule) });
            }));

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();
        }

        private void RegisterBackgroundServices(ContainerBuilder builder)
        {
            builder.RegisterType<SyncProductsWorker>()
                    .As<IHostedService>()
                    .SingleInstance();
        }
    }
}
