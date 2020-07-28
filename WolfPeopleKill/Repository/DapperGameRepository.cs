﻿using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;
using WolfPeopleKill.DBModels;
using WolfPeopleKill.Interfaces;
using WolfPeopleKill.Models;
using Room = WolfPeopleKill.Models.Room;

namespace WolfPeopleKill.Repository
{
    /// <summary>
    /// Dapper
    /// </summary>
    public class DapperGameRepository : IGameRepo
    {
        private readonly string connStr =
                "data source=werewolfkill.database.windows.net;initial catalog=Werewolfkill;persist security info=True;user id=Werewolfkill;password=Wolfpeoplekill_2020;MultipleActiveResultSets=True;";
        private readonly WerewolfkillContext _context;

        public DapperGameRepository(WerewolfkillContext context)
        {
            _context = context;
        }
        public List<GamePlay> RoomGetPlayers(List<Models.GamePlay> data)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                var sql = "select * from AspNetUsers where RoomId = @RoomId";
                var total = conn.Query<AspNetUsers>(sql, data[0]).ToList();
                var result = new List<GamePlay>();
                foreach (var item in total)
                {
                    result.Add(new GamePlay { RoomId = Convert.ToInt32(item.RoomId), Player = item.UserName, PlayerPic = item.Pic });
                }
                return result;
            }
        }
        public List<Role> GetRoles()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                const string sql = "select top 10 Occupation_Name, Occupation_GB, Pic, About from Occupation";
                var col = conn.Query<dynamic>(sql).ToList();
                var result = (from c in col
                              select new Role
                              {
                                  Name = c.Occupation_Name,
                                  IsGood = Convert.ToBoolean(c.Occupation_GB),
                                  ImgUrl = c.Pic,
                                  Description = c.About
                              }).ToList();
                return result;
            }
        }

        public List<Models.Room> GetPlayers(List<GamePlay> data)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                var sql = "select * from Room where RoomID = @RoomId";
                var result = conn.Query<Room>(sql, data[0]).ToList();
                return result;
            }
        }

        public void PatchCurrentPlayer(List<Models.Room> data)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                var paramater = new Room { RoomId = data[0].RoomId, Player1 = data[0].Player1, Player2 = data[0].Player2, Player3 = data[0].Player3, Player4 = data[0].Player4, Player5 = data[0].Player5, Player6 = data[0].Player6, Player7 = data[0].Player7, Player8 = data[0].Player8, Player9 = data[0].Player9, Player10 = data[0].Player10 };
                //var paramater = new Room { RoomId = data.RoomId, player = data.Pl};
                var sql = "update GameRoom set isAlive = 'false' where Players = 'string' and RoomId = 1";
                conn.Query<Room>(sql, paramater);
            }
        }
        public List<string> GetCurrentPlayer()
        {
            IEnumerable<string> r = null;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                //var paramater = new Room { RoomId = data.RoomId, Player1 = data.Player1, Player2 = data.Player2, Player3 = data.Player3, Player4 = data.Player4, Player5 = data.Player5, Player6 = data.Player6, Player7 = data.Player7, Player8 = data.Player8, Player9 = data.Player9, Player10 = data.Player10 };
                var sql = "select Players from GameRoom where isAlive = 'True'";
                r = conn.Query<string>(sql);
            }
            return r.ToList();
        }



        //推資料進GameRoom資料表
        public void PushGetRoles(IEnumerable<Models.GamePlay> datas)
        {
            foreach (var item in datas)
            {
                var data = new GameRoom()
                {
                    RoomId = item.RoomId,
                    Players = item.Player,
                    OccupationId = _context.Occupation.FirstOrDefault(x => x.OccupationName == item.Name).OccupationId,
                    IsAlive = item.isAlive.ToString(),
                };
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    var paramater = new GameRoom { RoomId = data.RoomId, Players = data.Players, OccupationId = data.OccupationId, IsAlive = data.IsAlive };
                    //var sql = "update Room set RoomID = @RoomId,player1 = @Player1,player2 = @Player2,player3 = @Player3,player4 = @Player4,player5 = @Player5,player6 = @Player6,player7 = @Player7,player8 = @Player8,player9 = @Player9,player10 = @Player10";
                    var sql = "  insert into [dbo].[GameRoom](RoomId,Players,OccupationId,isAlive)values(@RoomId, @Players, @OccupationId, @IsAlive)";
                    conn.Query<GameRoom>(sql, paramater);
                }
            }

        }
    }
}
