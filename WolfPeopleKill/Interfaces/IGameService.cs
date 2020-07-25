using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WolfPeopleKill.DBModels;
using WolfPeopleKill.Models;

namespace WolfPeopleKill.Interfaces
{
    public interface IGameService
    {
        public List<GamePlay> GetRole(IEnumerable<Room> data);

        public IEnumerable<string> PatchCurrentPlayer(IEnumerable<Models.Room> data);


        public string WinOrLose(IEnumerable<Role> data);
    }

}
