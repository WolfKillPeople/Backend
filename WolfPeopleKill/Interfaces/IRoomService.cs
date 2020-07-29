using System.Collections.Generic;
using System.Text;
using WolfPeopleKill.Models;

namespace WolfPeopleKill.Interfaces
{
    public interface IRoomService
    {
        public IEnumerable<Room> AddRoom(IEnumerable<Room> data,StringBuilder TempRoomId);


        public List<Room> GetCurrentRoom(StringBuilder TempRoomId);


        public List<Room> UpdatePlayer(IEnumerable<Room> data, StringBuilder TempRoomId);

        public List<Room> DeleteRoom(IEnumerable<Room> data, StringBuilder TempRoomId);
       

    }
}
