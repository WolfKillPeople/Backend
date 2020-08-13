using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WolfPeopleKill.Interfaces;
using WolfPeopleKill.Models;

namespace WolfPeopleKill.Services
{
    public class ShopService : IShopService
    {
        private readonly IShopRepo _repo;
        public ShopService(IShopRepo repo)
        {
            _repo = repo;
        }

        public IEnumerable<Shop> GetShop()
        {
            return _repo.GetShop();
        }
    }
}
