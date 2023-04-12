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
        IList<ITask> Tasks { get; }
        bool TeamExists(string teamname);
        void AddTeam(ITeam team);
        ITeam GetTeam(string teamName);
        bool MemberExists(string membername);
        void AddMember(IMember member);
        IMember GetMember(string memberName);       
        ITeam CreateTeam(string teamName);
        IMember CreateMember(string memberName);       
        IBug CreageBug(string title, string description, PriorityType priority, SeverityType severity);
        IStory CreateStory(string title, string description, PriorityType priority, SizeType size);
        IFeedback CreateFeedback(string title, string description, int rating);
        ITask GetTask(int id);


        
    }
}
