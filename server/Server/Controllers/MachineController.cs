using AutoMapper;
using BLL;
using DAL.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Server.Models.Machine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Controllers
{
    using Microsoft.AspNetCore.Authorization;

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

        [HttpGet("not-deleted")]
        public IActionResult GetNotDeletedMachines()
        {
            var machines = _machineRepository.GetAll(m => m.MachineContainers.Any(x => !x.IsDeleted))
                .ToList()
                .Select(x =>
                {
                    x.MachineContainers = x.MachineContainers.Where(z => !z.IsDeleted);

                    return x;
                });
            var result = _mapper.Map<IEnumerable<MachineModel>>(machines);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetMachineById(int id)
        {
            var machine = _mapper.Map<MachineModel>(_machineRepository.GetById(id));

            return Ok(machine);
        }

        [AllowAnonymous]
        [HttpGet("{id}/containers")]
        public IActionResult GetNotProcessedMachines(int id)
        {
            var containers = _machineContainerRepository.GetAll(x => x.MachineId == id && !x.IsDeleted).ToList();
            
            containers.ForEach(x =>
            {
                x.IsDeleted = true;
                _machineContainerRepository.Update(x);
            });

            return Ok(_mapper.Map<ContainerModel[]>(containers));
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
