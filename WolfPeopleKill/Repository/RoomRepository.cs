using System;
using System.Collections.Generic;
using System.Linq;
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
        //public IEnumerable<Room> GetRoom()
        //{
        //    _context.
        //}

        //public void AddRoom()
        //{
        //    _context.
        //}

        //public void UpdateRoom()
        //{
        //    _context.
        //}
    }
}
