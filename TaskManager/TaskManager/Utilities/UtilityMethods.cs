global using static TaskManager.Utilities.UtilityMethods;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TaskManager.Exceptions;
using TaskManager.Models;
using TaskManager.Models.Contracts;
using TaskManager.Models.Enums;

namespace TaskManager.Utilities
{
    public static class UtilityMethods
    {
        private const string AdvanceMethodLogMessage = "The {0} of {1} ID {2} was advanced from {3} to {4} by {5}.";
        private const string RevertMethodLogMessage = "The {0} of {1} ID {2} was reverted from {3} to {4} by {5}.";
        private const string AdvanceMethodLogMessageNoAssignee = "The {0} of {1} ID {2} was advanced from {3} to {4}.";
        private const string RevertMethodLogMessageNoAssignee = "The {0} of {1} ID {2} was reverted from {3} to {4}.";

        public static string GenerateAdvanceMethodMessage(Type type, int currentValue, string propertyName,
            string className, int id, string assigneeName)
        {
            int nextValue = currentValue + 1;
            string nextValueName = "";
            string currentValueName = "";
            if (type == typeof(BugStatusType))
            {
                nextValueName = ((BugStatusType)nextValue).ToString();
                currentValueName = ((BugStatusType)currentValue).ToString();
            }
            else if (type == typeof(FeedbackStatusType))
            {
                nextValueName = ((FeedbackStatusType)nextValue).ToString();
                currentValueName = ((FeedbackStatusType)currentValue).ToString();
            }
            else if (type == typeof(PriorityType))
            {
                nextValueName = ((PriorityType)nextValue).ToString();
                currentValueName = (((PriorityType)currentValue).ToString());
            }
            else if (type == typeof(SeverityType))
            {
                nextValueName = ((SeverityType)nextValue).ToString();
                currentValueName = ((SeverityType)currentValue).ToString();
            }
            else if (type == typeof(SizeType))
            {
                nextValueName = ((SizeType)nextValue).ToString();
                currentValueName = ((SizeType)currentValue).ToString();
            }
            else if (type == typeof(StoryStatusType))
            {
                nextValueName = ((StoryStatusType)nextValue).ToString();
                currentValueName = ((StoryStatusType)currentValue).ToString();
            }
            string logMessage = string.Format(AdvanceMethodLogMessage, propertyName, className, id,
                currentValueName, nextValueName, assigneeName);
            return logMessage;
        }

        public static string GenerateRevertMethodMessage(Type type, int currentValue, string propertyName,
            string className, int id, string assigneeName)
        {
            int nextValue = currentValue - 1;
            string nextValueName = "";
            string currentValueName = "";
            if (type == typeof(BugStatusType))
            {
                nextValueName = ((BugStatusType)nextValue).ToString();
                currentValueName = ((BugStatusType)currentValue).ToString();
            }
            else if (type == typeof(FeedbackStatusType))
            {
                nextValueName = ((FeedbackStatusType)nextValue).ToString();
                currentValueName = ((FeedbackStatusType)currentValue).ToString();
            }
            else if (type == typeof(PriorityType))
            {
                nextValueName = ((PriorityType)nextValue).ToString();
                currentValueName = (((PriorityType)currentValue).ToString());
            }
            else if (type == typeof(SeverityType))
            {
                nextValueName = ((SeverityType)nextValue).ToString();
                currentValueName = ((SeverityType)currentValue).ToString();
            }
            else if (type == typeof(SizeType))
            {
                nextValueName = ((SizeType)nextValue).ToString();
                currentValueName = ((SizeType)currentValue).ToString();
            }
            else if (type == typeof(StoryStatusType))
            {
                nextValueName = ((StoryStatusType)nextValue).ToString();
                currentValueName = ((StoryStatusType)currentValue).ToString();
            }
            string logMessage = string.Format(RevertMethodLogMessage, propertyName, className, id,
                currentValueName, nextValueName, assigneeName);
            return logMessage;
        }

        public static string GenerateAdvanceMethodMessage(Type type, int currentValue, string propertyName, string className, int id)
        {
            int nextValue = currentValue + 1;
            string nextValueName = "";
            string currentValueName = "";
            if (type == typeof(BugStatusType))
            {
                nextValueName = ((BugStatusType)nextValue).ToString();
                currentValueName = ((BugStatusType)currentValue).ToString();
            }
            else if (type == typeof(FeedbackStatusType))
            {
                nextValueName = ((FeedbackStatusType)nextValue).ToString();
                currentValueName = ((FeedbackStatusType)currentValue).ToString();
            }
            else if (type == typeof(PriorityType))
            {
                nextValueName = ((PriorityType)nextValue).ToString();
                currentValueName = (((PriorityType)currentValue).ToString());
            }
            else if (type == typeof(SeverityType))
            {
                nextValueName = ((SeverityType)nextValue).ToString();
                currentValueName = ((SeverityType)currentValue).ToString();
            }
            else if (type == typeof(SizeType))
            {
                nextValueName = ((SizeType)nextValue).ToString();
                currentValueName = ((SizeType)currentValue).ToString();
            }
            else if (type == typeof(StoryStatusType))
            {
                nextValueName = ((StoryStatusType)nextValue).ToString();
                currentValueName = ((StoryStatusType)currentValue).ToString();
            }
            string logMessage = string.Format(AdvanceMethodLogMessageNoAssignee, propertyName, className, id, currentValueName, nextValueName);
            return logMessage;
        }

