using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WolfPeopleKill.Models;

namespace WolfPeopleKill.Interfaces
{
    public interface IBuyRepo
    {
        /// <summary>
        /// 讀取購買資料
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Buy> GetBuy();
        /// <summary>
        /// 新增購買資料
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<Buy> NewBuy(Buy data);
    }
}
