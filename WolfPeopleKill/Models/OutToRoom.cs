using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WolfPeopleKill.Models
{
    public class OutToRoom
    {
        /// <summary>
        /// 房間ID
        /// </summary>
        [Required]
        public int RoomId { get; set; }
        /// <summary>
        /// 玩家帳號
        /// </summary>
        public string Player { get; set; }
    }
}
