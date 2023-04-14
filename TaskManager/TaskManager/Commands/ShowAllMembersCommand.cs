using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;

namespace TaskManager.Commands
{
    public class ShowAllMembersCommand:BaseCommand
    {
       
        public ShowAllMembersCommand(IRepository repository)
            : base(repository)
        {
        }

        public override string Execute()
        {
            var teams = Repository.Teams; 
            StringBuilder memberDisplay = new StringBuilder();
            foreach (var team in teams)
            {
                memberDisplay.AppendLine(team.Name);
                for (int i = 0; i < team.Members.Count; i++)
                {
                    memberDisplay.AppendLine(team.Members[i].FullInfo());
                }
                memberDisplay.AppendLine(StringGenerator('*', 15));
            }
            return memberDisplay.ToString().Trim();
        }
    }
}
