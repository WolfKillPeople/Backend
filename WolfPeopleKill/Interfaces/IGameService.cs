using System.Collections.Generic;
using WolfPeopleKill.Models;

namespace WolfPeopleKill.Interfaces
{
    public interface IGameService
    {
        
        public List<GamePlay> GetRole(IEnumerable<GamePlay> data);
        public List<KillPeoPle> PatchCurrentPlayer(IEnumerable<KillPeoPle> data);

        public List<KillPeoPle> Savepeople(IEnumerable<KillPeoPle> data);

        public string WinOrLose(IEnumerable<Role> data);

        public List<GamePlay> RoomGetPlayers(IEnumerable<GamePlay> data);

        public List<PollPlayers> PollPlayers(IEnumerable<PollPlayers> data);

        public List<KillPeoPle> Observer(KillPeoPle data);
    }

}
