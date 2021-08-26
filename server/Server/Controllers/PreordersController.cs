using BLL;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Models.Preorders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Route("api/preorders")]
    [ApiController]
    public class PreordersController : ControllerBase
    {
        private readonly PreorderService _preorderService;
        private readonly UserService _userService;

        public PreordersController(PreorderService preorderService, UserService userService)
        {
            _preorderService = preorderService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAllPreorders()
        {
            var preorders = _preorderService.GetAllPreorders();

            return Ok(preorders);
        }
        [HttpGet("user")]
        public IActionResult GetAllUserPreorders()
        {
            var user = _userService.GetCurrentUser(HttpContext);
            var userPreorders = _preorderService.GetAllUserPreorders(user.Id);

            return Ok(userPreorders);
        }
        [HttpPost]
        public IActionResult AddPreorder([FromBody] AddPreorderModel model)
        {
            var user = _userService.GetCurrentUser(HttpContext);
            _preorderService.AddPreorder(user, model.EatIds);

            return Ok();
        }
    }
}
