using System.Collections.Generic;
using WolfPeopleKill.Models;

namespace WolfPeopleKill.Interfaces
{
    public interface IGameService
    {
        public List<GamePlay> GetRole(IEnumerable<GamePlay> data);

        public IEnumerable<string> PatchCurrentPlayer(IEnumerable<GamePlay> data);

        public string WinOrLose(IEnumerable<Role> data);

        public List<GamePlay> RoomGetPlayers(IEnumerable<GamePlay> data);

        public IEnumerable<VotePlayers> Votes();
    }

}
