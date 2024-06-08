using BookShopApp.BLL.Interfaces;
using BookShopApp.Server.RabbitMQ;
using BookShopApp.Shared;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookShopApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeedbackController : ControllerBase
    {
        private IFeedbackBL _feedbackBL;
        private readonly ILogger<GenresController> _logger;
        private readonly IRabbitMqService _mqService;

        public FeedbackController(ILogger<GenresController> logger, IFeedbackBL feedbackBL, IRabbitMqService mqService)
        {
            _logger = logger;
            _feedbackBL = feedbackBL;
            _mqService = mqService;

        }

        // POST api/<FeedbackController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Feedback feedback)
        {
            string message;
            _mqService.SendMessage(feedback, "Feedback");
            return Ok();
/*            string message = null;
            while (message == null)
            {
                message = _mqService.Message;
                await Task.Delay(25);

            }*/
        }


    }
}
