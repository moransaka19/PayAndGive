using AutoMapper;
using BLL;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Server.Models.Recalls;

namespace Server.Controllers
{
    [Route("api/recalls")]
    [ApiController]
    public class RecallsController : ControllerBase
    {
        private readonly RecallService _recallService;
        private readonly IMapper _mapper;
        public RecallsController(RecallService recallService,
            IMapper mapper)
        {
            _recallService = recallService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllRecalls()
        {
            var recalls = _recallService.GetAllRecalls();

            return Ok(recalls);
        }
        [HttpGet("restaurant/{id}")]
        public IActionResult GetAllRestaurantRecalls(int id)
        {
            var recalls = _recallService.GetAllRestaurantRecalls(id);

            return Ok(recalls);
        }
        [HttpPost]
        public IActionResult AddRecall([FromBody] AddRecallModel model)
        {
            var recall = _mapper.Map<Recall>(model);
            _recallService.AddRecall(recall);

            return Ok();

        }
    }
}
