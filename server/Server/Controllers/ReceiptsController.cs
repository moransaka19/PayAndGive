using AutoMapper;
using BLL;
using DAL.Interfaces;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Models.Receipt;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Authorize(Roles = "Customer")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptsController : ControllerBase
    {
        private readonly ReceiptRepository _receiptRepository;
        private readonly MachineRepository _machineRepository;
        private readonly MachineContainerRepository _machineContainerRepository;
        private readonly UserRepository _userRepository;
        private readonly EatRepository _eatRepository;
        private readonly PurchaseService _purchaseService;
        private readonly IMapper _mapper;

        public ReceiptsController(ReceiptRepository receiptRepository,
            MachineRepository machineRepository,
            MachineContainerRepository machineContainerRepository,
            UserRepository userRepository,
            EatRepository eatRepository,
            PurchaseService purchaseService,
            IMapper mapper)
        {
            _receiptRepository = receiptRepository;
            _machineRepository = machineRepository;
            _machineContainerRepository = machineContainerRepository;
            _userRepository = userRepository;
            _eatRepository = eatRepository;
            _purchaseService = purchaseService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddReceipt([FromBody] AddReceiptModel model)
        {

            var machine = _machineRepository.GetById(model.MachineId);
            var user = _userRepository.GetById(model.UserId);
            var machineContainers = model.ContainersId
            .Select(mci => _machineContainerRepository.GetById(mci)).ToList();

            _purchaseService.MakePurchase(machineContainers, user, machine);

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetReceipt(int id)
        {
            var receipt = _receiptRepository.GetById(id);

            return Ok(receipt);
        }

        [HttpGet("user")]
        public IActionResult GetAllUserReceipts()
        {
            var userId = int.Parse(HttpContext.User
                .Claims.First(c => c.Type == JwtRegisteredClaimNames.Sub)
                .Value);

            var user = _userRepository.GetById(userId);
            var userReceipts = _receiptRepository.GetAll(r => r.User == user);

            return Ok(userReceipts);
        }
    }
}
