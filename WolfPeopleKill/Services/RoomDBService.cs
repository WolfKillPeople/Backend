using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WolfPeopleKill.DTO;
using WolfPeopleKill.Interfaces;
using WolfPeopleKill.Models;
using WolfPeopleKill.Repository;

namespace WolfPeopleKill.Services
{
    /// <summary>
    /// Room CRUD With DB
    /// </summary>
    public class RoomDBService :IRoomService
    {
        private IRoomDTO _dto;
        public RoomDBService(IRoomDTO dto)
        {
            _dto = dto;
        }

        public IEnumerable<Room> AddRoom(IEnumerable<Room> data)
        {
            var _list = _dto.AddRoomMap(data);
            int count = _list.Count();
            List<Room> newList = new List<Room>();
           
            foreach (var item in data)
            {
                newList.Add(new Room { RoomId = item.RoomId,Length = count });
            }

            return newList;

        }

        public List<Room> GetCurrentRoom()
        {
            var _list = _dto.GetCuurentRooms();
            return _list;
        }

        public List<Room> UpdatePlayer(IEnumerable<Room> data)
        {
            var _list = _dto.UpdateRoomMap(data);

            int count = 0;
            for (int i = 0; i < _list.Count; i++)
            {
                if (_list[0].Player1 != null)
                {
                    count++;
                }
                if (_list[0].Player2 != null)
                {
                    count++;
                }
                if (_list[0].Player3 != null)
                {
                    count++;
                }
                if (_list[0].Player4 != null)
                {
                    count++;
                }
                if (_list[0].Player5 != null)
                {
                    count++;
                }
                if (_list[0].Player6 != null)
                {
                    count++;
                }
                if (_list[0].Player7 != null)
                {
                    count++;
                }
                if (_list[0].Player8 != null)
                {
                    count++;
                }
                if (_list[0].Player9 != null)
                {
                    count++;
                }
                if (_list[0].Player10 != null)
                {
                    count++;
                }

            }

            var newList = new List<Room>();
            _list.ForEach(x => newList.Add(new Room { RoomId = x.RoomId, Player1 = x.Player1, Player2 = x.Player2, Player3 = x.Player3, Player4 = x.Player4, Player5 = x.Player5, Player6 = x.Player6, Player7 = x.Player7, Player8 = x.Player8, Player9 = x.Player9, Player10 = x.Player10, Length = count }));
            return newList;
            

        }

        public void DeleteRoom(IEnumerable<Room> data)
        {
            _dto.DeleteRoom(data);
        }


    }
}
