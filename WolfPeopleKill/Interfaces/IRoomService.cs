using System.Collections.Generic;
using WolfPeopleKill.Models;

namespace WolfPeopleKill.Interfaces
{
    public interface IRoomService
    {
        public IEnumerable<Room> AddRoom(IEnumerable<Room> data);


        public List<Room> GetCurrentRoom();


        public List<Room> UpdatePlayer(IEnumerable<Room> data);

        public void DeleteRoom(IEnumerable<Room> data);
       

    }
}
