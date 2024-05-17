using BookShopApp.BLL.Interfaces;
using BookShopApp.Client.Pages;
using BookShopApp.Shared;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace BookShopApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private IBooksBL _booksBL;
        private readonly ILogger<BooksController> _logger;

        public BooksController(ILogger<BooksController> logger, IBooksBL booksBL)
        {
            _logger = logger;
            _booksBL = booksBL;
        }


        [HttpGet("{genreId:length(24)}")]
        /*[Route("genres/{genre}")]*/
        public async Task<ActionResult<IEnumerable<Book>>> Get(string genreId)
        {
            /*genre = "Фантастика";*/
           /* var books = */
            return await _booksBL.GetAllAsync(genreId);
        }

    }
}
