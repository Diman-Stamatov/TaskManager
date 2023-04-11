using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Commands.Interfaces;
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

        protected bool ParseBoolParameter(string value, string parameterName)
        {
            if (bool.TryParse(value, out bool result))
            {
                return result;
            }
            throw new InvalidUserInputException($"Invalid value for {parameterName}. Should be either true or false.");
        }

        protected BugStatusType ParseBugStatusTypeParameter(string value, string parameterName)
        {
            if (Enum.TryParse(value, true, out BugStatusType result))
            {
                return result;
            }
            throw new InvalidUserInputException($"Invalid value for {parameterName}.");
            //Тук към съобщението да се добавят кои са вариантите на enum!
        }

        protected FeedbackStatusType ParseFeedbackStatusTypeParameter(string value, string parameterName)
        {
            if (Enum.TryParse(value, true, out FeedbackStatusType result))
            {
                return result;
            }
            throw new InvalidUserInputException($"Invalid value for {parameterName}.");
            //Тук към съобщението да се добавят кои са вариантите на enum!
        }

        protected PriorityType ParsePriorityTypeParameter(string value, string parameterName)
        {
            if (Enum.TryParse(value, true, out PriorityType result))
            {
                return result;
            }
            throw new InvalidUserInputException($"Invalid value for {parameterName}.");
            //Тук към съобщението да се добавят кои са вариантите на enum!
        }

        protected SeverityType ParseSeverityTypeParameter(string value, string parameterName)
        {
            if (Enum.TryParse(value, true, out SeverityType result))
            {
                return result;
            }
            throw new InvalidUserInputException($"Invalid value for {parameterName}.");
            //Тук към съобщението да се добавят кои са вариантите на enum!
        }

        protected SizeType ParseSizeTypeParameter(string value, string parameterName)
        {
            if (Enum.TryParse(value, true, out SizeType result))
            {
                return result;
            }
            throw new InvalidUserInputException($"Invalid value for {parameterName}.");
            //Тук към съобщението да се добавят кои са вариантите на enum!
        }

        protected StoryStatusType ParseStoryStatusTypeParameter(string value, string parameterName)
        {
            if (Enum.TryParse(value, true, out StoryStatusType result))
            {
                return result;
            }
            throw new InvalidUserInputException($"Invalid value for {parameterName}.");
            //Тук към съобщението да се добавят кои са вариантите на enum!
        }
    }
}
