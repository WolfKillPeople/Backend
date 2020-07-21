using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WolfPeopleKill.Interfaces
{
    public interface IRoomRepo
    {
        public IEnumerable<DBModels.Room> GetRoom();
        public void AddRoom(DBModels.Room _list);
        public void UpdatePlayer(DBModels.Room _list);
        public void DeleteRoom(DBModels.Room _list);

    }
}
