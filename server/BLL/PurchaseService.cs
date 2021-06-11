using DAL.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class PurchaseService
    {
        private readonly UserRepository _userRepository;
        private readonly ReceiptRepository _receiptRepository;
        private readonly MachineContainerRepository _machineContainerRepository;

        public PurchaseService(UserRepository userRepository,
            ReceiptRepository receiptRepository,
            MachineContainerRepository machineContainerRepository)
        {
            _userRepository = userRepository;
            _receiptRepository = receiptRepository;
            _machineContainerRepository = machineContainerRepository;
        }
        public void MakePurchase(ICollection<MContainer> containers, User customer, Machine machine)
        {
            var totalCost = containers.Select(c => c.Eat.Price).Sum();
            customer.Money -= totalCost;
            _userRepository.Update(customer);

            _receiptRepository.Add(new Receipt
            {
                Machine = machine,
                User = customer,
                Containers = containers
            });

            var emptyContainers = containers.Select(c =>
            {
                c.IsDeleted = true;
                c.ReadyForOpen = true;
                return c;
            }).ToList();

            emptyContainers.ForEach(ec => _machineContainerRepository.Update(ec));
        }
    }
}
