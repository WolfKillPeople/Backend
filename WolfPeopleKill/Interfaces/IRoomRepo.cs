using System.Collections.Generic;

namespace WolfPeopleKill.Interfaces
{
    public interface IRoomRepo
    {
        public List<Models.Room> GetRoom();
        public List<Models.Room> AddRoom(IEnumerable<Models.Room> result);
        public List<Models.Room> UpdatePlayer(IEnumerable<Models.Room> _list);
        public List<Models.Room> DeleteRoom(IEnumerable<Models.Room> _list);

    }
}
