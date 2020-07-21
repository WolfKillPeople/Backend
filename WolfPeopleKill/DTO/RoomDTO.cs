using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Linq;
using WolfPeopleKill.Interfaces;
using WolfPeopleKill.Models;

namespace WolfPeopleKill.DTO
{
    public class RoomDTO : IRoomDTO
    {
        private readonly IRoomRepo _repo;
        public RoomDTO(IRoomRepo repo)
        {
            _repo = repo;
        }
        public List<Models.Room> AddRoomMap(IEnumerable<Models.Room> data)
        {
            var result = new DBModels.Room();

            foreach (var item in data)
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

            var _list = _repo.AddRoom(result);
            var newList = (from l in _list
                           select new Models.Room
                           {
                               RoomId = l.RoomId,
                               Player1 = l.Player1,
                           }).ToList();
            return newList;


        }


        public List<Room> UpdateRoomMap(IEnumerable<Models.Room> data)
        {
            var result = new DBModels.Room();

            foreach (var item in data)
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

            var _list = _repo.UpdatePlayer(result);
            
            var newList = (from l in _list
                           select new Models.Room
                           {
                               RoomId = l.RoomId,
                               Player1 = l.Player1,
                               Player2 = l.Player2,
                               Player3 = l.Player3,
                               Player4 = l.Player4,
                               Player5 = l.Player5,
                               Player6 = l.Player6,
                               Player7 = l.Player7,
                               Player8 = l.Player8,
                               Player9 = l.Player9,
                               Player10 = l.Player10
                           }).ToList();

            return newList;
        }

        public List<Models.Room> GetCuurentRooms()
        {
            var _list = _repo.GetRoom();

            var result = (from l in _list
                          select new Models.Room
                          {
                              RoomId = l.RoomId,
                              Player1 = l.Player1,
                              Player2 = l.Player2,
                              Player3 = l.Player3,
                              Player4 = l.Player4,
                              Player5 = l.Player5,
                              Player6 = l.Player6,
                              Player7 = l.Player7,
                              Player8 = l.Player8,
                              Player9 = l.Player9,
                              Player10 = l.Player10
                          }).ToList();
            return result;
        }

        public void DeleteRoom(IEnumerable<Models.Room> data)
        {
            var result = new DBModels.Room();
            foreach (var item in data)
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
            _repo.DeleteRoom(result);
        }
    }
}
