using DAL.Interfaces;
using Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class ReceiptService
    {
        private readonly UserService _userService;
        private readonly ReceiptRepository _receiptRepository;
        private readonly MachineRepository _machineRepository;
        private readonly ContainerRepository _machineContainerRepository;
        private readonly UserRepository _userRepository;
        private readonly EatRepository _eatRepository;
        private readonly PurchaseService _purchaseService;

        public ReceiptService(PurchaseService purchaseService, EatRepository eatRepository, UserRepository userRepository, ContainerRepository machineContainerRepository, MachineRepository machineRepository, ReceiptRepository receiptRepository, UserService userService)
        {
            _purchaseService = purchaseService;
            _eatRepository = eatRepository;
            _userRepository = userRepository;
            _machineContainerRepository = machineContainerRepository;
            _machineRepository = machineRepository;
            _receiptRepository = receiptRepository;
            _userService = userService;
        }

        public void AddReceipt(HttpContext http, ICollection<int> containerIds)
        {
            var machineContainers = containerIds
                .Select(mci => _machineContainerRepository.GetById(mci)).ToList();

            _purchaseService.MakePurchase(machineContainers, http);
        }

        public Receipt GetReceiptById(int id)
        {
            return _receiptRepository.GetById(id);
        }

        public IEnumerable<Receipt> GetAllUserReceipts(User user)
        {
            return _receiptRepository.GetAll(r => r.User == user);
        }
    }
}
