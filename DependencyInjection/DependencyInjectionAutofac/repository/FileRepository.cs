using DependencyInjectionAutofac.model;

namespace DependencyInjectionAutofac.repository
{
    internal class FileRepository : IRepository<ToDoItem>
    {
        private readonly string filename = "repo.txt";
        private int id = 1;

        public FileRepository()
        {
            var all = GetAll();
            var last = all.LastOrDefault();
            if (last != null)
            {
                id = last.Id + 1;
            }

            Console.WriteLine("FileRepository Created");
        }

        public FileRepository(string filename) : base()
        {
            this.filename = filename;
        }

        public IEnumerable<ToDoItem> GetAll()
        {
            if (File.Exists(filename))
            {
                return File.ReadAllLines(filename).Select(line => ToDoItem.FromCsv(line)).ToList();
            }
            return Enumerable.Empty<ToDoItem>();
        }

        public ToDoItem GetById(int id)
        {
            var items = GetAll().ToList();
            ToDoItem? toDoItem = items.Find(item => item.Id == id);
            if (toDoItem != null)
                return toDoItem;

            throw new CustomException($"Object with id [{id}] not found");
        }

        public void Insert(ToDoItem obj)
        {
            obj.Id = id;
            File.AppendAllLines(filename, new string[]{ ToDoItem.ToCsv(obj) });
            ++id;
        }

        public void Update(ToDoItem obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            var items = GetAll().ToList();

            items.RemoveAll(i => i.Id == item.Id);
            File.WriteAllLines(filename, items.Select(item => ToDoItem.ToCsv(item)));
        }

        public void Save()
        {
        }
    }
}
