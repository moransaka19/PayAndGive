using BLL;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Server.Models.Machine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers
{

    [Route("api/machine")]
    public class MachineController : Controller
    {
        private readonly PurchaseService _purchaseService;
        private readonly UserRepository _userRepository;
        private readonly MachineContainerRepository _machineContainerRepository;
        private readonly MachineRepository _machineRepository;

        public MachineController(PurchaseService purchaseService,
            UserRepository userRepository,
            MachineContainerRepository machineContainerRepository,
            MachineRepository machineRepository)
        {
            _purchaseService = purchaseService;
            _userRepository = userRepository;
            _machineContainerRepository = machineContainerRepository;
            _machineRepository = machineRepository;
        }

        [HttpPost("make-purchase")]
        public IActionResult MakePurchase(MachineContainerListModel model)
        {
            var machine = _machineRepository.GetById(model.MachineId);
            var user = _userRepository.GetById(model.UserId);
            var machineContainers = model.machineContainerIds
            .Select(mci => _machineContainerRepository.GetById(mci));

            _purchaseService.MakePurchase(machineContainers, user, machine);

            return Ok();
        }
    }
}
