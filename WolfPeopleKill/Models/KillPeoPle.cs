﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WolfPeopleKill.Models
{
    public class KillPeoPle
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
        /// <summary>
        /// 職業
        /// </summary>
        public string Occupation_Name { get; set; }
        /// <summary>
        /// 是否存活
        /// </summary>
        public string IsAlive { get; set; }
    }
}
