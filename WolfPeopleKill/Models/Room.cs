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
        /// 人數
        /// </summary>
        [Required]
        public int People { get; set; }
    }
}
