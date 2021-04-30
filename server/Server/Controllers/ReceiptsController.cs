using AutoMapper;
using DAL.Interfaces;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Models.Receipt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Route("api/[controller]/{id}")]
    [ApiController]
    public class ReceiptsController : ControllerBase
    {
        private readonly ReceiptRepository _receiptRepository;
        private readonly MachineRepository _machineRepository;
        private readonly UserRepository _userRepository;
        private readonly EatRepository _eatRepository;
        private readonly IMapper _mapper;

        public ReceiptsController(ReceiptRepository receiptRepository,
            MachineRepository machineRepository,
            UserRepository userRepository,
            EatRepository eatRepository,
            IMapper mapper)
        {
            _receiptRepository = receiptRepository;
            _machineRepository = machineRepository;
            _userRepository = userRepository;
            _eatRepository = eatRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddReceipt([FromBody] AddReceiptModel model)
        {
            var machine = _machineRepository.GetById(model.MachineId);
            var user = _userRepository.GetById(model.UserId);
            var eatList = model.EatIdList.Select(e => _eatRepository.GetById(e)).ToList();
            var receipt = new Receipt()
            {
                User = user,
                Machine = machine,
                EatList = eatList
            };
            _receiptRepository.Add(receipt);

            return Ok();
        }

        [HttpGet]
        public IActionResult GetReceipt(int id)
        {
            var receipt = _receiptRepository.GetById(id);

            return Ok(receipt);
        }
    }
}
