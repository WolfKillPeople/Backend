using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WolfPeopleKill.Models
{
    public class Buy
    {
        /// <summary>
        /// user id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 產品ID
        /// </summary>
        public Guid ProductId{ get; set; }
    }
}
