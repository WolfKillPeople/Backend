using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using WolfPeopleKill.DBModels;
using WolfPeopleKill.Interfaces;
using WolfPeopleKill.Models;

namespace WolfPeopleKill.Repository
{
    /// <summary>
    /// EntityFramework
    /// </summary>
    public class RoomRepository : IRoomRepo
    {
        private readonly WerewolfkillContext _context;

        public RoomRepository(WerewolfkillContext context)
        {
            _context = context;
        }

        public IEnumerable<DBModels.Room> GetRoom()
        {
            var _list = _context.Room.ToList();
            return _list;

        }

        public void AddRoom(DBModels.Room _list)
        {
            _context.Room.Add(_list);
            _context.SaveChanges();
          
        }

        public void UpdatePlayer(DBModels.Room _list)
        {
            var target = _context.Room.Single(x => x.RoomId == _list.RoomId);

            _context.Room.Update(_list);
            _context.SaveChanges();

            //var newList = new List<DBModels.Room>();
            
            //newList.Add(new DBModels.Room { RoomId = _list.RoomId, Player1 = _list.Player1, Player2 = _list.Player2, Player3 = _list.Player3, Player4 = _list.Player4, Player5 = _list.Player5,Player6=_list.Player6,Player7=_list.Player7,Player8=_list.Player8,Player9=_list.Player9,Player10=_list.Player10 });
            //return newList;
        }

        public void DeleteRoom(DBModels.Room _list)
        {
            var target = _context.Room.Single(x => x.RoomId == _list.RoomId);
            _context.Room.Remove(target);
            _context.SaveChanges();

            //var newList = new List<DBModels.Room>();
            //newList.Add(new DBModels.Room { RoomId = _list.RoomId, Player1 = _list.Player1, Player2 = _list.Player2, Player3 = _list.Player3, Player4 = _list.Player4, Player5 = _list.Player5, Player6 = _list.Player6, Player7 = _list.Player7, Player8 = _list.Player8, Player9 = _list.Player9, Player10 = _list.Player10 });
            //return newList;

        }
    }
}
