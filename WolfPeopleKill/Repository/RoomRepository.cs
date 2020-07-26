using System;
using System.Linq;
using System.Collections.Generic;
using WolfPeopleKill.DBModels;
using WolfPeopleKill.Interfaces;
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
            var result = _mapper.Map<List<DBModels.Room>, List<Models.Room>>(_list);
            return result;
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
            var newList = _list.ToList();
            var target = _mapper.Map<List<Models.Room>, List<DBModels.Room>>(newList);
            _context.Room.UpdateRange(target);
            _context.SaveChanges();

            var Roomlist = _context.Room.Where(x => x.RoomId == target[0].RoomId).ToList();
            var result = _mapper.Map<List<DBModels.Room>, List<Models.Room>>(Roomlist);
            return result;
        }


        public void DeleteRoom(IEnumerable<Models.Room> _list)
        {
            try
            {
                var newList = _list.ToList();
                var result = _mapper.Map<List<Models.Room>, List<DBModels.Room>>(newList);
                _context.Room.RemoveRange(result);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                // ignored
            }
        }







    }
}
           
        
        

       
    

