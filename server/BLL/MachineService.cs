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
		private readonly ContainerRepository _machineContainerRepository;
		private readonly UserRepository _userRepository;
		private readonly ReceiptRepository _receiptRepository;

		public MachineService(MachineRepository machineRepository,
			ContainerRepository machineContainerRepository,
			UserRepository userRepository, ReceiptRepository receiptRepository)
		{
			_machineRepository = machineRepository;
			_machineContainerRepository = machineContainerRepository;
			_userRepository = userRepository;
			_receiptRepository = receiptRepository;
		}
		public IEnumerable<Machine> GetAllMachines()
		{
			return _machineRepository.GetAll();
		}
		public IEnumerable<Container> GetAllContainers(int id)
		{
			return _machineContainerRepository.GetAll();
		}
		public IEnumerable<Container> GetAllSoldMachineContainers(int id)
		{
			return _machineContainerRepository.GetAll().Where(c => c.MachineId == id && c.IsBought == true);
		}

        public IEnumerable<Machine> GetAllRestaurantMachines(int id)
        {
			return _machineRepository.GetAll(m => m.RestaurantId == id);
        }

        public IEnumerable<Container> GetAllUserContainers(int userId)
		{
			var user = _userRepository.GetById(userId);
			var containers = _receiptRepository.GetAll()
				.Where(r => r.User == user)
				.Select(r => r.Container);

			return containers;
		}
		
		public Container GetContainerById(int id)
		{
			return _machineContainerRepository.GetById(id);
		}
		public Machine GetMachineById(int id)
		{
			return _machineRepository.GetById(id);
		}
		public void AddContainer(Container container)
		{
			_machineContainerRepository.Add(container);
		}
		public void AddMachine(Machine model)
        {
			_machineRepository.Add(model);
        }
	}
}

