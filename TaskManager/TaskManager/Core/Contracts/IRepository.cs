using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;
using TaskManager.Models.Contracts;
using TaskManager.Models.Enums;

namespace TaskManager.Core.Interfaces
{
   public interface IRepository
    {
        IList<ITeam> Teams { get; }
        IList<IMember> Members { get; }
        void AddTeam(ITeam team);
        ITeam GetTeam(string name);
        void AddMember(IMember member);
        public bool MemberExist(string membername);
        public bool TeamExist(string teamname);
        ITeam GetMember(string name);
        public ITeam CreateTeam(string name);
        public IMember CreateMember(string name);
        public IBoard CreateBoard(string name);
        public IBug CreageBug(string title, string description, PriorityType priority, SeverityType severity);
        public IStory CreateStory(string title, string description, PriorityType priority, SizeType size);
        public IFeedback CreateFeedback(string title, string description, int rating);

        
    }
}
