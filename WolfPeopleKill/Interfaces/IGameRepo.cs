using System.Collections.Generic;
using WolfPeopleKill.Models;

namespace WolfPeopleKill.Interfaces
{
    public interface IGameRepo
    {
        public List<Role> GetRoles();

        public List<Models.Room> GetPlayers(List<GamePlay> data);
        public void PatchCurrentPlayer(List<KillPeoPle> data);
        public void Savepeople(List<KillPeoPle> data);

        public void PushGetRoles(IEnumerable<Models.GamePlay> data);
        public List<KillPeoPle> GetCurrentPlayer(List<KillPeoPle> data);
        public List<GamePlay> RoomGetPlayers(List<Models.GamePlay> data);

        public List<Models.Occupation> Observer(KillPeoPle data);
        public List<OutToRoom> OutToRoom(OutToRoom data);
        List<GameWin> GameWin(GameWin data);
    }
}
