using DAL;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class RestaurantService
    {
        private readonly RestaurantRepository _restaurantRepository;
        private readonly RecallService _recallService;

        public RestaurantService(RestaurantRepository restaurantRepository,
            RecallService recallService)
        {
            _restaurantRepository = restaurantRepository;
            _recallService = recallService;
        }

        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            return _restaurantRepository.GetAll();
        }
        public Restaurant GetByIdRestaurant(int id)
        {
            return _restaurantRepository.GetById(id);
        }
        public void AddRestaurant(Restaurant model)
        {
            _restaurantRepository.Add(model);
        }
        public double GetRestaurantRating(int id)
        {
            var restaurantRecalls = _recallService.GetAllRestaurantRecalls(id);
            var restaurantRecallsCount = restaurantRecalls.ToList().Count;
            var restaurantRatingsSum = restaurantRecalls.Select(rr => rr.Rating).Sum();

            return restaurantRatingsSum / restaurantRecallsCount;
        }
    }
}
