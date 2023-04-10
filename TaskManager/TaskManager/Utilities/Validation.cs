using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Exceptions;
using TaskManager.Models;
using TaskManager.Models.Contracts;

namespace TaskManager.Utilities
{
    public class Validation
    {
       
        private const string InvalidStringPropertyMessage = "The {0}'s {1} must be between {2} and {3} characters long!";
        private const string InvalidNumberPropertyMessage = "The {0}'s {1} must be between {2} and {3}!";
        private const string InvalidArgumentsCountMessage = "Invalid number of arguments. Expected: {0}, Received: {1}.";
        private const string DuplicateTeamMessage = "A team with the name \"{0}\" already exists!";
        private const string DuplicateTeamMemberMessage = "{0} is already part of team \"{1}\"!";
        private const string DuplicateEmployeeMessage = "{0} is already in the system!";
        private const string NotAssignedToTeamMessage = "{0} is not on team \"{1}\"!";


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

        public static void ValidateIntRange(int value, string className, string propertyName, int minValue, int maxValue)
        {
            string errorMessage = String.Format(InvalidNumberPropertyMessage, className, propertyName, minValue, maxValue);
            if (value < minValue || value > maxValue)
            {
                throw new InvalidUserInputException(errorMessage);
            }
        }
        public static void ValidateDuplicateTeam(string teamName, IList<ITeam> teams)
        {
            bool duplicateName = teams.Any(team=>team.Name == teamName);
            if (duplicateName == true)
            {
                string errorMessage = string.Format(DuplicateTeamMessage, teamName);
                throw new DuplicateEntryException(errorMessage);
            }
        }
        public static void ValidateDuplicateTeamMember(string memberName, IList<IMember> members)
        {
            bool duplicateName = members.Any(member => member.Name == memberName);
            if (duplicateName == true)
            {
                string errorMessage = string.Format(DuplicateTeamMemberMessage, memberName);
                throw new DuplicateEntryException(errorMessage);
            }
        }
        public static void ValidateDuplicateEmpoyee(string employeeName, IList<IMember> employees)
        {
            bool duplicateName = employees.Any(member => member.Name == employeeName);
            if (duplicateName == true)
            {
                string errorMessage = string.Format(DuplicateEmployeeMessage, employeeName);
                throw new DuplicateEntryException(errorMessage);
            }
        }
        public static void ValidateAssigneStatus(IMember member, string teamName)
        {
            if (member.IsAssigned == true)
            {
                string memberName = member.Name;
                string errorMessage = string.Format(NotAssignedToTeamMessage, memberName, teamName);
                throw new EntryNotFoundException(errorMessage);
            }
        }

    }
}
