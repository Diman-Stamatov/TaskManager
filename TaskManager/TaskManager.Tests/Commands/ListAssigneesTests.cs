using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Commands;
using TaskManager.Core;
using TaskManager.Core.Interfaces;
using TaskManager.Models.Contracts;

namespace TaskManager.Tests.Commands
{
    [TestClass]
    public class ListAssigneesTests
    {
        private IRepository repository;

        [TestInitialize]
        public void Setup()
        {
            repository = GetTestRepository();
        }

        [TestMethod]
        public void Execute_ReturnsNoTasksAssignedMessage_WhenRepositoryHasNoAssignees()
        {

            Assert.AreEqual("No Tasks have been assigned yet!", result);
        }

    }
}
