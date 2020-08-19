using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WolfPeopleKill.Models;

namespace WolfPeopleKill.Interfaces
{
    public interface IStoreRepo
    {
        /// <summary>
        /// post Score
        /// </summary>
        /// <returns></returns>
        public List<Store> PostScore(Store data);

        //public List<Store> NewScore(Store data);

    }
}
