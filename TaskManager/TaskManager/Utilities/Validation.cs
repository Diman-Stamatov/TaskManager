using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Exceptions;
using TaskManager.Models;
using TaskManager.Models.Contracts;
using TaskManager.Models.Enums;

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
        private const string CannotAdvanceFurtherMessage = "Cannot advance the {0} any further, it is already set to {1}!";
        private const string CannotRevertFurtherMessage = "Cannot revert the {0} any further, it is already set to {1}!";
        private const string TaskAlreadyAsssignedMessage = "The task is already assigned to {0}!";
        private const string TaskTakenMessage = "The task is already being taken care of by {0}!";


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
        public static void ValidateAssignedStatus(IMember member, string teamName)
        {
            if (member.IsAssigned == true)
            {
                string memberName = member.Name;
                string errorMessage = string.Format(NotAssignedToTeamMessage, memberName, teamName);
                throw new EntryNotFoundException(errorMessage);
            }
        }
        public static void ValidateAssignee(IMember currentAssignee, IMember newAssignee)
        {
            string currentName = currentAssignee.Name;
            string newName = newAssignee.Name;

            if (currentName == newName)
            {
                string errorMessage = string.Format(TaskAlreadyAsssignedMessage, currentName);
                throw new InvalidUserInputException(errorMessage);
            }
            else if (currentAssignee != null)
            {
                string errorMessage = string.Format(TaskTakenMessage, currentName);
                throw new InvalidUserInputException(errorMessage);
            }
        }
        public static void ValidateAdvanceMethod(Type type, int currentValue, string propertyName)
        {
            int maxValue = 0;
            string maxValueName = "";
            if (type == typeof(BugStatusType))
            {
                maxValue = Enum.GetValues(typeof(BugStatusType)).Cast<int>().Max();
                maxValueName = ((BugStatusType)maxValue).ToString();
                
            }
            else if (type == typeof(FeedbackStatusType))
            {
                maxValue = Enum.GetValues(typeof(FeedbackStatusType)).Cast<int>().Max();
                maxValueName = ((FeedbackStatusType)maxValue).ToString();
            }
            else if (type == typeof(PriorityType))
            {
                maxValue = Enum.GetValues(typeof(PriorityType)).Cast<int>().Max();
                maxValueName = ((PriorityType)maxValue).ToString();
            }
            else if (type == typeof(SeverityType))
            {
                maxValue = Enum.GetValues(typeof(SeverityType)).Cast<int>().Max();
                maxValueName = ((SeverityType)maxValue).ToString();

            }
            else if (type == typeof(SizeType))
            {
                maxValue = Enum.GetValues(typeof(SizeType)).Cast<int>().Max();
                maxValueName = ((SizeType)maxValue).ToString();
            }
            else if (type == typeof(StoryStatusType))
            {
                maxValue = Enum.GetValues(typeof(StoryStatusType)).Cast<int>().Max();
                maxValueName = ((StoryStatusType)maxValue).ToString();
            }

            if (currentValue == maxValue)
            {
                string errorMessage = string.Format(CannotAdvanceFurtherMessage, propertyName, maxValueName);
                throw new InvalidUserInputException(errorMessage);
            }
        }

        public static void ValidateRevertMethod(Type type, int currentValue, string propertyName)
        {
            int minValue = 0;
            string maxValueName = "";
            if (type == typeof(BugStatusType))
            {
                minValue = Enum.GetValues(typeof(BugStatusType)).Cast<int>().Min();
                maxValueName = ((BugStatusType)minValue).ToString();

            }
            else if (type == typeof(FeedbackStatusType))
            {
                minValue = Enum.GetValues(typeof(FeedbackStatusType)).Cast<int>().Min();
                maxValueName = ((FeedbackStatusType)minValue).ToString();
            }
            else if (type == typeof(PriorityType))
            {
                minValue = Enum.GetValues(typeof(PriorityType)).Cast<int>().Min();
                maxValueName = ((PriorityType)minValue).ToString();
            }
            else if (type == typeof(SeverityType))
            {
                minValue = Enum.GetValues(typeof(SeverityType)).Cast<int>().Min();
                maxValueName = ((SeverityType)minValue).ToString();

            }
            else if (type == typeof(SizeType))
            {
                minValue = Enum.GetValues(typeof(SizeType)).Cast<int>().Min();
                maxValueName = ((SizeType)minValue).ToString();
            }
            else if (type == typeof(StoryStatusType))
            {
                minValue = Enum.GetValues(typeof(StoryStatusType)).Cast<int>().Min();
                maxValueName = ((StoryStatusType)minValue).ToString();
            }

            if (currentValue == minValue)
            {
                string errorMessage = string.Format(CannotRevertFurtherMessage, propertyName, maxValueName);
                throw new InvalidUserInputException(errorMessage);
            }
        }

    }
}
