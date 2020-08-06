using System.ComponentModel.DataAnnotations;

namespace WolfPeopleKill.Models
{
    public class User
    {
        /// <summary>
        /// 玩家ID
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 註冊圖片
        /// </summary>
        [Required]
        public string Pic { get; set; }
    }
}
