using DAL.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class EatService
    {
        private readonly EatRepository _eatRepository;

        public EatService(EatRepository eatRepository)
        {
            _eatRepository = eatRepository;
        }

        public IEnumerable<Eat> GetAllEats()
        {
            return _eatRepository.GetAll();
        }
        public void CreateEat(Eat model)
        {
            _eatRepository.Add(model);
        }
    }
}
