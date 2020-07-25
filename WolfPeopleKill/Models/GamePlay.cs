using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WolfPeopleKill.Models
{
    public class GamePlay
    {
       
        /// <summary>
        /// 角色名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 圖片網址
        /// </summary>
        public string ImgUrl { get; set; }

        /// <summary>
        /// 職業ID
        /// </summary>
        public int OccupationId { get; set; }

        /// <summary>
        /// 角色描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 角色的陣營
        /// </summary>
        [Required]
        public bool IsGood { get; set; }


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
        /// 玩家存活狀態
        /// </summary>
        public bool isAlive { get; set; }

    
    }
}
