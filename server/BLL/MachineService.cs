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
		public IEnumerable<Machine> GetAllMachines()
		{
			return _machineRepository.GetAll();
		}
		public IEnumerable<Machine> GetNotDeletedMachines()
        {
			return _machineRepository.GetAll(m => m.MachineContainers.Any(x => !x.IsDeleted))
				.ToList()
				.Select(x =>
				{
					x.MachineContainers = x.MachineContainers.Where(z => !z.IsDeleted);

					return x;
				});
		}
		public IEnumerable<MContainer> GetNotProcessedMachines(int id)
        {
			var containers = _machineContainerRepository.GetAll(x => x.MachineId == id && x.ReadyForOpen).ToList();

			containers.ForEach(x =>
			{
				x.ReadyForOpen = false;
				_machineContainerRepository.Update(x);
			});

			return containers;
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
			var containers = _receiptRepository.GetAll()
				.Where(r => r.User == user)
				.Select(r => r.Container);

			return containers;
		}
		public IEnumerable<object> GetAllSoldContainersForGoogleMap(int id)
		{
			return _machineContainerRepository.GetAll(c => c.IsDeleted && c.Eat.Id == id)
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
		public Machine GetMachineById(int id)
		{
			return _machineRepository.GetById(id);
		}
		public void AddContainer(MContainer container)
		{
			_machineContainerRepository.Add(container);
		}
		public void AddMachine(Machine model)
        {
			_machineRepository.Add(model);
        }
	}
}

