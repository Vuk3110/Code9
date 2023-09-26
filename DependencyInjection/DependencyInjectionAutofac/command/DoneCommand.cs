using DependencyInjectionAutofac.repository;
using DependencyInjectionAutofac.service;

namespace DependencyInjectionAutofac.command
{
    internal class DoneCommand : ICommand
    {

        private readonly IToDoService service;

        private readonly int id;

        public DoneCommand(IToDoService service, int id)
        {
            this.service = service;
            this.id = id;
        }

        public void Execute()
        {
            service.MarkAsDone(id);
        }
    }
}
