using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WolfPeopleKill.Models;
using WolfPeopleKill.Repository;

namespace WolfPeopleKill.DTO
{
    public class RoomDTO
    {
        private RoomRepository _repo;
        //public void AddRoomMap(IEnumerable<Room> data)
        //{
        //    var result = (from d in data
        //        select new
        //        {
        //            d.userId,
        //            d.RoomId
        //        }).ToList();
        //    _repo.AddRoom(result);

        //}
        //public void UpdateRoomMap(IEnumerable<Room> data)
        //{
        //    var result = (from d in data
        //                  select new
        //                  {
        //                      d.userId,
        //                      d.RoomId
        //                  }).ToList();
        //    _repo.UpdateRoom(result);
        //}

        //public IEnumerable<Room> GetCuurentRooms()
        //{
        //    var _list = _repo.GetRoom();
            
        //}
    }
}
