using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WolfPeopleKill.Models
{
    public class VotePlayers
    {
        /// <summary>
        /// 房間ID
        /// </summary>
        [Required]
        public int RoomID { get; set; }
        /// <summary>
        /// 玩家帳號
        /// </summary>
        [Required]
        public string Player { get; set; }

        /// <summary>
        /// 投票對象
        /// </summary>
        [Required]
        public string PlayersPoll { get; set; }

        /// <summary>
        /// 投票結果
        /// </summary>
        public string Results { get; set; }
    }
}
