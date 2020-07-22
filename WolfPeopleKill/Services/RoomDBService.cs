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

            return _list;

        }

        public List<Room> GetCurrentRoom()
        {
            var _list = _dto.GetCuurentRooms();
            var newList = new List<Room>();
            for (int o = 0; o < _list.Count; o++)
            {
                int count = 0;
                if (_list[o].Player1 != null)
                {
                    count++;
                }
                if (_list[o].Player2 != null)
                {
                    count++;
                }
                if (_list[o].Player3 != null)
                {
                    count++;
                }
                if (_list[o].Player4 != null)
                {
                    count++;
                }
                if (_list[o].Player5 != null)
                {
                    count++;
                }
                if (_list[o].Player6 != null)
                {
                    count++;
                }
                if (_list[o].Player7 != null)
                {
                    count++;
                }
                if (_list[o].Player8 != null)
                {
                    count++;
                }
                if (_list[o].Player9 != null)
                {
                    count++;
                }
                if (_list[o].Player10 != null)
                {
                    count++;
                }
                newList.Add(new Room { RoomId = _list[o].RoomId, Player1 = _list[o].Player1, Player2 = _list[o].Player2, Player3 = _list[o].Player3, Player4 = _list[o].Player4, Player5 = _list[o].Player5, Player6 = _list[o].Player6, Player7 = _list[o].Player7, Player8 = _list[o].Player8, Player9 = _list[o].Player9, Player10 = _list[o].Player10, TotalPlayers = count });

            }
            

           
            //_list.ForEach(x => newList.Add(new Room { RoomId = x.RoomId, Player1 = x.Player1, Player2 = x.Player2, Player3 = x.Player3, Player4 = x.Player4, Player5 = x.Player5, Player6 = x.Player6, Player7 = x.Player7, Player8 = x.Player8, Player9 = x.Player9, Player10 = x.Player10, TotalPlayers = count }));
            return newList;

            
        }

        public List<Room> UpdatePlayer(IEnumerable<Room> data)
        {
            var _list = _dto.UpdateRoomMap(data);
            var newList = new List<Room>();
            int count = 0;
            for (int i = 0; i < _list.Count; i++)
            {
                if (_list[i].Player1 != null)
                {
                    count++;
                }
                if (_list[i].Player2 != null)
                {
                    count++;
                }
                if (_list[i].Player3 != null)
                {
                    count++;
                }
                if (_list[i].Player4 != null)
                {
                    count++;
                }
                if (_list[i].Player5 != null)
                {
                    count++;
                }
                if (_list[i].Player6 != null)
                {
                    count++;
                }
                if (_list[i].Player7 != null)
                {
                    count++;
                }
                if (_list[i].Player8 != null)
                {
                    count++;
                }
                if (_list[i].Player9 != null)
                {
                    count++;
                }
                if (_list[i].Player10 != null)
                {
                    count++;
                }
                newList.Add(new Room { RoomId = _list[i].RoomId, Player1 = _list[i].Player1, Player2 = _list[i].Player2, Player3 = _list[i].Player3, Player4 = _list[i].Player4, Player5 = _list[i].Player5, Player6 = _list[i].Player6, Player7 = _list[i].Player7, Player8 = _list[i].Player8, Player9 = _list[i].Player9, Player10 = _list[i].Player10, TotalPlayers = count });
            }


            return newList;


        }

        public void DeleteRoom(IEnumerable<Room> data)
        {
            _dto.DeleteRoom(data);
        }


    }
}
