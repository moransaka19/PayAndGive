using AutoMapper;
using BLL;
using DAL.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Server.Models.Machine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Route("api/machines")]
    public class MachineController : Controller
    {
        private readonly PurchaseService _purchaseService;
        private readonly UserRepository _userRepository;
        private readonly MachineContainerRepository _machineContainerRepository;
        private readonly MachineRepository _machineRepository;
        private readonly IMapper _mapper;

        public MachineController(PurchaseService purchaseService,
            UserRepository userRepository,
            MachineContainerRepository machineContainerRepository,
            MachineRepository machineRepository,
            IMapper mapper)
        {
            _purchaseService = purchaseService;
            _userRepository = userRepository;
            _machineContainerRepository = machineContainerRepository;
            _machineRepository = machineRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetMachines()
        {
            var machines = _mapper.Map<IEnumerable<MachineModel>>(_machineRepository.GetAll());

            return Ok(machines);
        }

        [HttpGet("{id}")]
        public IActionResult GetMachineById(int id)
        {
            var machine = _mapper.Map<MachineModel>(_machineRepository.GetById(id));

            return Ok(machine);
        }

        [HttpPost]
        public IActionResult AddMachine([FromBody] AddMachineModel model)
        {
            var machine = _mapper.Map<Machine>(model);
            _machineRepository.Add(machine);

            return Ok();
        }
    }
}
