using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WolfPeopleKill.DTO;
using WolfPeopleKill.Interfaces;
using WolfPeopleKill.Models;

namespace WolfPeopleKill.Services
{
    /// <summary>
    /// Room CRUD With DB
    /// </summary>
    public class RoomDBService
    {
        private readonly RoomDTO _dto;
        
        //public string AddRoom(IEnumerable<Room> data)
        //{
        //    _dto.AddRoomMap(data);
        //    return "ok";
        //}

        //public IEnumerable<Room> GetCurrentRoom()
        //{
        //    var _list = _dto.GetCuurentRooms();
        //    return _list;
        //}

        //public string UpdatePlayer(string team, string userid)
        //{
        //    _dto.UpdateRoomMap(data);
        //    return "ok";
        //}
    }
}
