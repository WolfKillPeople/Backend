using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WolfPeopleKill.Models
{
    public class Room
    {
        /// <summary>
        /// 房間ID
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// 玩家ID
        /// </summary>
        [Required]
        public string userId { get; set; }
    }
}
