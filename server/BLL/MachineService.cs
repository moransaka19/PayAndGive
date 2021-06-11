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

        public MachineService(MachineRepository machineRepository)
        {
            _machineRepository = machineRepository;
        }

        public IEnumerable<MContainer> GetAllContainers(int id)
        {
            return _machineRepository.GetById(id).MachineContainers.Where(mc => mc.IsDeleted == false);
        }
    }
}
