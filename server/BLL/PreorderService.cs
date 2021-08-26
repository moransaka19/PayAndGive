using DAL;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class PreorderService
    {
        private readonly PreorderRepository _preorderRepository;

        public PreorderService(PreorderRepository preorderRepository)
        {
            _preorderRepository = preorderRepository;
        }

        public IEnumerable<Preorder> GetAllPreorders()
        {
            return _preorderRepository.GetAll();
        }
        public IEnumerable<Preorder> GetAllUserPreorders(int id)
        {
            return _preorderRepository.GetAll(p => p.UserId == id);
        }
        public void AddPreorder(User user, IEnumerable<int> eatIds)
        {
            var dateTimeNow = DateTime.Now;
            eatIds.ToList().ForEach(e => _preorderRepository.Add(
                new Preorder
                {
                    DateTimePreorder = dateTimeNow,
                    EatId = e,
                    User = user
                })
            );
        }
    }
}
