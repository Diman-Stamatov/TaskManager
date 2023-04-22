using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core;
using TaskManager.Core.Interfaces;
using TaskManager.Exceptions;
using TaskManager.Models;
using TaskManager.Models.Contracts;
using TaskManager.Models.Enums;

namespace TaskManager.Tests.Models
{
    [TestClass]
    public class CommentTests
    {
        private IRepository repository;
        private ICommandFactory commandFactory;
        private ITeam mockTeam;
        private IMember mockMember;
        private IStory mockStory;
        private IBug mockBug;
        private IFeedback mockFeedback;
        private IComment mockComment;

        [TestInitialize]
        public void Initialize()
        {
            repository = new Repository();
            commandFactory = new CommandFactory(repository);
            mockBug = repository.CreateBug(ValidTaskTitle, ValidDescription, ValidPriority, ValidSeverity);
            mockStory = repository.CreateStory(ValidTaskTitle, ValidDescription, ValidPriority, ValidSize);
            mockFeedback = repository.CreateFeedback(ValidTaskTitle, ValidDescription, ValidId);
            mockTeam = repository.CreateTeam(ValidTeamName);
            mockMember = repository.CreateMember(ValidMemberName);
            mockMember.AssignToTeam(mockTeam.Name);
            mockBug.Assign(mockMember);
        }

        //[TestMethod]
        //public void CommandShoudAddComment_When_InputIsValid() 
        //{
        //    ICommand command = commandFactory.Create($"AddTaskComment 1 {mockMember.Name} kjhgkjhgkjhgkjhgkjhgkjhgjkgkjhg");
        //    command.Execute();
        //    Assert.AreEqual(mockBug.Comments.Count, 1);
        //}

    }
}
