using DependencyInjection.command;
using DependencyInjection.model;
using DependencyInjection.repository;
using DependencyInjection.service;

namespace DependencyInjection
{
    internal class Application
    {
        private static readonly string menu = @"Insert command (ADD, DONE, LIST, DELETE)";
        private readonly IToDoService service;

        public Application()
        {
            var repository = InMemoryRepository.GetInstance();

            var service = new ToDoService(repository);
            this.service = service;
        }

        public void Run()
        {

            var invoker = new CommandInvoker();

            while (true)
            {
                Console.WriteLine(menu);
                Console.Write(">> ");
                var command = Console.ReadLine();
                if (command == null || command.Trim() == "")
                {
                    continue;
                }
                try
                {
                    switch (command.ToUpper())
                    {
                        case "ADD":
                            {
                                Console.Write("title: ");
                                var title = Console.ReadLine();

                                Console.Write("description: ");
                                var description = Console.ReadLine();

                                var addCommand = new AddCommand(title!, description!)
                                {
                                    Service = service
                                };

                                invoker.SetCommand(addCommand);
                                invoker.ExecuteCommand();
                                break;
                            }
                        case "DONE":
                            {
                                Console.Write("id: ");
                                _ = int.TryParse(Console.ReadLine(), out int id);

                                var doneCommand = new DoneCommand(id);
                                invoker.SetCommand(doneCommand);
                                invoker.ExecuteCommand();
                                break;
                            }
                        case "LIST":
                            {
                                var listCommand = new ListCommand(service);
                                invoker.SetCommand(listCommand);
                                invoker.ExecuteCommand();
                                break;
                            }
                        case "DELETE":
                            {
                                Console.Write("id: ");
                                _ = int.TryParse(Console.ReadLine(), out int id);

                                var deleteCommand = new DeleteCommand(id);
                                invoker.SetCommand(deleteCommand);
                                invoker.ExecuteCommand();
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Command not found");
                                break;
                            }

                    }
                }
                catch (CustomException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception)
                {
                    Console.WriteLine("OOPS");
                }

            }
        }

    }
}
