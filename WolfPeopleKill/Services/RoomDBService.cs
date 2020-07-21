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
    public class RoomDBService
    {
        private readonly RoomDTO _dto;

        public void AddRoom(IEnumerable<Room> data)
        {
            _dto.AddRoomMap(data);
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
