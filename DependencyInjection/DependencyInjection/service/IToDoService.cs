using DependencyInjection.model;

namespace DependencyInjection.service
{
    internal interface IToDoService
    {
        void Insert(string title, string description);
        void UpdateDescription(int id, string description);
        void MarkAsDone(int id);
        void Delete(int id);
        IEnumerable<ToDoItem> GetAll();
    }
}
