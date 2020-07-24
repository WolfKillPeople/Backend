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
        public List<GamePlay> GetRole(IEnumerable<GamePlay> data);

        public IEnumerable<string> PatchCurrentPlayer(IEnumerable<Models.Room> data);


        public bool WinOrLose(IEnumerable<Role> data);
    }

}
