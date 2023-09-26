﻿using Autofac;
using DependencyInjectionAutofac.service;

namespace DependencyInjectionAutofac.command
{
    internal class ListCommand : ICommand
    {
        private readonly IToDoService service;

        public ListCommand(IToDoService service)
        {
            this.service = service;
        }

        public void Execute()
        {
            var items = service.GetAll();
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
