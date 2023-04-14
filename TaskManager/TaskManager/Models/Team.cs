using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.Models.Enums;
using TaskManager.Models.Contracts;
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
        private readonly IList<string> historyLog;

        public Team(string name)
        {
            Name = name;
            members = new List<IMember>();
            boards = new List<IBoard>();
            historyLog = new List<string>();
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
            get => new List<IMember>(members);            
        }

        public IList<IBoard> Boards
        {
            get => new List<IBoard>(boards);            
        }

        public void CreateBoard(string boardName)
        {
            string teamName = Name;
            ValidateDuplicateBoard(boardName, Boards, teamName);
            var board = new Board(boardName);
            boards.Add(board);
            Log(Message(board, teamName));
        }
        public void AddTeamMember(IMember member)
        {
            ValidateDuplicateTeamMember(member.Name, Members);
            members.Add(member);
            member.AssignToTeam(Name);
            Log(Message(member, Name));            
        }
        public IBoard GetBoard(string boardName)
        {
            return boards.Where(board => board.Name == boardName).First();
        }
        public string ShowBoards()
        {
            var allBoardsInfo = new StringBuilder();
            string lineSeperator = GenerateString('-', 10);
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
            historyLog.Add(AddDate(newEvent));
        }
        public void ShowHistoryLog()
        {
            string lineSeperator = GenerateString('-', 10);
            Console.WriteLine(lineSeperator);
            Console.WriteLine($"Team \"{Name}\" activity history:");
            foreach (var loggedEvent in historyLog)
            {
                Console.WriteLine(loggedEvent);
            }
            Console.WriteLine(lineSeperator);
        }
        public void ShowTeamMembers()
        {
            string lineSeperator = GenerateString('-', 10);
            Console.WriteLine(lineSeperator);
            Console.WriteLine($"Members assigned to Team \"{Name}\":");
            if (members.Count == 0)
            {
                Console.WriteLine($"No members have been assigned to Team \"{Name}\" yet!");
            }
            else
            {
                foreach (var member in members)
                {
                    Console.WriteLine(member.ToString());
                }
            }            
            Console.WriteLine(lineSeperator);
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

        
    }
}
