﻿using System;
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
        private List<string> stepsToReproduce;
        private PriorityType priority;
        private BugStatusType status;
        private SeverityType severity;
        private IMember assignee;

        public Bug(
            string title, 
            string description, 
            PriorityType priority,  
            SeverityType severity) 

            : base(title, description)
        {
            Priority = priority;
            status = BugStatusType.Active;
            Severity = severity;
            stepsToReproduce = new List<string>();
             // ???  LogChanges($"Priority set to {value}");
              //  LogChanges($"Severity set to {value}");

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
            private set
            {
                ValidateAssignee(assignee, value);
                assignee = value;               
            }
        }


        public void AddStepsToReproduce(string stepToReproduce)
        {
            //???
            ValidateStringNotNullOrEmpty(
                stepToReproduce, 
                "Step to reproduce can not be null or empty.");

            stepsToReproduce.Add(stepToReproduce);

            LogChanges(
                $"'{stepsToReproduce}' added to 'Steps to reproduce'");
        }        
      
        public IList<string> StepsToReproduce { get => new List<string>(stepsToReproduce); }

        public IList<IComment> Comments => throw new NotImplementedException();

        public IList<string> ChangesHistory => throw new NotImplementedException();

        public BugStatusType StatusType => throw new NotImplementedException();
    }
}
