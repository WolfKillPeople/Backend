using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WolfPeopleKill.Interfaces
{
    public interface IRoomDTO
    {
        public void AddRoomMap(IEnumerable<Models.Room> data);
        public void UpdateRoomMap(IEnumerable<Models.Room> data);
        public List<Models.Room> GetCuurentRooms();
        public void DeleteRoom(IEnumerable<Models.Room> data);

    }
}
