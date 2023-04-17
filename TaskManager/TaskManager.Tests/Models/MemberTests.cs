using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Exceptions;
using TaskManager.Models;
using TaskManager.Models.Contracts;

namespace TaskManager.Tests.Models
{
    [TestClass]
    public class MemberTests
    {
        [TestMethod]
        [DataRow(MemberNameMinLength - 1)]        
        [DataRow(MemberNameMaxLength + 1)]        
        public void Member_ShouldThrow_WhenMemberName_IsInvalidLength(int testSize)
        {            
            string testName = GetTestString(testSize);

            Assert.ThrowsException<InvalidUserInputException>(() =>
            new Member(testName));
        }

        [TestMethod]        
        public void Member_Should_CreateWhenDataIsValid()
        {
            var member = new Member(ValidMemberName);

            Assert.IsNotNull(member);
        }

        [TestMethod]
        public void MemberAddTask_Should_Add()
        {
            var member = GetTestMember();
            var bug = GetTestBug();
            member.AddTask(bug);
            Assert.AreEqual(1, member.Tasks.Count);
        }
        [TestMethod]
        public void MemberAddTask_ShouldThrow_WhenTaskIsDuplicate()
        {
            var member = GetTestMember();
            var bug = GetTestBug();
            member.AddTask(bug);
            Assert.ThrowsException<DuplicateEntryException>(() =>
            member.AddTask(bug)); 
        }
        [TestMethod]
        public void MemberRemoveTask_Should_Remove()
        {
            var member = GetTestMember();
            var bug = GetTestBug();
            member.AddTask(bug);
            member.RemoveTask(bug);
            Assert.AreEqual(0, member.Tasks.Count);
        }
        [TestMethod]
        public void MemberRemoveTask_ShouldThrow_WhenTaskNotFound()
        {
            var member = GetTestMember();
            var bug = GetTestBug();
            member.AddTask(bug);
            member.RemoveTask(bug);
            Assert.ThrowsException<EntryNotFoundException>(() =>
            member.RemoveTask(bug));
        }
        [TestMethod]
        public void MemberPrintTasks_Should_ReturnAString()
        {
            var member = GetTestMember();
            var bug = GetTestBug();
            member.AddTask(bug);

            Assert.IsNotNull(member.PrintTasks());
        }
        [TestMethod]
        public void MemberShowActivityLog_Should_ReturnAString()
        {
            var member = GetTestMember();

            Assert.IsNotNull(member.ShowActivityLog());
        }

        [TestMethod]
        public void MemberFullInfo_Should_ReturnAString()
        {
            var member = GetTestMember();

            Assert.IsNotNull(member.FullInfo());
        }
        [TestMethod]
        public void MemberCreateComment_Should_ReturnAValidComment()
        {
            var member = GetTestMember();

            Assert.IsNotNull(member.CreateComment(ValidDescription));
        }

        [TestMethod]
        public void MemberAssignToTeam_Should_AssignWhenNotAssignedAlready()
        {
            var member = GetTestMember();
            member.AssignToTeam(ValidTeamName);

            Assert.AreEqual(ValidTeamName, member.TeamAssignedTo);
        }
        [TestMethod]
        public void MemberAssignToTeam_ShouldThrow_WhenAlreadyAssigned()
        {
            var member = GetTestMember();
            member.AssignToTeam(ValidTeamName);

            Assert.ThrowsException<InvalidUserInputException>(() =>
            member.AssignToTeam(ValidTeamName));
        }
        [TestMethod]
        public void MemberToString_Should_ReturnAString()
        {
            var member = GetTestMember();

            Assert.IsNotNull(member.ToString());
        }
    }
}
