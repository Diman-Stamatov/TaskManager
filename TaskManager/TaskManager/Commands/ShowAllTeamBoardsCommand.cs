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
                boardDisplay.AppendLine(team.Name);
                for (int i = 0; i < team.Boards.Count; i++)
                {
                    boardDisplay.AppendLine($"{team.Boards[i].Name} - Task Count {team.Boards[i].Tasks.Count}");
                    //ToDo ако няма board да изписва нещо
                }
                boardDisplay.AppendLine(StringGenerator('*', 15));
            }
            return boardDisplay.ToString().Trim();
        }
    }
}
