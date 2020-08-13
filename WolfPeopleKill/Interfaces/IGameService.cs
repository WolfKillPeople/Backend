using System.Collections.Generic;
using WolfPeopleKill.Models;

namespace WolfPeopleKill.Interfaces
{
    public interface IGameService
    {
        
        public List<Role> GetRole();
        public List<KillPeoPle> PatchCurrentPlayer(IEnumerable<KillPeoPle> data);

        public List<KillPeoPle> Savepeople(IEnumerable<KillPeoPle> data);

        public string WinOrLose(IEnumerable<Role> data);

        public List<GamePlay> RoomGetPlayers(IEnumerable<GamePlay> data);

        public IEnumerable<VotePlayers> Votes(IEnumerable<VotePlayers> data);

        public List<Models.Occupation> Observer(KillPeoPle data);

        public List<OutToRoom> OutToRoom(OutToRoom data);
        public List<GameWin> GameWin(GameWin data);

    }

}
