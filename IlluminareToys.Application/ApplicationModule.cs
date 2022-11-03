﻿using Autofac;
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
            builder.RegisterAssemblyTypes(new[] { typeof(ApplicationModule).GetTypeInfo().Assembly })
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
            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(new[] { typeof(ApplicationModule) });
            }));

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();
        }
    }
}
