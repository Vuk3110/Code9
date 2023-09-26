using DependencyInjection.repository;
using DependencyInjection.service;

namespace DependencyInjection.command
{
    internal class DeleteCommand : ICommand
    {
        private readonly IToDoService service;

        private readonly int id;

        public DeleteCommand(int id)
        {
            service = new ToDoService(InMemoryRepository.GetInstance());
            this.id = id;
        }

        public void Execute()
        {
            service.Delete(id);
        }
    }
}
