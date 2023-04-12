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
        public Story(int id, string title, string description, PriorityType priority, SizeType size)
            : base(id, title, description)
        {
            Priority = priority;
            Size = size;
            status = InitialStatus;
            Log(Message("Story", id, title, priority, size));
        }
        public PriorityType Priority
        {
            get => priority;

            private set
            {
                priority = value;
            }
        }

        public SizeType Size
        {
            get => size;

            private set
            {
                size = value; ;
            }
        }

        public StoryStatusType Status
        {
            get => status;
        }

        public IMember Assignee
        {
            get => assignee;
            set
            {
                ValidateAssignee(assignee, value);
                assignee = value;
                Log(Message("Story", value, Title, Id));
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

            priority++;
            Log(GenerateAdvanceMethodMessage(type, currentValue, propertyName, className, taskId));
        }

        public void RevertPriority()
        {
            var type = priority.GetType();
            int currentValue = (int)Priority;
            string propertyName = GetMethodName().TrimRevert();

            ValidateRevertMethod(type, currentValue, propertyName);

            string className = GetType().Name;
            int taskId = Id;
            
            priority--;
            Log(GenerateRevertMethodMessage(type, currentValue, propertyName, className, taskId));
        }

        public void AdvanceSize()
        {
            var type = size.GetType();
            int currentValue = (int)Size;
            string propertyName = GetMethodName().TrimAdvance();

            ValidateAdvanceMethod(type, currentValue, propertyName);

            string className = GetType().Name;
            int taskId = Id;

            size++;
            Log(GenerateAdvanceMethodMessage(type, currentValue, propertyName, className, taskId));
        }

        public void RevertSize()
        {
            var type = size.GetType();
            int currentValue = (int)Size;
            string propertyName = GetMethodName().TrimRevert();

            ValidateRevertMethod(type, currentValue, propertyName);

            string className = GetType().Name;
            int taskId = Id;
            
            size--;
            Log(GenerateRevertMethodMessage(type, currentValue, propertyName, className, taskId));
        }
        public override void AdvanceStatus()
        {
            var type = status.GetType();
            int currentValue = (int)Status;
            string propertyName = GetMethodName().TrimAdvance();

            ValidateAdvanceMethod(type, currentValue, propertyName);

            string className = GetType().Name;
            int taskId = Id;

            status++;
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
            Log(GenerateRevertMethodMessage(type, currentValue, propertyName, className, taskId));
            status--;
        }

        public void AssignTask(IMember member)
        {
            ValidateAssignee(Assignee, member);
            assignee = member;
            Log(Message("Story", member, title, Id));
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
