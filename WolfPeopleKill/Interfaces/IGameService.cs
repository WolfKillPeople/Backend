using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WolfPeopleKill.Models;

namespace WolfPeopleKill.Interfaces
{
    public interface IGameService
    {
        public List<GamePlay> GetRole(IEnumerable<GamePlay> data);

        public void PatchCurrentPlayer(IEnumerable<Room> data);


        public string WinOrLose(IEnumerable<Role> data);
    }
}
