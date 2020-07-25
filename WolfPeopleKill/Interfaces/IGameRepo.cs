using System.Collections.Generic;
using WolfPeopleKill.Models;

namespace WolfPeopleKill.Interfaces
{
    public interface IGameRepo
    {
        public List<Role> GetRoles();

        public List<Models.Room> GetPlayers(IEnumerable<Room> data);

        public void PatchCurrentPlayer(DBModels.Room data);
        public void PushGetRoles(IEnumerable<Models.GamePlay> data);
        public IEnumerable<string> GetCurrentPlayer();
    }
}
