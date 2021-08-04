using AutoMapper;
using BLL;
using DAL.Interfaces;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Models.Containers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly MachineService _machineService;

        public ContainersController(MachineContainerRepository machineContainerRepository,
            IMapper mapper,
            MachineService machineService,
            UserRepository userRepository,
            ReceiptRepository receiptRepository)
        {
            _machineContainerRepository = machineContainerRepository;
            _mapper = mapper;
            _machineService = machineService;
            _userRepository = userRepository;
            _receiptRepository = receiptRepository;
        }

        [HttpGet("{id}")]
        public IActionResult GetContainerById(int id)
        {
            var container = _machineService.GetContainerById(id);

            return Ok(container);
        }

        [HttpPost]
        public IActionResult CreateMachineContainer([FromBody] CreateMachineContainerModel model)
        {
            var container = _mapper.Map<MContainer>(model);
            _machineService.AddContainer(container);

            return Ok();
        }

        [HttpGet("machines/{id}")]
        public IActionResult GetAllMachineContainers(int id)
        {
            try
            {
                var containers = _machineService.GetAllContainers(id);
                var models = _mapper.Map<ICollection<GetMachineContainerModel>>(containers);

                return Ok(models);
            }
            catch
            {
                return BadRequest("Error: Containers not found");
            }
        }

        [HttpGet("sold-machines/{id}")]
        public IActionResult GetAllSoldMachineContainers(int id)
        {
            try
            {
                var containers = _machineService.GetAllSoldMachineContainers(id);
                var models = _mapper.Map<ICollection<GetMachineContainerModel>>(containers);

                return Ok(models);
            }
            catch
            {
                return BadRequest("Error: Containers not found");
            }
        }

        [HttpGet("user")]
        public IActionResult GetAllUserContainers()
        {
            try
            {
                //TODO: Create new service for this
                var userId = int.Parse(HttpContext.User
                    .Claims.First(c => c.Type == JwtRegisteredClaimNames.Sub)
                    .Value);
                var containers = _machineService.GetAllUserContainers(userId);
               
                return Ok(containers);
            }
            catch
            {

                return BadRequest("Error: User's containers not found or user do not make purchase yet");
            }
        }

    }
}
