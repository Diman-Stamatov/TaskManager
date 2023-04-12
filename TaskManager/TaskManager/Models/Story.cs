using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using TaskManager.Models.Contracts;
using TaskManager.Models.Enums;
using static TaskManager.Utilities.Validation;
using static TaskManager.Utilities.UtilityMethods;

namespace TaskManager.Models
{
    public class Story : Task, IStory
    {
        private const StoryStatusType InitialStatus = StoryStatusType.NotDone;

        private PriorityType priority;
        private SizeType size;
        private StoryStatusType status;
        private IMember assignee;
        public Story(int id,string title, string description, PriorityType priority, SizeType size)
            : base (id,title, description)
        {
            Priority = priority;
            Size = size;
            status = InitialStatus;
        }
        public PriorityType Priority
        {
            //не се записва Priority от инпут в changesLog
            get => priority;

            private set
            {
                priority = value;
            }
        }

        public SizeType Size
        {
            //не се записва Size от инпут в changesLog
            get => size;

            private set
            {
                size = value;
            }
        }

        public StoryStatusType Status
        {
            //не се записва Status от инпут в changesLog
            get => status;
        }

        public IMember Assignee
        {
            //не се записва Size от инпут в changesLog
            get => assignee;
            set
            {
                ValidateAssignee(assignee, value);
                assignee = value;
            }

        }


        public void AdvancePriority()
        {
            var type = priority.GetType();
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
            var type = priority.GetType();
            int currentValue = (int)Priority;
            string propertyName = GetMethodName().TrimRevert();

            ValidateRevertMethod(type, currentValue, propertyName);

            string className = GetType().Name;
            int taskId = Id;
            LogChanges(GenerateRevertMethodMessage(type, currentValue, propertyName, className, taskId));
            priority--;
        }
        public void AdvanceSize()
        {
            var type = size.GetType();
            int currentValue = (int)Size;
            string propertyName = GetMethodName().TrimAdvance();

            ValidateAdvanceMethod(type, currentValue, propertyName);

            string className = GetType().Name;
            int taskId = Id;
            LogChanges(GenerateAdvanceMethodMessage(type, currentValue, propertyName, className, taskId));

            size++;
        }
        public void RevertSize()
        {
            var type = size.GetType();
            int currentValue = (int)Size;
            string propertyName = GetMethodName().TrimRevert();

            ValidateRevertMethod(type, currentValue, propertyName);

            string className = GetType().Name;
            int taskId = Id;
            LogChanges(GenerateRevertMethodMessage(type, currentValue, propertyName, className, taskId));
            size--;
        }
        public override void AdvanceStatus()
        {
            var type = status.GetType();
            int currentValue = (int)Status;
            string propertyName = GetMethodName().TrimAdvance();

            ValidateAdvanceMethod(type, currentValue, propertyName);

            string className = GetType().Name;
            int taskId = Id;
            LogChanges(GenerateAdvanceMethodMessage(type, currentValue, propertyName, className, taskId));

            status++;
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
        public void AssignTask(IMember member)
        {
            ValidateAssignee(Assignee, member);
            assignee = member;
        }
        public override string ToString()
        {
            StringBuilder storyInfo = new StringBuilder();
            storyInfo.Append(base.ToString());
            storyInfo.AppendLine($"Priority: {Priority}");
            storyInfo.AppendLine($"Size: {Size}");
            storyInfo.AppendLine($"Status: {Status}");
            storyInfo.AppendLine($"Assigned to: {Assignee.Name}");
            return storyInfo.ToString().Trim();
        }        
    }
}
