﻿global using static TaskManager.Utilities.UtilityMethods;
global using static TaskManager.Utilities.Validation;
global using TaskManager.Exceptions;
global using TaskManager.Models.Contracts;
global using TaskManager.Models;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;
using TaskManager.Commands.Contracts;


namespace TaskManager.Core
{
    public class Engine : IEngine
    {
        private const string TerminationCommand = "Exit";
        private const string EmptyCommandError = "Command cannot be empty.";
        private const string ReportSeparator = "####################";

        private readonly ICommandFactory commandFactory;

        public Engine(ICommandFactory commandFactory)
        {
            this.commandFactory = commandFactory;
        }
        public void Start()
        {
            while (true)
            {
                try
                {
                    string inputLine = Console.ReadLine().Trim();

                    if (inputLine == string.Empty)
                    {
                        Console.WriteLine(EmptyCommandError);
                        continue;
                    }

                    if (inputLine.Equals(TerminationCommand, StringComparison.InvariantCultureIgnoreCase))
                    {
                        break;
                    }
                    // ToDo Не е ок.
                    ICommand command = (ICommand)commandFactory.Create(inputLine);
                    string result = command.Execute();
                    Console.WriteLine(result.Trim());
                    Console.WriteLine(ReportSeparator);
                }
                catch (Exception ex)
                {

                    //ToDo
                    if (!string.IsNullOrEmpty(ex.Message))
                    {
                        Console.WriteLine(ex.Message);
                    }
                    else
                    {
                        Console.WriteLine(ex);
                    }
                }
            }
        }
    }
}
