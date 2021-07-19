using AutoMapper;
using BLL;
using DAL.Interfaces;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Models.Eats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EatsController : ControllerBase
    {
        private readonly EatService _eatService;
        private readonly IMapper _mapper;

        public EatsController(EatService eatService,
            IMapper mapper)
        {
            _eatService = eatService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var eats = _eatService.GetAllEats();

                return Ok(eats);
            }
            catch (Exception)
            {
                return BadRequest("Error: Eats not found");
                
            }

        }

        [HttpPost]
        public IActionResult AddEat([FromBody] AddEatModel model)
        {
            var eat = _mapper.Map<Eat>(model);
            _eatService.CreateEat(eat);

            return Ok();
        }
    }
}
