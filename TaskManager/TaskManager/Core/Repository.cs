﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;
using TaskManager.Models.Contracts;
using TaskManager.Models.Enums;
using TaskManager.Core.Interfaces;
using TaskManager.Exceptions;

namespace TaskManager.Core
{
    internal class Repository : IRepository
    {
        private const string DuplicateMemberMessage = "{0} is already a registered employee!";
        private const string MemberNotFoundMessage = "{0} is not a registered employee!";
        private const string TaskNotFoundMessage = "A task with the ID {0} does not exist!";

        private readonly IList<ITeam> teams = new List<ITeam>();
        private readonly IList<IMember> members = new List<IMember>();
        private readonly IList<ITask> tasks = new List<ITask>();
        //ToDo Removed boards from Repository     
        
        public IList<ITeam> Teams
        {
            get
            {
                var teamCopy = new List<ITeam>(teams);
                return teamCopy;
            }
        }

        public IList<IMember> Members
        {
            get
            {
                var memberCopy = new List<IMember>(members);
                return memberCopy;
            }
        }

        public IList<ITask> Tasks
        {
            get
            {
                var taskCopy = new List<ITask>(tasks);
                return taskCopy;
            }
        }

        public IMember CreateMember(string name)
        {
            throw new NotImplementedException();
        }
        public IBoard CreateBoard(string name)
        {
            throw new NotImplementedException();
        }

        public ITeam CreateTeam(string name)
        {
            throw new NotImplementedException();
        }

        public IBug CreageBug(string title, string description, PriorityType priority, SeverityType severity)
        {
            int nextId = tasks.Count();
            ITask bug = new Bug(++nextId, title, description, priority, severity);
            tasks.Add(bug);
            return (IBug)bug;
            //защо трабва изрично да му даваме при услови, че интерфейсите се екстендват???????
        }

        public IFeedback CreateFeedback(string title, string description, int rating)
        {
            int nextId = tasks.Count();
            ITask feedback = new Feedback(++nextId, title, description, rating);
            tasks.Add(feedback);
            return (IFeedback)feedback;
            //защо трабва изрично да му даваме при услови, че интерфейсите се екстендват???????
        }

        public IStory CreateStory(string title, string description, PriorityType priority, SizeType size)
        {
            int nextId = tasks.Count();
            ITask story = new Story(nextId, title, description, priority, size);
            tasks.Add(story);
            return (IStory)story;
            //защо трабва изрично да му даваме при услови, че интерфейсите се екстендват???????
        }

       
        public IMember GetMember(string memberName)
        {
            bool memberExists = MemberExists(memberName);
            if (memberExists == false)
            {
                string errorMessage = string.Format(MemberNotFoundMessage, memberName);
                throw new EntryNotFoundException(errorMessage);
            }
            IMember foundMember = members.Where(member => member.Name == memberName).First();
            return foundMember;
        }

        public ITeam GetTeam(string name)
        {
            throw new NotImplementedException();
        }

        public void AddMember(IMember member)
        {
            string memberName = member.Name;
            bool memberExists = MemberExists(memberName);
            if (memberExists == true)
            {
                string errorMessage = string.Format(DuplicateMemberMessage, memberName);
                throw new DuplicateEntryException(errorMessage);
            }
            members.Add(member);
        }

        public void AddTeam(ITeam team)
        {
            throw new NotImplementedException();
        }

        public bool MemberExists(string memberName)
        {
            bool memberExists = Members.Any(member=>member.Name == memberName);
            return memberExists;
            
        }

        public bool TeamExists(string teamname)
        {
            throw new NotImplementedException();
        }

        public ITask GetTask(int id)
        {
            bool taskExists = TaskExists(id);
            if (taskExists == false)
            {
                string errorMessage = string.Format(TaskNotFoundMessage, id);
                throw new EntryNotFoundException(errorMessage);
            }
            ITask foundTask = Tasks.Where(task=>task.Id == id).First();
            return foundTask;
        }
        public bool TaskExists(int id)
        { 
            bool taskExists = Tasks.Any(task=>task.Id == id);
            return taskExists;
        }
    }
}
