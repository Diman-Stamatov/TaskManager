﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;
using TaskManager.Core;

namespace TaskManager.Commands
{
    public class ListTasksCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 1;

        public ListTasksCommand(IList<string> commandParameters, IRepository repository)
             : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            ValidateArgumentsCount(CommandParameters, ExpectedNumberOfArguments);
            string comand = CommandParameters[0];
            StringBuilder taskDisplay = new StringBuilder();

            if (comand == "Sorted")
            {
                List<ITask> tasks = Repository.Tasks.OrderBy(task => task.Title).ToList();
                foreach (ITask task in tasks)
                {
                    taskDisplay.AppendLine(task.ToString());
                    taskDisplay.AppendLine(GenerateString('.', 25));
                }
            }
            else
            {
                List<ITask> filterTasks = Repository.Tasks.Where(task => task.Title == comand).ToList();
                foreach (ITask task in filterTasks)
                {
                    taskDisplay.AppendLine(task.ToString());
                    taskDisplay.AppendLine(GenerateString('.', 25));
                }
            }
            return taskDisplay.ToString().Trim();
        }
    }
}
