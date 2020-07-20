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
        public void AddRoomTest()
        {
            StringBuilder sb = new StringBuilder();
            List<Room> data = new List<Room>()
            {
                new Room{RoomId = 1, userId = "1"},
            };

            foreach (var item in data)
            {
                var userID = Convert.ToString(item.userId);
                sb.AppendLine(userID);
            }
            var str = Convert.ToString(sb);
            string ex = "1";
            Assert.AreEqual(ex,str.Trim());
        }
    }
}