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
        private readonly MachineContainerRepository _machineContainerRepository;
        private readonly IMapper _mapper;
        private readonly MachineService _machineService;
        private readonly UserRepository _userRepository;
        private readonly ReceiptRepository _receiptRepository;

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
            var container = _machineContainerRepository.GetById(id);

            return Ok(container);
        }

        [HttpPost]
        public IActionResult CreateMachineContainer([FromBody] CreateMachineContainerModel model)
        {
            var container = _mapper.Map<MContainer>(model);
            _machineContainerRepository.Add(container);

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
                return BadRequest();
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
                return BadRequest();
            }
        }

        [HttpGet("user")]
        public IActionResult GetAllUserContainers()
        {
            try
            {

                var userId = int.Parse(HttpContext.User
                    .Claims.First(c => c.Type == JwtRegisteredClaimNames.Sub)
                    .Value);

                var user = _userRepository.GetById(userId);
                var userContainers = _receiptRepository.GetAll(r => r.User == user)
                    .SelectMany(r => r.Containers);

                return Ok(userContainers);
            }
            catch
            {

                return BadRequest();
            }
        }

    }
}
