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
using System.Diagnostics.Metrics;

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
            Log(Message("Bug", Id, title, priority, severity));
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
            get => assignee;
            
        }

        public void AddStepsToReproduce(string allStepsToReproduceAsOneString)
        {
            ValidateStringNotNullOrEmpty(allStepsToReproduceAsOneString,"Step to reproduce can not be null or empty.");
            stepsToReproduce = allStepsToReproduceAsOneString.Split(';').ToList();
            
            foreach (var step in stepsToReproduce)
            {
            Log($"[{stepsToReproduce}] was added to 'Steps to reproduce'");
            }
        }

        public IList<string> StepsToReproduce
        {
            get => new List<string>(stepsToReproduce);
        }

        //ToDo      AssignBug() ? има и  AssignStory() 
        public void AssignTask(IMember member)
        {
            ValidateAssignee(Assignee, member);
            bool isAssigned = assignee == null;            
            assignee = member;
            Log(Message("Bug", isAssigned, member, title, Id));
        }
        public void UnassignTask(IMember member)
        {
            ValidateAssignee(Assignee, member);
            bool isAssigned = assignee == null;
            assignee = member;
            Log(Message("Bug", isAssigned, member, title, Id));
        }

        public void AdvancePriority()
        {
            var type = Priority.GetType();
            int currentValue = (int)Priority;
            string propertyName = GetMethodName().TrimAdvance();

            ValidateAdvanceMethod(type, currentValue, propertyName);

            string className = GetType().Name;
            int taskId = Id;

            priority++;
            Log(GenerateAdvanceMethodMessage(type, currentValue, propertyName, className, taskId));
        }

        public void RevertPriority()
        {
            var type = Priority.GetType();
            int currentValue = (int)Priority;
            string propertyName = GetMethodName().TrimRevert();

            ValidateRevertMethod(type, currentValue, propertyName);

            string className = GetType().Name;
            int taskId = Id;

            priority--;
            Log(GenerateRevertMethodMessage(type, currentValue, propertyName, className, taskId));
        }

        public override void AdvanceStatus()
        {
            var type = Status.GetType();
            int currentValue = (int)Status;
            string propertyName = GetMethodName().TrimAdvance();

            ValidateAdvanceMethod(type, currentValue, propertyName);

            string className = GetType().Name;
            int taskId = Id;

            Status++;
            Log(GenerateAdvanceMethodMessage(type, currentValue, propertyName, className, taskId));
        }

        public override void RevertStatus()
        {
            var type = status.GetType();
            int currentValue = (int)Status;
            string propertyName = GetMethodName().TrimRevert();

            ValidateRevertMethod(type, currentValue, propertyName);

            string className = GetType().Name;
            int taskId = Id;

            status--;
            Log(GenerateRevertMethodMessage(type, currentValue, propertyName, className, taskId));
        }

        public void AdvanceSeverity()
        {
            var type = Severity.GetType();
            int currentValue = (int)Severity;
            string propertyName = GetMethodName().TrimAdvance();

            ValidateAdvanceMethod(type, currentValue, propertyName);

            string className = GetType().Name;
            int taskId = Id;

            Severity++;
            Log(GenerateAdvanceMethodMessage(type, currentValue, propertyName, className, taskId));
        }

        public void RevertSeverity()
        {
            var type = Severity.GetType();
            int currentValue = (int)Severity;
            string propertyName = GetMethodName().TrimRevert();

            ValidateRevertMethod(type, currentValue, propertyName);

            string className = GetType().Name;
            int taskId = Id;

            Severity--;
            Log(GenerateRevertMethodMessage(type, currentValue, propertyName, className, taskId));
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
