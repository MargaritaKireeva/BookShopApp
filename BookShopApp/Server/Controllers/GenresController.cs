using BookShopApp.BLL.Interfaces;
using BookShopApp.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BookShopApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenresController : ControllerBase
    {
        private IGenresBL _genresBL;
        private IBooksBL _booksBL;
        private readonly ILogger<GenresController> _logger;

        public GenresController(ILogger<GenresController> logger, IGenresBL genresBL, IBooksBL booksBL)
        {
            _logger = logger;
            _genresBL = genresBL;
            _booksBL = booksBL;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> Get()
        {
/*            List<Genre> genres = await _genresBL.GetAllAsync();*/
            return await _genresBL.GetAllAsync();
        }

        [HttpGet("{genreId:length(24)}")]
        /*[Route("genres/{genre}")]*/
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks(string genreId)
        {
            /*genre = "Фантастика";*/
            /* var books = */
            var books = await _booksBL.GetAllAsync(genreId);
            return books;
        }

        [HttpGet("{genreId:length(24)}/GetBooks/{bookId:length(24)}")]
        /*[Route("genres/{genre}")]*/
        public async Task<ActionResult<Book>> GetBookById(string bookId)
        {
            /*genre = "Фантастика";*/
            /* var books = */
            var book = await _booksBL.GetByIdAsync(bookId);
            return book;
        }

    }
}
