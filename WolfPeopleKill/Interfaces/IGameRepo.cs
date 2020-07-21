using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WolfPeopleKill.DBModels;

namespace WolfPeopleKill.Interfaces
{
    public interface IGameRepo
    {
        public List<Occupation> GetRoles();

        public List<Room> GetPlayers(DBModels.Room data);

        public void PatchCurrentPlayer(DBModels.Room data);
    }
}
