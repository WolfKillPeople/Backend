using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WolfPeopleKill.Interfaces
{
    public interface IRoomRepo
    {
        public List<Models.Room> GetRoom();
        public List<Models.Room> AddRoom(IEnumerable<Models.Room> result);
        public List<Models.Room> UpdatePlayer(IEnumerable<Models.Room> _list);
        public void DeleteRoom(IEnumerable<Models.Room> _list);

    }
}
