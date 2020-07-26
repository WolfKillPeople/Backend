using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using WolfPeopleKill.DBModels;
using WolfPeopleKill.Interfaces;
using Dapper;
using Room = WolfPeopleKill.DBModels.Room;
using AutoMapper;

namespace WolfPeopleKill.Repository
{
    /// <summary>
    /// EntityFramework
    /// </summary>
    public class RoomRepository : IRoomRepo
    {
        private readonly WerewolfkillContext _context;
        private readonly IMapper _mapper;

        public RoomRepository(WerewolfkillContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Models.Room> GetRoom()
        {
            var _list = _context.Room.ToList();
            var temp = _mapper.Map<List<DBModels.Room>, List<Models.Room>>(_list);
            return temp;
        }

        public List<Models.Room> AddRoom(IEnumerable<Models.Room> _list)
        {
            var target = new DBModels.Room();
            foreach (var item in _list)
            {
                target.RoomId = item.RoomId;
                target.Player1 = item.Player1;
            }

            _context.Room.Add(target);
            _context.SaveChanges();

            var result = (from r in _context.Room
                where r.RoomId == target.RoomId
                select new Models.Room
                {
                    RoomId = r.RoomId,
                    Player1 = r.Player1,
                    TotalPlayers = 1
                }).ToList();

            return result;
        }

        public List<Models.Room> UpdatePlayer(IEnumerable<Models.Room> _list)
        {

            var target = new DBModels.Room();
            foreach (var item in _list)
            {
                target.RoomId = item.RoomId;
                target.Player1 = item.Player1;
                target.Player2 = item.Player2;
                target.Player3 = item.Player3;
                target.Player4 = item.Player4;
                target.Player5 = item.Player5;
                target.Player6 = item.Player6;
                target.Player7 = item.Player7;
                target.Player8 = item.Player8;
                target.Player9 = item.Player9;
                target.Player10 = item.Player10;
            }



            _context.Room.Update(target);



            var result = (from r in _context.Room
                where r.RoomId == target.RoomId
                select new Models.Room
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

        public void DeleteRoom(IEnumerable<Models.Room> _list)
        {
            try
            {
                var result = new Room();
                foreach (var item in _list)
                {
                    result.RoomId = item.RoomId;
                    result.Player1 = item.Player1;
                    result.Player2 = item.Player2;
                    result.Player3 = item.Player3;
                    result.Player4 = item.Player4;
                    result.Player5 = item.Player5;
                    result.Player6 = item.Player6;
                    result.Player7 = item.Player7;
                    result.Player8 = item.Player8;
                    result.Player9 = item.Player9;
                    result.Player10 = item.Player10;
                }

                var query = _context.Room.Where(x => x.RoomId == result.RoomId);
                _context.Room.RemoveRange(query);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                // ignored
            }
        }







    }
}
           
        
        

       
    

