using BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Models.Auth;
using Server.Models.Users;

namespace Server.Controllers
{
    [Authorize]
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly PurchaseService _purchaseService;

        public UserController(UserService userService,
            PurchaseService purchaseService)
        {
            _userService = userService;
            _purchaseService = purchaseService;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();

            return Ok(users);
        }
        [HttpGet("{id}")]
        public IActionResult GetByIdUser(int id)
        {
            var user = _userService.GetById(id);

            return Ok(user);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _userService.DeleteUser(id);

            return Ok();
        }

        [HttpPost("add-money")]
        public IActionResult AddMoney([FromBody] AddMoneyModel model)
        {
            var user = _userService.GetCurrentUser(HttpContext);
            _userService.AddMoney(user, model.Money);

            return Ok();
        }
        [HttpGet("bonus")]
        public IActionResult GetBonus()
        {
            var bonus = _purchaseService.GetUserBonusPercent(HttpContext);
            var bonusModel = new BonusModel
            {
                PercentDiscount = bonus
            };

            return Ok(bonusModel);
        }
    }
}
