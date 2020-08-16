using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using WolfPeopleKill.Models;

namespace WolfPeopleKill.Services.Tests
{
    [TestClass()]
    public class GameServiceTests
    {
        static List<VotePlayers> votePlayers = new List<VotePlayers>();

        [TestMethod()]
        public void WinOrLoseTest()
        {
            var data = new List<Role>()
            {
                //new Role{Id=1, Name="狼王",ImgUrl="https://imgur.com/fVQQgnM",Description="狼王",IsGood=false},
                //new Role{Id=2,Name = "狼人",ImgUrl="https://imgur.com/n7knadr",Description="狼人",IsGood=false},
                //new Role{Id=3,Name="狼人",ImgUrl="https://imgur.com/n7knadr",Description="狼人",IsGood=false},
                new Role{Id=4,Name="預言家",ImgUrl="https://imgur.com/8tiIFAB",Description="預言家",IsGood=true},
                new Role{Id=5,Name="女巫",ImgUrl="https://imgur.com/i9eRyug",Description="女巫",IsGood=true},
                new Role{Id=6,Name="獵人",ImgUrl="https://imgur.com/TIvcUG5",Description="獵人",IsGood=true},
                new Role{Id=7,Name="村民",ImgUrl="https://imgur.com/4eJqZgk",Description="村民男",IsGood=true},
                new Role{Id=8,Name="村民",ImgUrl="https://imgur.com/D2o6MV6",Description="村民女",IsGood=true},
                new Role{Id=9,Name="村民",ImgUrl="https://imgur.com/4eJqZgk",Description="村民男",IsGood=true},
                new Role{Id=10,Name="村民",ImgUrl="https://imgur.com/D2o6MV6",Description="村民男",IsGood=true}
            };

            var tempBad = 0;
            var tempGood = 0;
            var tempNormalPeople = 0;
            foreach (var item in data)
            {
                switch (item.Id)
                {
                    case 1:
                    case 2:
                    case 3:
                        tempBad++;
                        break;
                    case 4:
                    case 5:
                    case 6:
                        tempGood++;
                        break;
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                        tempNormalPeople++;
                        break;
                }
            }

            const bool goodGuyWin = true;
            const bool badGuyWin = false;
            const string noOneWin = "還沒結束";

            switch (tempGood)
            {
                case 0:
                    Assert.IsFalse(badGuyWin);
                    break;
                default:
                    {
                        switch (tempBad)
                        {
                            case 0:
                                Assert.IsTrue(goodGuyWin);
                                break;
                            default:
                                {
                                    if (tempNormalPeople == 0)
                                    {
                                        Assert.IsFalse(badGuyWin);
                                    }
                                    else
                                    {
                                        Assert.AreEqual(noOneWin, "還沒結束");
                                    }
                                    break;

                                }
                        }
                        break;
                    }
            }

        }

