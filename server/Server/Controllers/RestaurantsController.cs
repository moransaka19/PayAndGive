using AutoMapper;
using BLL;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Server.Models.Restaurants;

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
    }
}
