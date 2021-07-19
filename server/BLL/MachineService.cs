using DAL.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class MachineService
    {
        private readonly MachineRepository _machineRepository;
        private readonly MachineContainerRepository _machineContainerRepository;
        private readonly UserRepository _userRepository;
        private readonly ReceiptRepository _receiptRepository;

        public MachineService(MachineRepository machineRepository,
            MachineContainerRepository machineContainerRepository,
            UserRepository userRepository, ReceiptRepository receiptRepository)
        {
            _machineRepository = machineRepository;
            _machineContainerRepository = machineContainerRepository;
            _userRepository = userRepository;
            _receiptRepository = receiptRepository;
        }

        public IEnumerable<MContainer> GetAllContainers(int id)
        {
            return _machineRepository.GetById(id).MachineContainers.Where(mc => mc.IsDeleted == false);
        }
        public IEnumerable<MContainer> GetAllSoldMachineContainers(int id)
        {
            return _machineRepository.GetById(id).MachineContainers.Where(mc => mc.IsDeleted == true);
        }
        public IEnumerable<MContainer> GetAllUserContainers(int userId)
        {
            var user = _userRepository.GetById(userId);
            var containers = _receiptRepository.GetAll(r => r.User == user)
                    .SelectMany(r => r.Containers);

            return containers;
        }
        public IEnumerable<object> GetAllSoldContainersForMap(string name)
        {
            return _machineContainerRepository.GetAll(c => c.IsDeleted && c.Eat.Name == name)
                .GroupBy(c => c.CountryName,
                    c => c.Eat.Price,
                    (country, price) => new
                    {
                        country,
                        price = price.Sum()
                    });
        }
        public MContainer GetContainerById(int id)
        {
            return _machineContainerRepository.GetById(id);
        }
        public void AddContainer(MContainer container)
        {
            _machineContainerRepository.Add(container);
        }
    }
}

