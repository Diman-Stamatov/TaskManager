using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.Models.Enums;
using TaskManager.Models.Contracts;
using static TaskManager.Utilities.UtilityMethods;
using static TaskManager.Utilities.Validation;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace TaskManager.Models
{
    public class Team : ITeam
    {
        private const int TeamNameMinLength = 5;
        private const int TeamNameMaxLength = 15;

        private string name;
        private IList<IMember> members;
        private IList<IBoard> boards;
        private readonly IList<string> hystoryLog;

        public Team(string name)
        {
            Name = name;
            members = new List<IMember>();
            boards = new List<IBoard>();
            hystoryLog = new List<string>();
            Log(Message(Name));
        }
        public string Name
        {
            get => name;
            private set
            {
                string className = this.GetType().Name;
                string propertyName = GetMethodName();
                ValidateStringPropertyLength(value, className, propertyName, TeamNameMinLength, TeamNameMaxLength);                
                this.name = value;
            }
        }

        public IList<IMember> Members
        {
            get
            {
                return new List<IMember>(this.members);
            }            
        }

        public IList<IBoard> Boards
        {
            get
            {
                return new List<IBoard>(this.boards);
            }
        }

        public void CreateBoard(string boardName)
        {
            string teamName = Name;
            ValidateDuplicateBoard(boardName, Boards, teamName);
            var board = new Board(boardName);
            boards.Add(board);
            Log(Message(board, teamName));
        }

        public string ShowBoards()
        {
            var allBoardsInfo = new StringBuilder();
            string lineSeperator = StringGenerator('-', 10);
            allBoardsInfo.AppendLine($"Team \"{Name}\" boards:");
            for (int board = 0; board < Boards.Count; board++)
            {
                allBoardsInfo.AppendLine(Boards[board].ToString());
                allBoardsInfo.AppendLine(lineSeperator);
            }
            return allBoardsInfo.ToString();
        }

        private void Log(string newEvent)
        {
            hystoryLog.Add(AddDate(newEvent));
        }
        private string Message(string name)
        {
            return $"Team with name: {name} was created";
        }
        private string Message(Board board, string name)
        {
            return $"Board: {board.Name} was created in team: {name}";
        }
        private string Message(IMember member, string name)
        {
            return $"{member.Name} was added in team: {name}";
        }
        public void AddTeamMember(IMember member)
        {
            ValidateDuplicateTeamMember(member.Name, Members);
            members.Add(member);
            member.AssignToATeam();
            Log(Message(member, Name));            
        }

    }
}
