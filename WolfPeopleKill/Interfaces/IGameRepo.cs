using System.Collections.Generic;
using WolfPeopleKill.Models;

namespace WolfPeopleKill.Interfaces
{
    public interface IGameRepo
    {
        public List<Role> GetRoles();

        public List<Models.Room> GetPlayers(IEnumerable<Room> data);

        public void PatchCurrentPlayer(Room data);
    }
}
