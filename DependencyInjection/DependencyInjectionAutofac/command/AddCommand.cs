using Autofac;
using DependencyInjectionAutofac.service;

namespace DependencyInjectionAutofac.command
{
    internal class AddCommand : ICommand
    {
        private readonly IToDoService service = ContainerConfig.GetContainer().Resolve<IToDoService>();

        private readonly string title;
        private readonly string description;

        public AddCommand(string title, string description)
        {
            this.title = title;
            this.description = description;
        }

        public void Execute()
        {
            service.Insert(title, description);
        }
    }
}
