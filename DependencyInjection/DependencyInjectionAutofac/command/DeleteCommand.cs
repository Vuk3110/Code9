using DependencyInjectionAutofac.repository;
using DependencyInjectionAutofac.service;

namespace DependencyInjectionAutofac.command
{
    internal class DeleteCommand : ICommand
    {
        private readonly IToDoService service;

        private readonly int id;

        public DeleteCommand(IToDoService service, int id)
        {
            this.service = service;
            this.id = id;
        }

        public void Execute()
        {
            service.Delete(id);
        }
    }
}
