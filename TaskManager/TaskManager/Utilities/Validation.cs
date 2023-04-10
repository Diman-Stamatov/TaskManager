using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Exceptions;

namespace TaskManager.Utilities
{
    public class Validation
    {
       
        private const string InvalidStringPropertyMessage = "The {0}'s {1} must be between {2} and {3} characters long!";
        private const string InvalidArgumentsCountMessage = "Invalid number of arguments. Expected: {0}, Received: {1}.";

        public static void ValidateArgumentsCount(IEnumerable<String> arguments, int expectedArgumentsCount)
        {
            int actualArgumentsCount = arguments.Count();
            string errorMessage = String.Format(InvalidArgumentsCountMessage, expectedArgumentsCount, actualArgumentsCount);
            if (actualArgumentsCount != expectedArgumentsCount)
            {
                throw new InvalidUserInputException(errorMessage);
            }
        }

        public static void ValidateStringPropertyLength(string value, string className, string propertyName,
            int minLength, int maxLength)
        {
            string errorMessage = String.Format(InvalidStringPropertyMessage, className, propertyName,
                minLength, maxLength);
            ValidateStringNotNullOrEmpty(value, errorMessage);
            int valueLength = value.Length;
            if (valueLength < minLength || valueLength > maxLength)
            {
                throw new InvalidUserInputException(errorMessage);
            }
        }

        public static void ValidateStringNotNullOrEmpty(string value, string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(value) == true)
            {
                throw new InvalidUserInputException(errorMessage);
            }
        }

        public static void ValidateIntRange() => throw new NotImplementedException();
        public static void ValidateDuplicateTeam() => throw new NotImplementedException();
        public static void ValidateDuplicateMember() => throw new NotImplementedException();
        public static void ValidateAssigneStatus() => throw new NotImplementedException();

    }
}
