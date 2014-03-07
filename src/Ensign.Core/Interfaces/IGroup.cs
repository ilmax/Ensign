using System.Collections.Generic;

namespace EnsignLib.Core.Interfaces
{
    public interface IGroup
    {
        string Name { get; }
        IEnumerable<string> Users { get; }

        IGroup AddUser(string userId);
        IGroup RemoveUser(string userId);

        bool IsUserInGroup(string userId);
    }
}
