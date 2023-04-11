using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;
using TaskManager.Models.Contracts;
using TaskManager.Models.Enums;
using TaskManager.Core.Interfaces;


namespace TaskManager.Core
{
    internal class Repository : IRepository
    {
        private readonly IList<ITeam> teams = new List<ITeam>();
        private readonly IList<IMember> members = new List<IMember>();
        private readonly IList<ITask> tasks = new List<ITask>();
        private readonly IList<IBoard> boards = new List<IBoard>();


        public IList<IBoard> Boards
        {
            get
            {
                var boardCopy = new List<IBoard>(boards);
                return boardCopy;
            }
        }
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

       
        public ITeam GetMember(string name)
        {
            throw new NotImplementedException();
        }

        public ITeam GetTeam(string name)
        {
            throw new NotImplementedException();
        }

        public void AddMember(IMember member)
        {
            throw new NotImplementedException();
        }

        public void AddTeam(ITeam team)
        {
            throw new NotImplementedException();
        }

        public bool MemberExist(string membername)
        {
            throw new NotImplementedException();
        }

        public bool TeamExist(string teamname)
        {
            throw new NotImplementedException();
        }
    }
}
