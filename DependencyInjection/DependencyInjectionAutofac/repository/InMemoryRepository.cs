using DependencyInjectionAutofac.model;

namespace DependencyInjectionAutofac.repository
{
    internal class InMemoryRepository : IRepository<ToDoItem>
    {
        private readonly List<ToDoItem> items = new();
        private int id = 1;

        public InMemoryRepository() 
        {
            Console.WriteLine("InMemoryRepository Created");
        }

        public IEnumerable<ToDoItem> GetAll()
        {
            return items;
        }

        public ToDoItem GetById(int id)
        {
            ToDoItem? toDoItem = items.Find((item) => item.Id == id);
            if (toDoItem != null)
                return toDoItem;

            throw new CustomException($"Object with id [{id}] not found");
        }

        public void Insert(ToDoItem obj)
        {
            obj.Id = id;
            items.Add(obj);
            ++id;
        }

        public void Update(ToDoItem obj)
        {
            var toDoItem = GetById(obj.Id);
            if (toDoItem != null)
            {
                toDoItem.Description = obj.Description;
                toDoItem.Title = obj.Title;
                toDoItem.Done = obj.Done;
            }
        }

        public void Delete(int id)
        {
            ToDoItem toDoItem = GetById(id);
            items.Remove(toDoItem);
        }

        public void Save()
        {
        }

    }
}
