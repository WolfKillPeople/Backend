﻿using System;
using System.Collections.Generic;
using WolfPeopleKill.Models;
using WolfPeopleKill.Interfaces;
using System.Collections;
using System.Linq;
using System.Runtime.CompilerServices;

namespace WolfPeopleKill.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepo _repo;
        static List<VotePlayers> votePlayers = new List<VotePlayers>();
        public GameService(IGameRepo repo)
        {
            _repo = repo;
        }

        public List<GamePlay> RoomGetPlayers(IEnumerable<GamePlay> data)
        {
            return _repo.RoomGetPlayers(data.ToList());
        }

        public List<GamePlay> GetRole(IEnumerable<GamePlay> data)
        {
            var _o = 0;
            var _list = _repo.GetRoles();
            var players = _repo.RoomGetPlayers(data.ToList());


            var random = new Random();
            for (var i = 0; i < _list.Count; i++)
            {
                var index = random.Next(0, _list.Count - 1);
                if (index == i) continue;
                var temp = _list[i];
                _list[i] = _list[index];
                _list[index] = temp;
            };

            foreach (var d in players)
            {
                d.Name = _list[_o].Name;
                d.OccupationId = _list[_o].Id;
                d.ImgUrl = _list[_o].ImgUrl;
                d.IsGood = _list[_o].IsGood;
                d.Description = _list[_o].Description;
                _o++;
            }

            _repo.PushGetRoles(players);

            return players;
        }


        public string WinOrLose(IEnumerable<Role> data)
        {
            var tempBad = 0;
            var tempGood = 0;
            var tempNormalPeople = 0;
            foreach (var item in data)
            {
                switch (item.Name)
                {
                    case "狼王":
                    case "狼人":
                        tempBad++;
                        break;
                    case "預言家":
                    case "女巫":
                    case "獵人":
                        tempGood++;
                        break;
                    case "村民":
                        tempNormalPeople++;
                        break;
                }
            }

            const string goodGuyWin = "好人獲勝";
            const string badGuyWin = "狼人獲勝";
            const string noOneWin = "還沒結束";

            switch (tempGood)
            {
                case 0:
                    return badGuyWin;
                default:
                    {
                        switch (tempBad)
                        {
                            case 0:
                                return goodGuyWin;
                            default:
                                {
                                    return tempNormalPeople == 0 ? badGuyWin : noOneWin;
                                }
                        }
                    }
            }

        }

        public IEnumerable<VotePlayers> Votes(IEnumerable<VotePlayers> data)
        {
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

            for (int i = 0; i < votePlayers.Count; i++)
            {
                for (int o = 0; o < votePlayers.Count; o++)
                {
                    if (votePlayers[i].Vote == votePlayers[o].Vote)
                    {
                        votePlayers[i].VoteTickets++;
                    }
                }
            }

            Random ran = new Random();
            votePlayers.OrderByDescending(x => x.VoteTickets);

            for (int i = 0; i < votePlayers.Count; i++)
            {
                for (int o = 0; o < votePlayers.Count; o++)
                {
                    if (votePlayers[i].VoteTickets == votePlayers[o].VoteTickets)
                    {
                        dynamic temp;
                        for (var r = 0; r < votePlayers.Count; r++)
                        {
                            var index = ran.Next(0, votePlayers.Count - 1);
                            if (index != r)
                            {
                                temp = votePlayers[r];
                                votePlayers[r] = votePlayers[index];
                                votePlayers[index] = temp;
                            }
                        };


                        votePlayers.ForEach(x => { x.voteResult = x.Vote; x.User = null; });
                        return votePlayers;
                    }
                }
            }


            votePlayers.ForEach(x => { x.voteResult = x.Vote; x.User = null; });
            return votePlayers;
        }

        public List<KillPeoPle> PatchCurrentPlayer(IEnumerable<KillPeoPle> data)
        {
            _repo.PatchCurrentPlayer(data.ToList());
            return _repo.GetCurrentPlayer(data.ToList());
        }

        public List<KillPeoPle> Savepeople(IEnumerable<KillPeoPle> data)
        {
            _repo.Savepeople(data.ToList());
            return _repo.GetCurrentPlayer(data.ToList());
        }

        public List<Models.Occupation> Observer(KillPeoPle data)
        {
            return _repo.Observer(data);
        }

        public List<OutToRoom> OutToRoom(OutToRoom data)
        {
            return _repo.OutToRoom(data);
        }
        public List<GameWin> GameWin(GameWin data)
        {
            return _repo.GameWin(data);
        }
        
    }
}
