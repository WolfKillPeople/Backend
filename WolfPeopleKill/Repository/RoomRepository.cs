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
            var target = _mapper.Map<List<Models.Room>, List<DBModels.Room>>(_list.ToList());
            _context.Room.AddRange(target);

            var list = _context.AspNetUsers.ToList().Find(x => x.UserName.Contains(_list.ToList()[0].Player1));
            list.RoomId = _list.ToList()[0].RoomId;
            _context.AspNetUsers.Update(list);
            _context.SaveChanges();

            var contextList = _context.Room.Where(x => x.RoomId == target[0].RoomId).ToList();
            var result = _mapper.Map<List<DBModels.Room>, List<Models.Room>>(contextList);
            var num = _context.Room.ToList().LastOrDefault().RoomId;
            if (num == 1)
            {
                result.ToList()[0].TempRoomID = "2";
                return result;
            }

            for (int i = 0; i < _context.Room.ToList().Count; i++)
            {
                if (_context.Room.ToList()[i].RoomId != i + 1)
                {
                    result.ToList()[0].TempRoomID = (i + 1).ToString();
                    return result;
                }
            }
            result.ToList()[0].TempRoomID = (num + 1).ToString();
            return result;

        }

        public List<Models.Room> UpdatePlayer(IEnumerable<Models.Room> _list)
        {
            var newList = _list.ToList();
            var target = _mapper.Map<List<Models.Room>, List<DBModels.Room>>(newList);
            _context.Room.UpdateRange(target);



            if (_context.AspNetUsers.ToList().SingleOrDefault(x => x.UserName == _list.ToList()[0].Player1) != null)
            {
                var Players1 = _context.AspNetUsers.ToList().SingleOrDefault(x => x.UserName == _list.ToList()[0].Player1);
                Players1.RoomId = _list.ToList()[0].RoomId;
                _context.AspNetUsers.Update(Players1);
            }
            if (_context.AspNetUsers.ToList().SingleOrDefault(x => x.UserName == _list.ToList()[0].Player2) != null)
            {
                var Players2 = _context.AspNetUsers.ToList().SingleOrDefault(x => x.UserName == _list.ToList()[0].Player2);
                Players2.RoomId = _list.ToList()[0].RoomId;
                _context.AspNetUsers.Update(Players2);
            }
            if (_context.AspNetUsers.ToList().SingleOrDefault(x => x.UserName == _list.ToList()[0].Player3) != null)
            {
                var Players3 = _context.AspNetUsers.ToList().SingleOrDefault(x => x.UserName == _list.ToList()[0].Player3);
                Players3.RoomId = _list.ToList()[0].RoomId;
                _context.AspNetUsers.Update(Players3);
            }
            if (_context.AspNetUsers.ToList().SingleOrDefault(x => x.UserName == _list.ToList()[0].Player4) != null)
            {
                var Players4 = _context.AspNetUsers.ToList().SingleOrDefault(x => x.UserName == _list.ToList()[0].Player4);
                Players4.RoomId = _list.ToList()[0].RoomId;
                _context.AspNetUsers.Update(Players4);
            }
            if (_context.AspNetUsers.ToList().SingleOrDefault(x => x.UserName == _list.ToList()[0].Player5) != null)
            {
                var Players5 = _context.AspNetUsers.ToList().SingleOrDefault(x => x.UserName == _list.ToList()[0].Player5);
                Players5.RoomId = _list.ToList()[0].RoomId;
                _context.AspNetUsers.Update(Players5);
            }
            if (_context.AspNetUsers.ToList().SingleOrDefault(x => x.UserName == _list.ToList()[0].Player6) != null)
            {
                var Players6 = _context.AspNetUsers.ToList().SingleOrDefault(x => x.UserName == _list.ToList()[0].Player6);
                Players6.RoomId = _list.ToList()[0].RoomId;
                _context.AspNetUsers.Update(Players6);
            }
            if (_context.AspNetUsers.ToList().SingleOrDefault(x => x.UserName == _list.ToList()[0].Player7) != null)
            {
                var Players7 = _context.AspNetUsers.ToList().SingleOrDefault(x => x.UserName == _list.ToList()[0].Player7);
                Players7.RoomId = _list.ToList()[0].RoomId;
                _context.AspNetUsers.Update(Players7);
            }
            if (_context.AspNetUsers.ToList().SingleOrDefault(x => x.UserName == _list.ToList()[0].Player8) != null)
            {
                var Players8 = _context.AspNetUsers.ToList().SingleOrDefault(x => x.UserName == _list.ToList()[0].Player8);
                Players8.RoomId = _list.ToList()[0].RoomId;
                _context.AspNetUsers.Update(Players8);
            }
            if (_context.AspNetUsers.ToList().SingleOrDefault(x => x.UserName == _list.ToList()[0].Player9) != null)
            {
                var Players9 = _context.AspNetUsers.ToList().SingleOrDefault(x => x.UserName == _list.ToList()[0].Player9);
                Players9.RoomId = _list.ToList()[0].RoomId;
                _context.AspNetUsers.Update(Players9);
            }
            if (_context.AspNetUsers.ToList().SingleOrDefault(x => x.UserName == _list.ToList()[0].Player10) != null)
            {
                var Players10 = _context.AspNetUsers.ToList().SingleOrDefault(x => x.UserName == _list.ToList()[0].Player10);
                Players10.RoomId = _list.ToList()[0].RoomId;
                _context.AspNetUsers.Update(Players10);
            }
            _context.SaveChanges();
            var roomList = _context.Room.Where(x => x.RoomId == target[0].RoomId).ToList();
            var result = _mapper.Map<List<DBModels.Room>, List<Models.Room>>(roomList);
            return result;
        }


        public List<Models.Room> DeleteRoom(IEnumerable<Models.Room> _list)
        {
            var newList = _list.ToList();
            var target = _mapper.Map<List<Models.Room>, List<DBModels.Room>>(newList);
            _context.Room.RemoveRange(target);
            _context.SaveChanges();

            for (int i = 0; i < _context.Room.ToList().Count; i++)
            {
                if (_context.Room.ToList()[i].RoomId != i + 1)
                {
                    var result = (from r in _context.Room
                                  select new Models.Room
                                  {
                                      TempRoomID = (i + 1).ToString()
                                  }).Take(1).ToList();
                    return result;
                }
            }
            return null;


        }







    }
}







