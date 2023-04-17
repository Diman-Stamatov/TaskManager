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


namespace TaskManager.Tests.Commands
{
    [TestClass]
    public class ListAssigneesTests
    {
        private IRepository repository;
        private ICommandFactory commandFactory;

        [TestInitialize]
        public void Setup()
        {
            repository = GetTestRepository();
            commandFactory = new CommandFactory(repository);
        }

        

    }
}
