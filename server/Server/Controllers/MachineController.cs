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
        public IActionResult GetMachines()
        {
            try
            {
                var machines = _machineService.GetAllMachines();
                //TODO: Remove this mapping
                var machineModels = _mapper.Map<IEnumerable<MachineModel>>(machines);

                return Ok(machineModels);
            }
            catch
            {
                return BadRequest("Error: Machines not found");
            }
        }

        [HttpGet("not-deleted")]
        public IActionResult GetNotDeletedMachines()
        {
            var machines =_machineService.GetNotDeletedMachines();
            var result = _mapper.Map<IEnumerable<MachineModel>>(machines);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetMachineById(int id)
        {
            var machine = _machineService.GetMachineById(id);
            //TODO: Remove this mapping
            var machineModel = _mapper.Map<MachineModel>(machine);

            return Ok(machineModel);
        }

        //TODO: Think about it
        [AllowAnonymous]
        [HttpGet("{id}/containers")]
        public IActionResult GetNotProcessedMachines(int id)
        {
            var containers = _machineService.GetNotProcessedMachines(id);

            return Ok(_mapper.Map<ContainerModel[]>(containers));
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
