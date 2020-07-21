using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WolfPeopleKill.Models;

namespace WolfPeopleKill.Interfaces
{
    public interface IRoomService
    {
        public IEnumerable<Room> AddRoom(IEnumerable<Room> data);


        public List<Room> GetCurrentRoom();


        public void UpdatePlayer(IEnumerable<Room> data);

        public void DeleteRoom(IEnumerable<Room> data);
       

    }
}
