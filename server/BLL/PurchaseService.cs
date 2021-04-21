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

        public PurchaseService(UserRepository userRepository, ReceiptRepository receiptRepository)
        {
            _userRepository = userRepository;
            _receiptRepository = receiptRepository;
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
        }
    }
}
