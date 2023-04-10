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
        public ICollection<ITeam> Teams => throw new NotImplementedException();

        public ICollection<IMember> Members => throw new NotImplementedException();

        public void AddMember(IMember member)
        {
            throw new NotImplementedException();
        }

        public void AddTeam(ITeam team)
        {
            throw new NotImplementedException();
        }

        public IBug CreageBug(string title, string description, PriorityType priority, SeverityType severity)
        {
            throw new NotImplementedException();
        }

        public IBoard CreateBoard(string name)
        {
            throw new NotImplementedException();
        }

        public IFeedback CreateFeedback(string title, string description, int rating)
        {
            throw new NotImplementedException();
        }

        public IMember CreateMember(string name)
        {
            throw new NotImplementedException();
        }

        public IStory CreateStory(string title, string description, PriorityType priority, SizeType size)
        {
            throw new NotImplementedException();
        }

        public ITeam CreateTeam(string name)
        {
            throw new NotImplementedException();
        }

        public ITeam GetMember(string name)
        {
            throw new NotImplementedException();
        }

        public ITeam GetTeam(string name)
        {
            throw new NotImplementedException();
        }
    }
}
