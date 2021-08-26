using DAL.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class ContainerService
    {
        private readonly ContainerRepository _containerRepository;
        public ContainerService(ContainerRepository containerRepository)
        {
            _containerRepository = containerRepository;
        }

        public IEnumerable<Container> GetAllMachineContainers(int machineId)
        {
            return _containerRepository.GetAll(c => c.MachineId == machineId);
        }
        public IEnumerable<Container> GetAllNotSoldContainers(int machineId)
        {
            return _containerRepository.GetAll(c => !c.IsBought && c.MachineId == machineId);
        }
        public IEnumerable<Container> GetAllSoldMachineContainers(int machineId)
        {
            return _containerRepository.GetAll(c => c.IsBought && c.MachineId == machineId);
        }
        public Container GetByIdContainer(int id)
        {
            return _containerRepository.GetById(id);
        }
        public void AddContainer(Container model)
        {
            _containerRepository.Add(model);
        }

        public IEnumerable<Container> GetAllSoldContainersForMap()
        {
            //var restaurant = _restaurant.GetAll();
            return _containerRepository.GetAll(c => c.IsBought);
        }
    }
}
