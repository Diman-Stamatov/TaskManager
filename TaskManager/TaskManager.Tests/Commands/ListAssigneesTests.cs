using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Commands;
using TaskManager.Core;
using TaskManager.Core.Interfaces;
using TaskManager.Exceptions;
using TaskManager.Models.Contracts;
using TaskManager.Commands.Contracts;
using TaskManager.Models;


namespace TaskManager.Tests.Commands
{
    [TestClass]
    public class ListAssigneesTests
    {
        private IRepository repository;
        private ICommand command;

        [TestInitialize]
        public void InitTest()
        {
            repository = new Repository();
            command = new ListAssigneesCommand(repository);
        }

        [TestMethod]
        public void Should_ShowMessage_When_ThereAreNoMembers()
        {
            Assert.AreEqual(command.Execute(), "No Tasks have been assigned yet!");
        }

        [TestMethod]
        public void Execute_ReturnsSortedAssignees_WhenThereAreAssignees()
        {
            var member1 = repository.CreateMember("Aaaaaaaaaa");
            var member2 = repository.CreateMember("Bbbbbbbbbb");
            var member3 = repository.CreateMember("Cccccccccc");
            Team team1 = (Team)repository.CreateTeam("Team1");
            team1.AddTeamMember(member3);
            team1.AddTeamMember(member2);
            team1.AddTeamMember(member1);
            List<string> result = command.Execute().Split(Environment.NewLine).ToList();
            Assert.IsTrue(result[0].Contains("Aaaaaaaaaa"));
            Assert.IsTrue(result[1].Contains("Bbbbbbbbbb"));
            Assert.IsTrue(result[2].Contains("Cccccccccc"));
        }


    }
}
