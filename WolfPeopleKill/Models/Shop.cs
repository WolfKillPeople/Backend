using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WolfPeopleKill.Models
{
    public class Shop
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 商品名稱
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 商品價格
        /// </summary>
        public int Price { get; set; }
    }
}
