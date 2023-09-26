using DependencyInjection.service;

namespace DependencyInjection.command
{
    internal class AddCommand : ICommand
    {
        private readonly string title;
        private readonly string description;

        private IToDoService? _service;
        public IToDoService? Service { set { _service = value; } }

        public AddCommand(string title, string description)
        {
            this.title = title;
            this.description = description;
        }

        public void Execute()
        {
            _service?.Insert(title, description);
        }
    }
}
