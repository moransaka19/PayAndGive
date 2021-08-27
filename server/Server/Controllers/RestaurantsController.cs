using AutoMapper;
using BLL;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Server.Models.Restaurants;
using System.Collections.Generic;
using System.Linq;

namespace Server.Controllers
{
    [Route("api/restaurants")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly RestaurantService _restaurantService;
        private readonly IMapper _mapper;

        public RestaurantsController(RestaurantService resaurantService, IMapper mapper)
        {
            _restaurantService = resaurantService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllRestaurants()
        {
            var restaurants = _restaurantService.GetAllRestaurants();

            return Ok(restaurants);
        }
        [HttpGet("google-map")]
        public IActionResult GetAllGoogleMapRestaurants()
        {
            var restaurants = _restaurantService.GetAllRestaurants().ToList();
            var ratingRestaurants = new List<RatingRestaurantModel>();
            restaurants.ForEach(r =>
            {
                ratingRestaurants.Add(new RatingRestaurantModel
                {
                    Name = r.Name,
                    Lang = r.Lang,
                    Lat = r.Lat,
                    Rating = _restaurantService.GetRestaurantRating(r.Id)
                });
            });

            return Ok(ratingRestaurants);
        }
        [HttpPost]
        public IActionResult AddRestaurant([FromBody] AddRestaurantModel model)
        {
            var restaurant = _mapper.Map<Restaurant>(model);
            _restaurantService.AddRestaurant(restaurant);

            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetByIdRestaurant(int id)
        {
            var restaurant = _restaurantService.GetByIdRestaurant(id);

            return Ok(restaurant);
        }
        [HttpGet("{id}/rating")]
        public IActionResult GetRestoutantRating(int id)
        {
            var rating = _restaurantService.GetRestaurantRating(id);
            var ratingModel = new RatingModel
            {
                Rating = rating
            };

            return Ok(ratingModel);
        }
        [HttpGet("eats-google-chart/{id}")]
        public IActionResult GetAllRestaurantEats(int id)
        {
            var eats = _restaurantService.GetEatGoogleMapModels(id);
            var eatGoogleMapModel = eats.Select(e => new EatCountryPriceModel { Country = e.Key, Price = e.Value });
            return Ok(eatGoogleMapModel);
        }
    }
}
