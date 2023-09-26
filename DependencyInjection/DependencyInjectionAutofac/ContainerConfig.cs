using Autofac;
using DependencyInjectionAutofac.command;
using DependencyInjectionAutofac.model;
using DependencyInjectionAutofac.repository;
using DependencyInjectionAutofac.service;

namespace DependencyInjectionAutofac
{
    internal class ContainerConfig
    {
        private static IContainer? container = null;

        private static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ToDoService>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<InMemoryRepository>().As<IRepository<ToDoItem>>().SingleInstance();

            builder.RegisterType<ListCommand>();
            builder.RegisterType<Application>().AsSelf().InstancePerLifetimeScope();

            return builder.Build();
        }

        public static IContainer GetContainer()
        {
            container ??= Configure();
            return container;
        }
    }
}
