namespace DependencyInjection.command
{
    internal class CommandInvoker
    {
        private ICommand? _command;

        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        public void ExecuteCommand()
        {
            if (_command != null)
            {
                _command.Execute();
            }
            else
            {
                throw new InvalidOperationException();
            }

        }
    }
}
