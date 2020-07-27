using System.Collections.Generic;

namespace WolfPeopleKill.Interfaces
{
    public interface IGameRole
    {
        public void PushGetRoles(IEnumerable<Models.GamePlay> data);

    }
}
