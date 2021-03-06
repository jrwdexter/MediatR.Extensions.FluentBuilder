﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Autofac;

using Module = Autofac.Module;

namespace MediatR.Extensions.FluentBuilder
{
    public static class ContainerBuilderExtensions
    {
        public static void RegisterMediatR(this ContainerBuilder builder)
        {
            builder.RegisterType<Mediator>().As<IMediator>().InstancePerDependency();
            builder.Register<ServiceFactory>(context =>
            {
                var innerContext = context.Resolve<IComponentContext>();
                return type => innerContext.Resolve(type);
            }).InstancePerDependency();
        }

        public static void RegisterRequestModules(this ContainerBuilder builder, Assembly assembly)
        {
            foreach (var module in assembly.GetRequestModulesAs<Module>())
            {
                builder.RegisterModule(module);
            }
        }

        public static void RegisterNotificationModules(this ContainerBuilder builder, Assembly assembly)
        {
            foreach (var module in assembly.GetNotificationModulesAs<Module>())
            {
                builder.RegisterModule(module);
            }
        }
    }
}