using AutoMapper;
using BLL;
using DAL.Interfaces;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Models.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainersController : ControllerBase
    {
        private readonly MachineContainerRepository _machineContainerRepository;
        private readonly IMapper _mapper;
        private readonly MachineService _machineService;

        public ContainersController(MachineContainerRepository machineContainerRepository,
            IMapper mapper,
            MachineService machineService)
        {
            _machineContainerRepository = machineContainerRepository;
            _mapper = mapper;
            _machineService = machineService;
        }

        [HttpGet("{id}")]
        public IActionResult GetContainerById(int id)
        {
            var container = _machineContainerRepository.GetById(id);
            
            return Ok(container);
        }
        
        [HttpPost]
        public IActionResult CreateMachineContainer(CreateMachineContainerModel model)
        {
            var container = _mapper.Map<MachineContainer>(model);
            _machineContainerRepository.Add(container);

            return Ok();
        }

        [HttpGet("machines/{id}")]
        public IActionResult GetAllMachineContainers(int id)
        {
            try
            {

                var containers = _machineService.GetAllContainers(id);

                return Ok(containers);
            }
            catch
            {

                return BadRequest();
            }
        }

    }
}
