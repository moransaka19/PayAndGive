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
        public void MakePurchase(IEnumerable<MachineContainer> containers, User customer, Machine machine)
        {
            var totalCost = containers.Select(c => c.Eat.Price).Sum();
            customer.Money = customer.Money - totalCost;
            var eatList = containers.Select(c => c.Eat);
            _userRepository.Update(customer);

            _receiptRepository.Add(new Receipt
            {
                Machine = machine,
                User = customer,
                EatList = eatList
            });

            var emptyContainers = containers.Select(c =>
            {
                c.IsEmpty = true;

                return c;
            }).ToList();

            emptyContainers.ForEach(ec => _machineContainerRepository.Update(ec));
        }
        public void LoadContainers(IEnumerable<MachineContainer> containers)
        {
            containers.Select(c =>
            {
                c.IsEmpty = false;
                c.FixedLoadingTime = DateTime.Now;

                return c;
            })
            .ToList()
            .ForEach(c => _machineContainerRepository.Update(c));
        }
    }
}
