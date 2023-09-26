using Autofac;
using DependencyInjectionAutofac.service;

namespace DependencyInjectionAutofac
{
    internal class Program
    {
        static void Main()
        {
            var container = ContainerConfig.GetContainer();
            using var scope = container.BeginLifetimeScope();

            var application = scope.Resolve<Application>();
            application.Run();
        }
    }
}