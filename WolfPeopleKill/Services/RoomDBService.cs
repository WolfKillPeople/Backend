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
            _dto.AddRoomMap(data);
            int count = 1;
            List<Room> _list = new List<Room>();
           
            foreach (var item in data)
            {
                _list.Add(new Room { RoomId = item.RoomId, Player1 = item.Player1, Player2 = item.Player2, Player3 = item.Player3, Player4 = item.Player4, Player5 = item.Player5, Player6 = item.Player6, Player7 = item.Player7, Player8 = item.Player8, Player9 = item.Player9, Player10 = item.Player10,Length=count });
            }

            return _list;

        }

        public List<Room> GetCurrentRoom()
        {
            var _list = _dto.GetCuurentRooms();
            return _list;
        }

        public void UpdatePlayer(IEnumerable<Room> data)
        {
            _dto.UpdateRoomMap(data);

        }

        public void DeleteRoom(IEnumerable<Room> data)
        {
            _dto.DeleteRoom(data);
        }


    }
}
