using DAL.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class ReceiptService
    {
        private readonly ReceiptRepository _receiptRepository;
        private readonly MachineRepository _machineRepository;
        private readonly MachineContainerRepository _machineContainerRepository;
        private readonly UserRepository _userRepository;
        private readonly EatRepository _eatRepository;
        private readonly PurchaseService _purchaseService;

        public ReceiptService(PurchaseService purchaseService, EatRepository eatRepository, UserRepository userRepository, MachineContainerRepository machineContainerRepository, MachineRepository machineRepository, ReceiptRepository receiptRepository)
        {
            _purchaseService = purchaseService;
            _eatRepository = eatRepository;
            _userRepository = userRepository;
            _machineContainerRepository = machineContainerRepository;
            _machineRepository = machineRepository;
            _receiptRepository = receiptRepository;
        }

        public void AddReceipt(int machineId, int userId, ICollection<int> containerIds)
        {
            var machine = _machineRepository.GetById(machineId);
            var user = _userRepository.GetById(userId);
            var machineContainers = containerIds
                .Select(mci => _machineContainerRepository.GetById(mci)).ToList();

            _purchaseService.MakePurchase(machineContainers, user, machine);
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
