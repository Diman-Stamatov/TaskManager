using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;

namespace TaskManager.Commands
{
    public class ShowAllTeamBoardsCommand:BaseCommand
    {
        public ShowAllTeamBoardsCommand(IRepository repository)
            : base(repository)
        {
        }

        public override string Execute()
        {
            var teams = Repository.Teams; 
            StringBuilder boardDisplay = new StringBuilder();
            foreach (var team in teams)
            {
                team.ShowBoards();
            }
            return "Successfully displayed every Team's Boards.";
        }
    }
}
