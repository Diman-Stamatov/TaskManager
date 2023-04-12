using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.Models.Enums;
using TaskManager.Models.Contracts;
using static TaskManager.Utilities.UtilityMethods;
using static TaskManager.Utilities.Validation;
using System.Reflection.Metadata;
using System.Xml.Linq;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    public class Bug : Task, IBug
    {
        private const BugStatusType InitialBugStatus = BugStatusType.Active;

        private List<string> stepsToReproduce;
        private PriorityType priority;         
        private BugStatusType status;
        private SeverityType severity;
        private IMember assignee;

        public Bug(
            int id,
            string title, 
            string description, 
            PriorityType priority,  
            SeverityType severity) 
            : base(id, title, description)
        {
            Priority = priority;
            Status = InitialBugStatus;
            Severity = severity;
            stepsToReproduce = new List<string>();
        }

        public PriorityType Priority
        {
            get => priority;
            private set
            {
                priority = value;
            }
        }

        public BugStatusType Status
        {
            get => status;
            private set
            {
                status = value;               
            }
        }

        public SeverityType Severity
        {
            get => severity;
            private set
            {
                severity = value;
            }
        }

        public IMember Assignee
        {
            get =>assignee;
            set
            {
                ValidateAssignee(assignee, value);
                assignee = value;               
            }
        }

        public IList<string> StepsToReproduce 
        { 
            get => new List<string>(stepsToReproduce); 
        }

        public void AddStepsToReproduce(string stepToReproduce)
        {
            //това ще отиде за валидация в "command"
            ValidateStringNotNullOrEmpty(
                stepToReproduce, 
                "Step to reproduce can not be null or empty.");

            stepsToReproduce.Add(stepToReproduce);

            LogChanges(
                $"'{stepsToReproduce}' added to 'Steps to reproduce'");
        }

        public void AdvancePriority()
        {
            var type = Priority.GetType();
            int currentValue = (int)Priority;
            string propertyName = GetMethodName().TrimAdvance();

            ValidateAdvanceMethod(type, currentValue, propertyName);

            string className = GetType().Name;
            int taskId = Id;
            LogChanges(GenerateAdvanceMethodMessage(type, currentValue, propertyName, className, taskId));
            priority++;
        }

        public void RevertPriority()
        {
            var type = Priority.GetType();
            int currentValue = (int)Priority;
            string propertyName = GetMethodName().TrimRevert();

            ValidateRevertMethod(type, currentValue, propertyName);

            string className = GetType().Name;
            int taskId = Id;
            LogChanges(GenerateRevertMethodMessage(type, currentValue, propertyName, className, taskId));
            priority--;
        }
        public override void AdvanceStatus()
        {
            var type = Status.GetType();
            int currentValue = (int)Status;
            string propertyName = GetMethodName().TrimAdvance();

            ValidateAdvanceMethod(type, currentValue, propertyName);

            string className = GetType().Name;
            int taskId = Id;
            LogChanges(GenerateAdvanceMethodMessage(type, currentValue, propertyName, className, taskId));
            Status++;
        }

        public override void RevertStatus()
        {
            var type = status.GetType();
            int currentValue = (int)Status;
            string propertyName = GetMethodName().TrimRevert();

            ValidateRevertMethod(type, currentValue, propertyName);

            string className = GetType().Name;
            int taskId = Id;
            LogChanges(GenerateRevertMethodMessage(type, currentValue, propertyName, className, taskId));
            status--;
        }

        public void AdvanceSeverity()
        {
            var type = Severity.GetType();
            int currentValue = (int)Severity;
            string propertyName = GetMethodName().TrimAdvance();

            ValidateAdvanceMethod(type, currentValue, propertyName);

            string className = GetType().Name;
            int taskId = Id;
            LogChanges(GenerateAdvanceMethodMessage(type, currentValue, propertyName, className, taskId));
            Severity++;
        }

        public void RevertSeverity()
        {
            var type = Severity.GetType();
            int currentValue = (int)Severity;
            string propertyName = GetMethodName().TrimRevert();

            ValidateRevertMethod(type, currentValue, propertyName);

            string className = GetType().Name;
            int taskId = Id;
            LogChanges(GenerateRevertMethodMessage(type, currentValue, propertyName, className, taskId));
            Severity--;
        }

        public string StepsToReproduseDisplay() 
        {
            StringBuilder bugInfo = new StringBuilder();
            int number = 1;
            bugInfo.AppendLine($"List of steps to reproduce it:");
            bugInfo.AppendLine(StringGenerator('=', 10));
            foreach (var step in stepsToReproduce)
            {
                bugInfo.AppendLine($"{number++}. {step}");
                bugInfo.AppendLine(StringGenerator('=', 10));
            }
            return bugInfo.ToString().Trim();
        }
        public override string ToString()
        {
            StringBuilder bugInfo = new StringBuilder();
            
            bugInfo.Append(base.ToString());
            bugInfo.AppendLine($"Priority: {Priority}");
            bugInfo.AppendLine($"Saverity: {Severity}");
            bugInfo.AppendLine($"Status: {Status}");
            bugInfo.AppendLine($"Assigned to: {Assignee.Name}");
            return bugInfo.ToString().Trim();
        }
    }
}
