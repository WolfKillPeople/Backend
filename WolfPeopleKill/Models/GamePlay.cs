using System.ComponentModel.DataAnnotations;

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
        public bool IsGood { get; set; }


        /// <summary>
        /// 房間ID
        /// </summary>
        [Required]
        public int RoomId { get; set; }

        /// <summary>
        /// 玩家帳號
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 玩家存活狀態
        /// </summary>
        public bool isAlive { get; set; }

        /// <summary>
        /// 玩家個人圖片
        /// </summary>
        public string PlayerPic { get; set; }
    
    }
}
