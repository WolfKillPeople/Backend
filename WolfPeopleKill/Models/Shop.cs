using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WolfPeopleKill.Models
{
    public class Shop
    {
        /// <summary>
        /// 產品ID
        /// </summary>
        public Guid ProductId { get;set;}
        /// <summary>
        /// 產品名稱
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 產品價格
        /// </summary>
        public float Price { get; set; }
        /// <summary>
        /// 產品圖片
        /// </summary>
        public string Pic { get; set; }
        /// <summary>
        /// 產品明細
        /// </summary>
        public string Description { get; set; }

    }
}
