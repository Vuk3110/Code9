using DependencyInjectionAutofac.command;
using DependencyInjectionAutofac.model;
using DependencyInjectionAutofac.service;

namespace DependencyInjectionAutofac
{
    internal class Application
    {
        private static readonly string menu = @"Insert command (ADD, DONE, LIST, DELETE)";

        private readonly IToDoService service;
        private readonly ListCommand listCommand;


        public Application(IToDoService service, ListCommand listCommand)
        {
            this.service = service;
            this.listCommand = listCommand;
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

                                var addCommand = new AddCommand(title!, description!);
                                invoker.SetCommand(addCommand);
                                invoker.ExecuteCommand();
                                break;
                            }
                        case "DONE":
                            {
                                Console.Write("id: ");
                                _ = int.TryParse(Console.ReadLine(), out int id);

                                var doneCommand = new DoneCommand(service, id);
                                invoker.SetCommand(doneCommand);
                                invoker.ExecuteCommand();
                                break;
                            }
                        case "LIST":
                            {
                                invoker.SetCommand(listCommand);
                                invoker.ExecuteCommand();
                                break;
                            }
                        case "DELETE":
                            {
                                Console.Write("id: ");
                                _ = int.TryParse(Console.ReadLine(), out int id);

                                var deleteCommand = new DeleteCommand(service, id);
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
