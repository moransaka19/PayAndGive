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

        public MachineService(MachineRepository machineRepository,
            MachineContainerRepository machineContainerRepository)
        {
            _machineRepository = machineRepository;
            _machineContainerRepository = machineContainerRepository;
        }

        public IEnumerable<MContainer> GetAllContainers(int id)
        {
            return _machineRepository.GetById(id).MachineContainers.Where(mc => mc.IsDeleted == false);
        }

        public IEnumerable<MContainer> GetAllSoldMachineContainers(int id)
        {
            return _machineRepository.GetById(id).MachineContainers.Where(mc => mc.IsDeleted == true);
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
    }
}