        [TestMethod()]
        public void GetRoleTest()
        {
            var _listed = new List<Role>()
            {
                new Role{Id=1, Name="狼王",ImgUrl="https://imgur.com/fVQQgnM",Description="狼王",IsGood=false},
                new Role{Id=2,Name = "狼人",ImgUrl="https://imgur.com/n7knadr",Description="狼人",IsGood=false},
                new Role{Id=3,Name="狼人",ImgUrl="https://imgur.com/n7knadr",Description="狼人",IsGood=false},
                new Role{Id=4,Name="預言家",ImgUrl="https://imgur.com/8tiIFAB",Description="預言家",IsGood=true},
                new Role{Id=5,Name="女巫",ImgUrl="https://imgur.com/i9eRyug",Description="女巫",IsGood=true},
                new Role{Id=6,Name="獵人",ImgUrl="https://imgur.com/TIvcUG5",Description="獵人",IsGood=true},
                new Role{Id=7,Name="村民",ImgUrl="https://imgur.com/4eJqZgk",Description="村民男",IsGood=true},
                new Role{Id=8,Name="村民",ImgUrl="https://imgur.com/D2o6MV6",Description="村民女",IsGood=true},
                new Role{Id=9,Name="村民",ImgUrl="https://imgur.com/4eJqZgk",Description="村民男",IsGood=true},
                new Role{Id=10,Name="村民",ImgUrl="https://imgur.com/D2o6MV6",Description="村民男",IsGood=true}
            };


            var _list = new List<Role>()
            {
                new Role{Id=1, Name="狼王",ImgUrl="https://imgur.com/fVQQgnM",Description="狼王",IsGood=false},
                new Role{Id=2,Name = "狼人",ImgUrl="https://imgur.com/n7knadr",Description="狼人",IsGood=false},
                new Role{Id=3,Name="狼人",ImgUrl="https://imgur.com/n7knadr",Description="狼人",IsGood=false},
                new Role{Id=4,Name="預言家",ImgUrl="https://imgur.com/8tiIFAB",Description="預言家",IsGood=true},
                new Role{Id=5,Name="女巫",ImgUrl="https://imgur.com/i9eRyug",Description="女巫",IsGood=true},
                new Role{Id=6,Name="獵人",ImgUrl="https://imgur.com/TIvcUG5",Description="獵人",IsGood=true},
                new Role{Id=7,Name="村民",ImgUrl="https://imgur.com/4eJqZgk",Description="村民男",IsGood=true},
                new Role{Id=8,Name="村民",ImgUrl="https://imgur.com/D2o6MV6",Description="村民女",IsGood=true},
                new Role{Id=9,Name="村民",ImgUrl="https://imgur.com/4eJqZgk",Description="村民男",IsGood=true},
                new Role{Id=10,Name="村民",ImgUrl="https://imgur.com/D2o6MV6",Description="村民男",IsGood=true}
            };

            var index = 0;
            var random = new Random();

            for (int i = 0; i < _list.Count; i++)
            {
                index = random.Next(0, _list.Count - 1);
                if (index == i) continue;
                var temp = _list[i];
                _list[i] = _list[index];
                _list[index] = temp;
            };


            Assert.AreNotEqual(_listed[0].Id, _list[0].Id);
        }

        [TestMethod()]
        public void VotesTest()
        {
            var data = new List<VotePlayers>()
            {
                new VotePlayers{RoomID = 1, User="Text001@gmail.com", Vote="1",voteResult = null},
                new VotePlayers{RoomID = 1, User="Text002@gmail.com", Vote="2",voteResult = null},
                new VotePlayers{RoomID = 1, User="Text003@gmail.com", Vote="2",voteResult = null},
                new VotePlayers{RoomID = 1, User="Text004@gmail.com", Vote="2",voteResult = null},
                new VotePlayers{RoomID = 1, User="Text005@gmail.com", Vote="4",voteResult = null},
                new VotePlayers{RoomID = 1, User="Text006@gmail.com", Vote="3",voteResult = null},
                new VotePlayers{RoomID = 1, User="Text007@gmail.com", Vote="8",voteResult = null},
                new VotePlayers{RoomID = 1, User="Text008@gmail.com", Vote="2",voteResult = null},
                new VotePlayers{RoomID = 1, User="Text009@gmail.com", Vote="1",voteResult = null},
                new VotePlayers{RoomID = 1, User="Text0010@gmail.com", Vote="9",voteResult = null},
            };

            var _list = new List<VotePlayers>();

            votePlayers.ForEach(x => x.VoteTickets = 0);

            if (votePlayers.Exists(x => data.ToList()[0].User == x.User) == false)
            {
                votePlayers.AddRange(data);
            }
            else
            {
                var index = votePlayers.IndexOf(data.ToList()[0]);
                votePlayers.InsertRange(index, data);
            }

            var newData = data.ToList().FindAll(x => x.Vote != null).ToList();
            newData.ForEach(i => votePlayers[Convert.ToInt32(i.Vote) - 1].VoteTickets++);


            var ran = new Random();
            var newVotePlayers = votePlayers.OrderByDescending(x => x.VoteTickets).ToList();
            newVotePlayers.ForEach(x => { x.voteResult = x.Vote; x.User = null; });

            if (newVotePlayers.Count > 1 && newVotePlayers[0].VoteTickets == newVotePlayers[1].VoteTickets)
            {
                for (var r = 0; r < newVotePlayers.Count; r++)
                {
                    var index = ran.Next(0, newVotePlayers.Count - 1);
                    if (index == r) continue;
                    var temp = votePlayers[r];
                    votePlayers[r] = votePlayers[index];
                    votePlayers[index] = temp;
                };
            }

            Assert.AreEqual(4, newVotePlayers.Take(1).ToList()[0].VoteTickets);

        }
    }
}