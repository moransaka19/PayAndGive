using BLL;
using Microsoft.AspNetCore.Mvc;
using Server.Models.Receipt;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptsController : ControllerBase
    {
        private readonly ReceiptService _receiptService;
        private readonly UserService _userService;


        public ReceiptsController(
            ReceiptService receiptService, 
            UserService userService)
        {
            _receiptService = receiptService;
            _userService = userService;
        }

        [HttpPost]
        public IActionResult AddReceipt([FromBody] AddReceiptModel model)
        {
            _receiptService.AddReceipt(HttpContext, model.ContainersId);

            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetReceipt(int id)
        {
            var receipt = _receiptService.GetReceiptById(id);

            return Ok(receipt);
        }
        [HttpGet("user")]
        public IActionResult GetAllUserReceipts()
        {
            var user = _userService.GetCurrentUser(HttpContext);
            var userReceipts = _receiptService.GetAllUserReceipts(user);

            return Ok(userReceipts);
        }
    }
}
