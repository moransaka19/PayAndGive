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
        public void MakePurchase(ICollection<MContainer> containers, User customer)
        {
            var totalCost = containers.Select(c => c.Eat.Price).Sum();
            customer.Money -= totalCost;
            _userRepository.Update(customer);

            containers.ToList().ForEach(c => _receiptRepository.Add(new Receipt
            {
                User = customer,
                Container = c
            }));

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
