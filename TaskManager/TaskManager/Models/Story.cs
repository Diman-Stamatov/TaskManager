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
         
        private PriorityType priority;
        private SizeType size;
        private StoryStatusType status;
        private IMember assignee;
        public Story(string title, string description, PriorityType priority, SizeType size, StoryStatusType status)
            : base (title, description)
        {
            this.Priority = priority;
            this.Size = size;
            this.Status = status;
        }
        public PriorityType Priority
        {
            get => priority;

            private set
            {
                this.priority = value;
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
                this.size = value;
            }
        }

        public StoryStatusType Status
        {
            get
            {
                return this.status;
            }
            private set
            {
                this.status = value;
            }
        }

        public IMember Assignee
        {
            get
            {
                return this.assignee;
            }
            private set
            {
                ValidateAssignee(this.assignee, value);
                this.assignee = value;
            }
        }


        public void AdvancePriority()
        {
            var type = this.priority.GetType();
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
            var type = this.priority.GetType();
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

        public override string ToString() => throw new NotImplementedException();

        
    }
}
