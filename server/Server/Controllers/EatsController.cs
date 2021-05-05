using AutoMapper;
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
        private readonly EatRepository _eatRepository;
        private readonly IMapper _mapper;

        public EatsController(EatRepository eatRepository,
            IMapper mapper)
        {
            _eatRepository = eatRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_eatRepository.GetAll());
        }

        [HttpPost]
        public IActionResult AddEat([FromBody] AddEatModel model)
        {
            var eat = _mapper.Map<Eat>(model);
            _eatRepository.Add(eat);

            return Ok();
        }
    }
}
