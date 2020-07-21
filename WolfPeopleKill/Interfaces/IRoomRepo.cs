using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WolfPeopleKill.Interfaces
{
    public interface IRoomRepo
    {
        public IEnumerable<DBModels.Room> GetRoom();
        public List<DBModels.Room> AddRoom(DBModels.Room _list);
        public List<DBModels.Room> UpdatePlayer(DBModels.Room _list);
        public void DeleteRoom(DBModels.Room _list);

    }
}
