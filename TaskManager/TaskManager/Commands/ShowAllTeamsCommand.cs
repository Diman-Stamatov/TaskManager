using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;

namespace TaskManager.Commands
{
   public class ShowAllTeamsCommand : BaseCommand
    {

        public ShowAllTeamsCommand(IRepository repository)
            : base(repository)
        {
        }

        public override string Execute()
        {
            var teams = Repository.Teams;
            StringBuilder boardDisplay = new StringBuilder();
            foreach (var team in teams)
            {
                boardDisplay.AppendLine($"Team - {team.Name} - have {team.Members.Count} members.");

            }
            return boardDisplay.ToString().Trim();
        }
    }
}
