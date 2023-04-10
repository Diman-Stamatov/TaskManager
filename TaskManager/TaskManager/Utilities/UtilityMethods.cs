using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;
using TaskManager.Models.Enums;

namespace TaskManager.Utilities
{
    public static class UtilityMethods
    {
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
        public static string GetMethodName([CallerMemberName] string callerName = null)
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

        public static string StringGenerator(char simbol,int num)
        {
            return new string(simbol, num);
        }
    }
}
