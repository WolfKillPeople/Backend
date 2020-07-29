using System.Collections.Generic;
using WolfPeopleKill.Models;

namespace WolfPeopleKill.Interfaces
{
    public interface IRoomService
    {
        public IEnumerable<Room> AddRoom(IEnumerable<Room> data,string session);


        public List<Room> GetCurrentRoom(string tempSession);


        public List<Room> UpdatePlayer(IEnumerable<Room> data,string tempSession);

        public List<Room> DeleteRoom(IEnumerable<Room> data,string session);
       

    }
}
