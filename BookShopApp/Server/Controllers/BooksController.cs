using BookShopApp.BLL.Interfaces;
using BookShopApp.Shared;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace BookShopApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private IBooksBL _booksBL;
        private readonly ILogger<BooksController> _logger;

        public BooksController(ILogger<BooksController> logger, IBooksBL booksBL)
        {
            _logger = logger;
            _booksBL = booksBL;
        }


        [HttpGet]
        [Route("api/Books/GetBooksByGenre/{genre}")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksByGenre(string Genre)
        {
            return await _booksBL.GetAllAsync(Genre);
        }

    }
}
