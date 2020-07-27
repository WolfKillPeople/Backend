using System.Collections.Generic;
using WolfPeopleKill.Models;

namespace WolfPeopleKill.Interfaces
{
    public interface IGameRepo
    {
        public List<Role> GetRoles();

        public List<Models.Room> GetPlayers(List<GamePlay> data);

        public void PatchCurrentPlayer(List<Models.Room> data);
        public void PushGetRoles(IEnumerable<Models.GamePlay> data);
        public List<string> GetCurrentPlayer();
    }
}
