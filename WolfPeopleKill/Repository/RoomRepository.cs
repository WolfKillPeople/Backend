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

        public List<DBModels.Room> AddRoom(DBModels.Room _list)
        {
            _context.Room.Add(_list);
                _context.SaveChanges();
                var result = (from r in _context.Room
                              where r.RoomId == _list.RoomId
                              select new DBModels.Room
                              {
                                  RoomId = r.RoomId,
                                  Player1 = r.Player1
                              }).ToList();
                return result;

        }

        public List<DBModels.Room> UpdatePlayer(DBModels.Room _list)
        {
            
                _context.Room.Update(_list);
                _context.SaveChanges();
                var result = (from r in _context.Room
                              where r.RoomId == _list.RoomId
                              select new DBModels.Room
                              {
                                  RoomId = r.RoomId,
                                  Player1 = r.Player1,
                                  Player2 = r.Player2,
                                  Player3 = r.Player3,
                                  Player4 = r.Player4,
                                  Player5 = r.Player5,
                                  Player6 = r.Player6,
                                  Player7 = r.Player7,
                                  Player8 = r.Player8,
                                  Player9 = r.Player9,
                                  Player10 = r.Player10
                              }).ToList();
                return result;
        }

        public void DeleteRoom(DBModels.Room _list)
        {
            try
            {
                _context.Room.Remove(_list);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                
            }
         
        }
    }
}
