using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using WolfPeopleKill.Interfaces;
using WolfPeopleKill.Models;

namespace WolfPeopleKill.Services
{
    /// <summary>
    /// Room CRUD
    /// </summary>
    public class RoomService : IRoomService
    {
        private readonly IRoomRepo _repo;
        public RoomService(IRoomRepo repo)
        {
            _repo = repo;
        }

        public IEnumerable<Room> AddRoom(IEnumerable<Room> data, StringBuilder TempRoomId)
        {
            var result = _repo.AddRoom(data);
            return result;
        }



        public List<Room> GetCurrentRoom(StringBuilder TempRoomId)
        {
            var _list = _repo.GetRoom();
            var newList = new List<Room>();

            //foreach (var item in _list)
            //{
            //    int count = 0;
            //    int i = 0;
            //    foreach (var prop in item.GetType().GetProperties())
            //    {
            //        if (prop.Name.ToLower().IndexOf("play") > 0)
            //        {
            //            var test2 = prop.GetValue(item, null);
            //            if (prop.GetValue(item, null) != null)
            //            {
            //                count++;
            //            }
            //        }

            //        i++;
            //    }
            //    newList.Add(new Room { RoomId = item.RoomId, Player1 = item.Player1, Player2 = item.Player2, Player3 = item.Player3, Player4 = item.Player4, Player5 = item.Player5, Player6 = item.Player6, Player7 = item.Player7, Player8 = item.Player8, Player9 = item.Player9, Player10 = item.Player10, TotalPlayers = count });
            //}

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
                newList.Add(new Room { RoomId = _list[o].RoomId, Player1 = _list[o].Player1, Player2 = _list[o].Player2, Player3 = _list[o].Player3, Player4 = _list[o].Player4, Player5 = _list[o].Player5, Player6 = _list[o].Player6, Player7 = _list[o].Player7, Player8 = _list[o].Player8, Player9 = _list[o].Player9, Player10 = _list[o].Player10, TotalPlayers = count, TempRoomID = TempRoomId.ToString() });
            }

            return newList;

        }

        public List<Room> UpdatePlayer(IEnumerable<Room> data, StringBuilder TempRoomId)
        {
            var _list = _repo.UpdatePlayer(data);
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
                newList.Add(new Room { RoomId = _list[i].RoomId, Player1 = _list[i].Player1, Player2 = _list[i].Player2, Player3 = _list[i].Player3, Player4 = _list[i].Player4, Player5 = _list[i].Player5, Player6 = _list[i].Player6, Player7 = _list[i].Player7, Player8 = _list[i].Player8, Player9 = _list[i].Player9, Player10 = _list[i].Player10, TotalPlayers = count, TempRoomID = TempRoomId.ToString() });
            }

            return newList;
        }

        public List<Room> DeleteRoom(IEnumerable<Room> data, StringBuilder TempRoomId)
        {

            var result = _repo.DeleteRoom(data);
            return result;

        }

    }
}
