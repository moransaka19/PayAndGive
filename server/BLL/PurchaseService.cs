using DAL;
using DAL.Interfaces;
using Domain;
using Microsoft.AspNetCore.Http;
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
        private readonly ContainerRepository _machineContainerRepository;
        private readonly BonusEatRepository _bonusEatRepository;
        private readonly UserService _userService;

        public PurchaseService(UserRepository userRepository,
            ReceiptRepository receiptRepository,
            ContainerRepository machineContainerRepository,
            BonusEatRepository bonusEatRepository, UserService userService)
        {
            _userRepository = userRepository;
            _receiptRepository = receiptRepository;
            _machineContainerRepository = machineContainerRepository;
            _bonusEatRepository = bonusEatRepository;
            _userService = userService;
        }
        public void MakePurchase(ICollection<Container> containers, HttpContext http)
        {
            var customer = _userService.GetCurrentUser(http);
            var totalCost = containers.Select(c => c.Eat.Price).Sum();
            var bonus = GetUserBonusPercent(http);

            if (bonus != 0)
            {
                totalCost = totalCost * bonus / 100;
            }

            customer.Money -= totalCost;
            _userRepository.Update(customer);

            containers.ToList().ForEach(c => _receiptRepository.Add(new Receipt
            {
                User = customer,
                Container = c
            }));

            var boughtContainers = containers.Select(c =>
            {
                c.IsBought = true;

                return c;
            }).ToList();

            boughtContainers.ForEach(ec => _machineContainerRepository.Update(ec));
        }

        public int GetUserBonusPercent(HttpContext httpContext)
        {
            var user = _userService.GetCurrentUser(httpContext);
            var userContainers = _receiptRepository.GetAllReceiptWithContainer().Where(r => r.User == user).Select(r => r.Container);
            var userBonusEatContainers = userContainers.Where(uc => IsContainerWithBonusEat(uc));
            var bonusCount = ValideBonusPurchases(userBonusEatContainers);
            var discountPercentBonus = 0;

            if (bonusCount > 3)
            {
                discountPercentBonus = 5;
            }

            if (bonusCount > 5)
            {
                discountPercentBonus = 10;
            }

            return discountPercentBonus;
        }
        private bool IsContainerWithBonusEat(Container container)
        {
            bool isValid = false;

            _bonusEatRepository.GetAll().ToList().ForEach(be =>
            {
                if (be.CreatedDateTime.Date == container.CreatedTime.Date && be.Eat == container.Eat)
                {
                    isValid = true;
                }

            });

            return isValid;
        }
        private int ValideBonusPurchases(IEnumerable<Container> containers)
        {
            var countBonusPurchases = 0;
            var dateTimeFlag = DateTime.Now.AddDays(-1);

            var datesBonusPurchasing = containers.Select(c => c.CreatedTime.Date).Distinct().OrderByDescending(d => d.Date).ToList();
            datesBonusPurchasing.ForEach(dbp =>
            {
                if (dbp.Date == dateTimeFlag.Date)
                {
                    countBonusPurchases++;
                    dateTimeFlag = dateTimeFlag.AddDays(-1);
                }
            });

            return countBonusPurchases;
        }
    }
}
