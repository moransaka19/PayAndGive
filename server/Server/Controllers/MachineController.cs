using AutoMapper;
using BLL;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Server.Models.Machine;
using System.Collections.Generic;

namespace Server.Controllers
{
    using Microsoft.AspNetCore.Authorization;

    [Route("api/machines")]
    public class MachineController : Controller
    {
        private readonly MachineService _machineService;
        private readonly IMapper _mapper;

        public MachineController(IMapper mapper,
            MachineService machineService)
        {
            _mapper = mapper;
            _machineService = machineService;
        }

        [HttpGet]
        public IActionResult GetAllMachines()
        {
            try
            {
                var machines = _machineService.GetAllMachines();

                return Ok(machines);
            }
            catch
            {
                return BadRequest("Error: Machines not found");
            }
        }
        [HttpGet("restaurant/{id}")]
        public IActionResult GetAllRestaurantMachines(int id)
        {
            var machines = _machineService.GetAllRestaurantMachines(id);

            return Ok(machines);
        }
        [HttpGet("{id}")]
        public IActionResult GetMachineById(int id)
        {
            var machine = _machineService.GetMachineById(id);

            return Ok(machine);
        }
        [HttpPost]
        public IActionResult AddMachine([FromBody] AddMachineModel model)
        {
            var machine = _mapper.Map<Machine>(model);
            _machineService.AddMachine(machine);

            return Ok();
        }
    }
}
