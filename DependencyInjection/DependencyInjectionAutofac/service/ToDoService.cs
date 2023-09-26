using DependencyInjectionAutofac.model;
using DependencyInjectionAutofac.repository;

namespace DependencyInjectionAutofac.service
{
    internal class ToDoService : IToDoService
    {
        private readonly IRepository<ToDoItem> repository;

        public ToDoService(IRepository<ToDoItem> repository)
        {
            this.repository = repository;
            Console.WriteLine("Service Created");
        }

        public void Insert(string title, string description)
        {
            var toDoItem = new ToDoItem { Title = title, Description = description, Timestamp = DateTime.Now };
            repository.Insert(toDoItem);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public void UpdateDescription(int id, string description)
        {
            var toDoItem = repository.GetById(id);
            toDoItem.Description = description;
            repository.Update(toDoItem);
        }

        public void MarkAsDone(int id)
        {
            var toDoItem = repository.GetById(id);
            toDoItem.Done = true;
            repository.Update(toDoItem);
        }

        public IEnumerable<ToDoItem> GetAll()
        {
            return repository.GetAll();
        }
    }
}
