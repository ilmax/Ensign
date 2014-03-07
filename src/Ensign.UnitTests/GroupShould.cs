using System;
using System.Collections.Generic;
using System.Linq;
using EnsignLib.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnsignLib.UnitTests
{
    [TestClass]
    public class GroupShould
    {
        private const string GroupName = "someGroup";

        private Group _group;

        [TestInitialize]
        public void Setup()
        {
            _group = new Group(GroupName);
        }

        [TestMethod]
        public void Constructor_SetAppropriateInitialValuesWhenNoUsersPassedIn()
        {
            Assert.AreEqual(_group.Name, GroupName);
            Assert.IsNotNull(_group.Users);
            Assert.AreEqual(0, _group.Users.Count());
        }

        [TestMethod]
        public void Constructor_SetAppropriateInitialValuesWhenUsersArePassedIn()
        {
            var users = BuildUserIds();

            _group = new Group(GroupName, users);

            Assert.AreEqual(_group.Name, GroupName);
            Assert.AreEqual(users, _group.Users);
        }

        [TestMethod]
        public void AddUser_AddUserToGroup()
        {
            var userId = Guid.NewGuid();

            var result = _group.AddUser(userId.ToString());

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Users.Count());
            Assert.AreEqual(userId.ToString(), result.Users.First());
        }

        [TestMethod]
        public void RemoveUser_RemoveUserFromGroup()
        {
            var users = SetupGroupWithUsers();

            var result = _group.RemoveUser(users.First());

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Users.Count());
        }

        [TestMethod]
        public void RemoveUser_DoNotThrowExceptionWhenRemovingUserThatIsNotThere()
        {
            var result = _group.RemoveUser(Guid.NewGuid().ToString());

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Users.Count());
        }

        [TestMethod]
        public void IsUserInGroup_ReturnFalseWhenUserIsNotInGroup()
        {
            var result = _group.IsUserInGroup(Guid.NewGuid().ToString());

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsUserInGroup_ReturnTrueWhenUserIsInGroup()
        {
            var users = SetupGroupWithUsers();

            var result = _group.IsUserInGroup(users.First());

            Assert.IsTrue(result);
        }

        private static List<string> BuildUserIds()
        {
            return new List<string>
            {
                Guid.NewGuid().ToString()
            };
        }

        private IEnumerable<string> SetupGroupWithUsers()
        {
            var users = BuildUserIds();

            _group = new Group(GroupName, users);
            Assert.AreEqual(1, _group.Users.Count());

            return users;
        }

    }
}
