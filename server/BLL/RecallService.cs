using DAL;
using Domain;
using System.Collections.Generic;

namespace BLL
{
    public class RecallService
    {
        private readonly RecallRepository _recallRepository;
        public RecallService(RecallRepository recallRepository)
        {
            _recallRepository = recallRepository;
        }

        public IEnumerable<Recall> GetAllRecalls()
        {
            return _recallRepository.GetAll();
        }
        public IEnumerable<Recall> GetAllRestaurantRecalls(int restaurantId)
        {
            return _recallRepository.GetAll(r => r.RestaurantId == restaurantId);
        }
        public void AddRecall(Recall model)
        {
            _recallRepository.Add(model);
        }
    }
}
