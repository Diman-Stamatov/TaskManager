﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Commands.Contracts;
using TaskManager.Core.Interfaces;
using TaskManager.Exceptions;
using TaskManager.Models.Enums;

namespace TaskManager.Commands
{
    public abstract class BaseCommand : ICommand
    {
        protected BaseCommand(IRepository repository)
            : this(new List<string>(), repository)
        {
        }

        protected BaseCommand(IList<string> commandParameters, IRepository repository)
        {
            this.CommandParameters = commandParameters;
            this.Repository = repository;
        }

        public abstract string Execute();

        protected IRepository Repository { get; }

        protected IList<string> CommandParameters { get; }

        protected int ParseIntParameter(string value, string parameterName)
        {
            if (int.TryParse(value, out int result))
            {
                return result;
            }
            throw new InvalidUserInputException($"Invalid value for {parameterName}. Should be an integer number.");
        }



        protected PriorityType ParsePriorityTypeParameter(string value, string parameterName)
        {
            if (Enum.TryParse(value, true, out PriorityType result))
            {
                return result;
            }
            throw new InvalidUserInputException($"Invalid input for {parameterName}! Please choose one of the following: {GetPriorityTypeNames()}");
        }

        protected SeverityType ParseSeverityTypeParameter(string value, string parameterName)
        {
            if (Enum.TryParse(value, true, out SeverityType result))
            {
                return result;
            }
            throw new InvalidUserInputException($"Invalid input for {parameterName}! Please choose one of the following: {GetSeverityTypeNames()}");
        }

        protected SizeType ParseSizeTypeParameter(string value, string parameterName)
        {
            if (Enum.TryParse(value, true, out SizeType result))
            {
                return result;
            }
            throw new InvalidUserInputException($"Invalid input for {parameterName}! Please choose one of the following: {GetSizeTypeNames()}");
        }

        protected void ValidateEnumChangeInput(string changeDirection)
        {
            string expectedAdvanceParameter = "advance"; 
            string expectedRevertParameter = "revert";

            if (changeDirection != expectedAdvanceParameter && changeDirection != expectedRevertParameter)
            {
                string errorMessage = $"Please choose either the \"{expectedRevertParameter}\" " +
                    $"or \"{expectedAdvanceParameter}\" clarification for this command!";
                throw new InvalidUserInputException(errorMessage);
            }
        }
    }
}
