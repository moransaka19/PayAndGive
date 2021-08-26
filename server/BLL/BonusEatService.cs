using DAL;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class BonusEatService
    {
        private readonly BonusEatRepository _bonusEatRepository;

        public BonusEatService(BonusEatRepository bonusEatRepository)
        {
            _bonusEatRepository = bonusEatRepository;
        }

        public IEnumerable<BonusEat> GetAllBonusEats()
        {
            return _bonusEatRepository.GetAll();
        }
        public IEnumerable<BonusEat> GetAllRestaurantBonusEat(int id)
        {
            return _bonusEatRepository.GetAll(be => be.RestaurantId == id
                && be.CreatedDateTime.Date == DateTime.Now.Date);
        }
        public void AddBonusEat(int restaurantId, IEnumerable<int> eatIds)
        {
            var datetimeNow = DateTime.Now;

            eatIds.ToList().ForEach(e => _bonusEatRepository.Add(
                new BonusEat
                {
                    CreatedDateTime = datetimeNow,
                    RestaurantId = restaurantId,
                    EatId = e
                })
            );
        }
    }
}
