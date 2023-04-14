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
using System.Diagnostics.Metrics;

namespace TaskManager.Models
{
    public class Story : Task, IStory
    {
        private const StoryStatusType InitialStatus = StoryStatusType.NotDone;

        private PriorityType priority;
        private SizeType size;
        private StoryStatusType status;
        private IMember assignee;
        private string teamAssignedTo;
        public Story(int id, string title, string description, PriorityType priority, SizeType size)
            : base(id, title, description)
        {
            Priority = priority;
            Size = size;
            status = InitialStatus;
            Log(Message(GetType().Name, id, title, priority, size));
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
        }

        public string TeamAssignedTo
        {
            get => teamAssignedTo;
        }

        public void AdvancePriority()
        {
            var type = priority.GetType();
            int currentValue = (int)Priority;
            string propertyName = GetMethodName().TrimAdvance();

            ValidateAdvanceMethod(type, currentValue, propertyName);

            string className = GetType().Name;
            int taskId = Id;
            string assigneeName = Assignee.Name;

            priority++;
            Log(GenerateAdvanceMethodMessage(type, currentValue, propertyName, className, taskId, assigneeName));
        }

        public void RevertPriority()
        {
            var type = priority.GetType();
            int currentValue = (int)Priority;
            string propertyName = GetMethodName().TrimRevert();

            ValidateRevertMethod(type, currentValue, propertyName);

            string className = GetType().Name;
            int taskId = Id;
            string assigneeName = Assignee.Name;

            priority--;
            Log(GenerateRevertMethodMessage(type, currentValue, propertyName, className, taskId, assigneeName));
        }

        public void AdvanceSize()
        {
            var type = size.GetType();
            int currentValue = (int)Size;
            string propertyName = GetMethodName().TrimAdvance();

            ValidateAdvanceMethod(type, currentValue, propertyName);

            string className = GetType().Name;
            int taskId = Id;
            string assigneeName = Assignee.Name;

            size++;
            Log(GenerateAdvanceMethodMessage(type, currentValue, propertyName, className, taskId, assigneeName));
        }

        public void RevertSize()
        {
            var type = size.GetType();
            int currentValue = (int)Size;
            string propertyName = GetMethodName().TrimRevert();

            ValidateRevertMethod(type, currentValue, propertyName);

            string className = GetType().Name;
            int taskId = Id;
            string assigneeName = Assignee.Name;

            size--;
            Log(GenerateRevertMethodMessage(type, currentValue, propertyName, className, taskId, assigneeName));
        }
        public override void AdvanceStatus()
        {
            var type = status.GetType();
            int currentValue = (int)Status;
            string propertyName = GetMethodName().TrimAdvance();

            ValidateAdvanceMethod(type, currentValue, propertyName);

            string className = GetType().Name;
            int taskId = Id;
            string assigneeName = Assignee.Name;

            status++;
            Log(GenerateAdvanceMethodMessage(type, currentValue, propertyName, className, taskId, assigneeName));
        }

        public override void RevertStatus()
        {
            var type = status.GetType();
            int currentValue = (int)Status;
            string propertyName = GetMethodName().TrimRevert();

            ValidateRevertMethod(type, currentValue, propertyName);

            string className = GetType().Name;
            int taskId = Id;
            string assigneeName = Assignee.Name;

            status--;
            Log(GenerateRevertMethodMessage(type, currentValue, propertyName, className, taskId, assigneeName));
        }

        public void Assign(IMember member)
        {
            ValidateAssignMethod(Assignee, member, teamAssignedTo);
            assignee = member;
            member.AddTask(this);
            bool isAssigned = assignee != null;
            string assigneeName = member.Name;
            Log(Message(GetType().Name, assigneeName, title, Id, isAssigned));
        }
        public void Unassign()
        {
            var type = this.GetType().Name;
            ValidateUnassignMethod(type, Assignee);
            string assigneeName = Assignee.Name;
            Assignee.RemoveTask(this);
            assignee = null;
            bool isAssigned = assignee != null;
            Log(Message(GetType().Name, assigneeName, title, Id, isAssigned));
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
