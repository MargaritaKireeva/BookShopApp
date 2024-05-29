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
        /*
                [HttpGet]
                public IEnumerable<string> Get()
                {
                    return new string[] { "value1", "value2" };
                }
        */

        // POST api/<FeedbackController>
        [HttpPost]
        public async Task<ActionResult<Feedback>> Post([FromBody] Feedback feedback)
        {
           var feedbackFromDb = await _feedbackBL.AddAsync(feedback);
            if (feedbackFromDb != null) 
            {
                string message = $"{feedbackFromDb.Name} отправил сообщение:" +
                    $"\n{feedbackFromDb.Message}" +
                    $"\n Дата: {feedbackFromDb.Date}" +
                    $"\n Почта: {feedbackFromDb.Email}";
                _mqService.SendMessage(message);
            }
            return feedbackFromDb;
        }


    }
}
