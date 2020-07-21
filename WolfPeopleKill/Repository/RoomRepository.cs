using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using WolfPeopleKill.DBModels;
using WolfPeopleKill.Models;

namespace WolfPeopleKill.Repository
{
    /// <summary>
    /// EntityFramework
    /// </summary>
    public class RoomRepository
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
            var target = _context.Room.FirstOrDefault(x => x.RoomId == _list.RoomId);

            _context.Room.Add(target);
            _context.SaveChanges();

        }

        public void UpdatePlayer(DBModels.Room _list)
        {
            var target = _context.Room.Single(x => x.RoomId == _list.RoomId);

            _context.Room.Update(_list);
            _context.SaveChanges();
        }

        public void DeleteRoom(DBModels.Room _list)
        {
            var target = _context.Room.Single(x => x.RoomId == _list.RoomId); ;
            _context.Room.Remove(target);
            _context.SaveChanges();

        }
    }
}
