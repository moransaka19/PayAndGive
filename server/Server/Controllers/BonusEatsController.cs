using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Models.BonusEats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Route("api/bonus-eats")]
    [ApiController]
    public class BonusEatsController : ControllerBase
    {
        private readonly BonusEatService _bonusEatService;

        public BonusEatsController(BonusEatService bonusEatService)
        {
            _bonusEatService = bonusEatService;
        }

        [HttpGet]
        public IActionResult GetAllBonusEats()
        {
            var bonusEats = _bonusEatService.GetAllBonusEats();

            return Ok(bonusEats);
        }
        [HttpGet("restauran/{id}")]
        public IActionResult GetAllRestaurantBonusEats(int id)
        {
            var restaurantBonusEats = _bonusEatService.GetAllRestaurantBonusEat(id);

            return Ok(restaurantBonusEats);
        }
        [HttpPost]
        public IActionResult AddBonusEat([FromBody] AddBonusEatModel model)
        {
            _bonusEatService.AddBonusEat(model.RestaurantId, model.EatIds);

            return Ok();
        }
    }
}