        public static string GenerateRevertMethodMessage(Type type, int currentValue, string propertyName, string className, int id)
        {
            int nextValue = currentValue - 1;
            string nextValueName = "";
            string currentValueName = "";
            if (type == typeof(BugStatusType))
            {
                nextValueName = ((BugStatusType)nextValue).ToString();
                currentValueName = ((BugStatusType)currentValue).ToString();
            }
            else if (type == typeof(FeedbackStatusType))
            {
                nextValueName = ((FeedbackStatusType)nextValue).ToString();
                currentValueName = ((FeedbackStatusType)currentValue).ToString();
            }
            else if (type == typeof(PriorityType))
            {
                nextValueName = ((PriorityType)nextValue).ToString();
                currentValueName = (((PriorityType)currentValue).ToString());
            }
            else if (type == typeof(SeverityType))
            {
                nextValueName = ((SeverityType)nextValue).ToString();
                currentValueName = ((SeverityType)currentValue).ToString();
            }
            else if (type == typeof(SizeType))
            {
                nextValueName = ((SizeType)nextValue).ToString();
                currentValueName = ((SizeType)currentValue).ToString();
            }
            else if (type == typeof(StoryStatusType))
            {
                nextValueName = ((StoryStatusType)nextValue).ToString();
                currentValueName = ((StoryStatusType)currentValue).ToString();
            }
            string logMessage = string.Format(RevertMethodLogMessageNoAssignee, propertyName, className, id,
                currentValueName, nextValueName);
            return logMessage;
        }

        public static string Message(IComment comment)
        {
            return $"Author: {comment.Author} added comment: \"{comment.Content}\"";
        }
        public static string Message(string type, string assigneeName, string title, int id, bool isAssigned)
        {
            string action;
            if (isAssigned == true)
            {
                action = "assigned to";
                
            }
            else
            {
                action = "unassigned from";
            }
            return $"{assigneeName} was {action} {type} with title:{title} and Id:{id}";
        }
        public static string Message(string type, IMember member, string title, int id)
        {
            return $"{member.Name} was assigned to {type} with title:{title} and Id:{id}";
        }
        public static string Message(string type, int id, string title, PriorityType priority, SizeType size)
        {
            return $"{type} with title: \"{title}\" ID: {id} PriorityType: {priority} SizeType {size} was created";
        }
        public static string Message(string type, int id, string title, PriorityType priority, SeverityType severity)
        {
            return $"{type} with title: \"{title}\" ID: {id} PriorityType: {priority} SizeType {severity} was created";
        }
        public static string Message(string type, int id, string title, int rating)
        {
            return $"{type} with title: \"{title}\" ID: {id} and raiting: {rating} was created";
        }
        public static string TrimAdvance(this string methodName)
        {
            int toSkip = "Advance".Length;
            string fieldName = string.Join("", methodName.Skip(toSkip));
            return fieldName;
        }
        public static string TrimRevert(this string methodName)
        {
            int toSkip = "Revert".Length;
            string fieldName = string.Join("", methodName.Skip(toSkip));
            return fieldName;
        }
        public static string GetMethodName([CallerMemberName] string callerName = "")
        {
            return callerName;
        }
        public static string GetBugStatusTypeNames()
        {
            string commandNames = String.Join(", ", Enum.GetNames(typeof(BugStatusType)));
            return commandNames;
        }
        public static string GetFeedbackStatusTypeNames()
        {
            string commandNames = String.Join(", ", Enum.GetNames(typeof(FeedbackStatusType)));
            return commandNames;
        }
        public static string GetPriorityTypeNames()
        {
            string commandNames = String.Join(", ", Enum.GetNames(typeof(PriorityType)));
            return commandNames;
        }
        public static string GetSeverityTypeNames()
        {
            string commandNames = String.Join(", ", Enum.GetNames(typeof(SeverityType)));
            return commandNames;
        }
        public static string GetSizeTypeNames()
        {
            string commandNames = String.Join(", ", Enum.GetNames(typeof(SizeType)));
            return commandNames;
        }
        public static string GetStoryStatusTypeNames()
        {
            string commandNames = String.Join(", ", Enum.GetNames(typeof(StoryStatusType)));
            return commandNames;
        }
        public static string GenerateString(char simbol, int num)
        {
            return new string(simbol, num);
        }
        public static string AddDate(string newEvent)
        {
            return $"{newEvent} : [{DateTime.Now.ToString("yyyyMMdd|HH:mm:ss.ffff")}]";
        }
    }
}
