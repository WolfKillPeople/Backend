using System.ComponentModel.DataAnnotations;

namespace WolfPeopleKill.Models
{
    public class UserWin
    {
        /// <summary>
        /// 玩家ID
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 積分加減
        /// </summary>
        public int win { get; set; }
    }
}
