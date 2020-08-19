using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WolfPeopleKill.Interfaces;
using WolfPeopleKill.Models;

namespace WolfPeopleKill.Services
{
    public class StoreService:IStoreService
    {
        private readonly IStoreRepo _repo;
        public StoreService(IStoreRepo repo)
        {
            _repo = repo;
        }
        public List<Store> NewScore(Store data)
        {
            return _repo.PostScore(data);
        }

    }
}
