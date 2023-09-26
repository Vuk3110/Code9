using DependencyInjection.repository;
using DependencyInjection.service;

namespace DependencyInjection.command
{
    internal class DoneCommand : ICommand
    {

        private readonly IToDoService service;

        private readonly int id;

        public DoneCommand(int id)
        {
            service = new ToDoService(InMemoryRepository.GetInstance());
            this.id = id;
        }

        public void Execute()
        {
            service.MarkAsDone(id);
        }
    }
}
