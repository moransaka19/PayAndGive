using AutoMapper;
using BLL;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Models.Containers;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainersController : ControllerBase
    {
        private readonly ContainerService _containerService;
        private readonly IMapper _mapper;

        public ContainersController(IMapper mapper,
            ContainerService containerService)
        {
            _mapper = mapper;
            _containerService = containerService;
        }

        [HttpGet("{id}")]
        public IActionResult GetContainerById(int id)
        {
            var container = _containerService.GetByIdContainer(id);

            return Ok(container);
        }
        [HttpPost]
        public IActionResult AddContainer([FromBody] AddContainerModel model)
        {
            var container = _mapper.Map<Container>(model);
            _containerService.AddContainer(container);

            return Ok();
        }
        [HttpGet("machines/{id}")]
        public IActionResult GetAllMachineContainers(int id)
        {
            try
            {
                var containers = _containerService.GetAllMachineContainers(id);

                return Ok(containers);
            }
            catch
            {
                return BadRequest("Error: Containers not found");
            }
        }
        [HttpGet("sold")]
        public IActionResult GetAllSoldContainers()
        {
            var soldContainers = _containerService.GetAllSoldContainersForMap();

            return Ok(soldContainers);
        }
        [HttpGet("not-sold-machines/{id}")]
        public IActionResult GetAllNotSoldContainers(int id)
        {
            var containers = _containerService.GetAllNotSoldContainers(id);

            return Ok(containers);
        }
        [HttpGet("sold-machines/{id}")]
        public IActionResult GetAllSoldMachineContainers(int id)
        {
            try
            {
                var containers = _containerService.GetAllSoldMachineContainers(id);

                return Ok(containers);
            }
            catch
            {
                return BadRequest("Error: Containers not found");
            }
        }
        //TODO: Relalize with Restaurant
        [HttpGet("google-map/{id}")]
        public IActionResult GetAllContainersForGoogleMap(int id)
        {
            //var eats = _machineService.GetAllSoldContainersForGoogleMap(id);

            return Ok();
        }
        //[HttpGet("user")]
        //public IActionResult GetAllUserContainers()
        //{
        //    try
        //    {
        //        //TODO: Create new service for this
        //        var userId = int.Parse(HttpContext.User
        //            .Claims.First(c => c.Type == JwtRegisteredClaimNames.Sub)
        //            .Value);
        //        var containers = _machineService.GetAllUserContainers(userId);
               
        //        return Ok(containers);
        //    }
        //    catch
        //    {

        //        return BadRequest("Error: User's containers not found or user do not make purchase yet");
        //    }
        //}
    }
}
