using System.ComponentModel.DataAnnotations;

namespace WolfPeopleKill.Models
{
    public class Room
    {
        /// <summary>
        /// 房間ID
        /// </summary>
        [Required]
        public int RoomId { get; set; }

        /// <summary>
        /// 玩家帳號
        /// </summary>
        public string? Player1 { get; set; }
        /// <summary>
        /// 玩家帳號
        /// </summary>
        public string? Player2 { get; set; }
        /// <summary>
        /// 玩家帳號
        /// </summary>
        public string? Player3 { get; set; }
        /// <summary>
        /// 玩家帳號
        /// </summary>
        public string? Player4 { get; set; }
        /// <summary>
        /// 玩家帳號
        /// </summary>
        public string? Player5 { get; set; }
        /// <summary>
        /// 玩家帳號
        /// </summary>
        public string? Player6 { get; set; }
        /// <summary>
        /// 玩家帳號
        /// </summary>
        public string? Player7 { get; set; }
        /// <summary>
        /// 玩家帳號
        /// </summary>
        public string? Player8 { get; set; }
        /// <summary>
        /// 玩家帳號
        /// </summary>
        public string? Player9 { get; set; }
        /// <summary>
        /// 玩家帳號
        /// </summary>
        public string? Player10 { get; set; }

        /// <summary>
        /// 房間人數
        /// </summary>
        public int TotalPlayers { get; set; }

        /// <summary>
        /// Room ID Session
        /// </summary>
        public string TempRoomID { get; set; }
    }
}
