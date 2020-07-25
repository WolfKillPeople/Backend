using Microsoft.VisualStudio.TestTools.UnitTesting;
using WolfPeopleKill.Services;
using System;
using System.Collections.Generic;
using System.Text;
using WolfPeopleKill.Models;

namespace WolfPeopleKill.Services.Tests
{
    [TestClass()]
    public class RoomServiceTests
    {
        [TestMethod()]
        public void GetCurrentRoomTest()
        {
            var _list = new List<Room>
            {
                new Room{RoomId = 1,Player1="David",Player2="Teresa",Player3="John",Player4="Jo",Player5="Jay",Player6=null,Player7=null,Player8=null,Player9=null,Player10=null },
                new Room{RoomId = 1,Player1="David",Player2="Teresa",Player3="John",Player4=null,Player5=null,Player6=null,Player7=null,Player8=null,Player9=null,Player10=null },
                new Room{RoomId = 1,Player1="David",Player2="Teresa",Player3="John",Player4=null,Player5="Jay",Player6=null,Player7=null,Player8=null,Player9=null,Player10=null }

            };

            var newList = new List<Room>();
            for (int o = 0; o < _list.Count; o++)
            {
                var count = 0;
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


            Assert.AreEqual(5, newList[0].TotalPlayers);
            Assert.AreEqual(3, newList[1].TotalPlayers);
            Assert.AreEqual(4, newList[2].TotalPlayers);
        }

       
    }
}