using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WolfPeopleKill.Models
{
    public class Role
    {
        /// <summary>
        /// 角色id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 角色名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 圖片網址
        /// </summary>
        /// <returns></returns>
        public string ImgUrl { get; set; }

        /// <summary>
        /// 角色描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 角色的陣營
        /// </summary>
        [Required]
        public bool IsGood { get; set; }
    }
}
