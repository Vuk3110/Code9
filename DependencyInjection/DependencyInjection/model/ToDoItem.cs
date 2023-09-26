namespace DependencyInjection.model
{
    internal class ToDoItem
    {
        public int Id { get; set; } = 0;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public bool Done { get; set; } = false;

        public override string ToString()
        {
            return $"Id: {Id} | Title: {Title} | Description: {Description} | Time: {Timestamp} | Done: {Done}";
        }

        public static ToDoItem FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            return new ToDoItem
            {
                Id = int.Parse(values[0]),
                Title = values[1],
                Description = values[2],
                Timestamp = DateTime.Parse(values[3]),
                Done = bool.Parse(values[4])
            };
        }

        public static string ToCsv(ToDoItem item)
        {
            return $"{item.Id},{item.Title},{item.Description},{item.Timestamp},{item.Done}";
        }
    }
}
