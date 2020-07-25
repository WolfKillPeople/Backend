using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WolfPeopleKill.Models;

namespace WolfPeopleKill.Interfaces
{
    public interface IGameService
    {
        public List<GamePlay> GetRole(IEnumerable<Room> data);

        public void PatchCurrentPlayer(IEnumerable<GamePlay> data);


        public string WinOrLose(IEnumerable<Role> data);
    }
}
