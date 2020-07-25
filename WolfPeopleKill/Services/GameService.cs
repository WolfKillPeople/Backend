using System;
using System.Collections.Generic;
using WolfPeopleKill.Models;
using WolfPeopleKill.Interfaces;
using System.Collections;
using System.Linq;
using WolfPeopleKill.DBModels;

namespace WolfPeopleKill.Services
{
    public class GameService : IGameService
    {
        private readonly IGameDTO _gameDto;
        private readonly IGameRepo _gameRole;


        public GameService(IGameDTO gameDto, IGameRepo gameRole)
        {
            _gameDto = gameDto;
            _gameRole = gameRole;
        }

        public List<GamePlay> GetRole(IEnumerable<GamePlay> data)
        {

            var _list = _gameDto.GetRole_Map();

            var players = _gameDto.GetPlayers_Map(data);

            string player1 = "";
            string player2 = "";
            string player3 = "";
            string player4 = "";
            string player5 = "";
            string player6 = "";
            string player7 = "";
            string player8 = "";
            string player9 = "";
            string player10 = "";
            int roomId = 0;

            ArrayList ary = new ArrayList();

            foreach (var item in players)
            {
                roomId = item.RoomId;
                player1 = item.Player1;
                player2 = item.Player2;
                player3 = item.Player3;
                player4 = item.Player4;
                player5 = item.Player5;
                player6 = item.Player6;
                player7 = item.Player7;
                player8 = item.Player8;
                player9 = item.Player9;
                player10 = item.Player10;
            }

            ary.Add(player1);
            ary.Add(player2);
            ary.Add(player3);
            ary.Add(player4);
            ary.Add(player5);
            ary.Add(player6);
            ary.Add(player7);
            ary.Add(player8);
            ary.Add(player9);
            ary.Add(player10);

            var newary = ary.ToArray();
            var newList = new List<GamePlay>();

            for (int i = 0; i < newary.Length; i++)
            {
                newList.Add(new GamePlay { RoomId = roomId, Player = Convert.ToString(newary[i]), Name = _list[i].Name, ImgUrl = _list[i].ImgUrl, Description = _list[i].Description, IsGood = _list[i].IsGood, isAlive = true });
            }

            var random = new Random();
            dynamic temp;
            for (var i = 0; i < newList.Count; i++)
            {
                var index = random.Next(0, newList.Count - 1);
                if (index != i)
                {
                    temp = newList[i];
                    newList[i] = newList[index];
                    newList[index] = temp;
                }
            };

            //var convertList = newList.Select(x => new GameRoom()
            //{

            //    //'@RoomId', '@Players', '@OccupationId', '@IsAlive'
            //     RoomId = x.RoomId,
            //     Players = x.Player,
            //     OccupationId = ,
            //});
            _gameRole.PushGetRoles(newList);
            return newList;
        }

        public IEnumerable<string> PatchCurrentPlayer(IEnumerable<Models.Room> data)
        {
            _gameDto.PatchCurrentPlayer(data);
            return _gameRole.GetCurrentPlayer();
        }

        public string WinOrLose(IEnumerable<Role> data)
        {
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
    }
}
