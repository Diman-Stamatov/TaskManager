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
        public Story(string title, string description, PriorityType priority, SizeType size)
            : base (title, description)
        {
            Priority = priority;
            Size = size;
            status = InitialStatus;
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
            get
            {
                return this.size;
            }
            private set
            {
                size = value;
            }
        }

        public StoryStatusType Status
        {
            get
            {
                return this.status;
            }
            
        }

        public IMember Assignee
        {
            get
            {
                return this.assignee;
            }
            
        }


        public void AdvancePriority()
        {
            var type = priority.GetType();
            int currentValue = (int)this.Priority;
            string propertyName = GetMethodName().TrimAdvance();
            
            ValidateAdvanceMethod(type, currentValue, propertyName);
            LogChanges(GenerateAdvanceMethodMessage(type, currentValue, propertyName));
            
            this.priority++;
        }
        public void RevertPriority()
        {
            var type = this.priority.GetType();
            int currentValue = (int)this.Priority;
            string propertyName = GetMethodName().TrimRevert();

            ValidateRevertMethod(type, currentValue, propertyName);
            this.priority--;
        }
        public void AdvanceSize()
        {
            var type = size.GetType();
            int currentValue = (int)this.Priority;
            string propertyName = GetMethodName().TrimAdvance();

            ValidateAdvanceMethod(type, currentValue, propertyName);
            
            this.size++;
        }
        public void RevertSize()
        {
            var type = this.priority.GetType();
            int currentValue = (int)this.Priority;
            string propertyName = GetMethodName().TrimRevert();

            ValidateRevertMethod(type, currentValue, propertyName);
            this.size--;
        }
        public override void AdvanceStatus()
        {
            var type = this.priority.GetType();
            int currentValue = (int)this.Priority;
            string propertyName = GetMethodName().TrimAdvance();

            ValidateAdvanceMethod(type, currentValue, propertyName);
            
            this.status++;
        }
        public override void RevertStatus()
        {
            var type = this.priority.GetType();
            int currentValue = (int)this.Priority;
            string propertyName = GetMethodName().TrimRevert();

            ValidateRevertMethod(type, currentValue, propertyName);
            this.status--;
        }
        public void AssignToMember(IMember member)
        {
            ValidateAssignee(Assignee, member);
            assignee = member;
        }
        public override string ToString() => throw new NotImplementedException();

        
    }
}
