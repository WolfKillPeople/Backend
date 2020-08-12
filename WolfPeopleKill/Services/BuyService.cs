using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WolfPeopleKill.Interfaces;
using WolfPeopleKill.Models;

namespace WolfPeopleKill.Services
{
    public class BuyService:IBuyService
    {
        private readonly IBuyRepo _repo;
        public BuyService(IBuyRepo repo)
        {
            _repo = repo;
        }

        public IEnumerable<Buy> GetBuy()
        {
            return _repo.GetBuy();
        }
        public List<Buy> NewBuy(Buy data)
        {
            return _repo.NewBuy(data);
        }
    }
}
