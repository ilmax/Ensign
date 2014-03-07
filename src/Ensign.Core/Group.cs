using System.Collections.Generic;
using EnsignLib.Core.Interfaces;

namespace EnsignLib.Core
{
    public class Group : IGroup
    {
        private readonly List<string> _users; 

        public string Name { get; private set; }

        public IEnumerable<string> Users
        {
            get { return _users; }
        }

        public Group(
            string name, 
            List<string> users = null)
        {
            Name = name;
            _users = users ?? new List<string>();
        }

        public IGroup AddUser(string userId)
        {
            _users.Add(userId);
            return this;
        }

        public IGroup RemoveUser(string userId)
        {
            _users.Remove(userId);
            return this;
        }

        public bool IsUserInGroup(string userId)
        {
            return _users.Contains(userId);
        }

    }
}
