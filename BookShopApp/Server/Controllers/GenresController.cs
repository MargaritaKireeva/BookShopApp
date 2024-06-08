using BookShopApp.BLL;
using BookShopApp.BLL.Interfaces;
using BookShopApp.Server.RabbitMQ;
using BookShopApp.Shared;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Newtonsoft.Json.Linq;

namespace BookShopApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenresController : ControllerBase
    {
        private IGenresBL _genresBL;
        private IBooksBL _booksBL;
        private readonly ILogger<GenresController> _logger;
        private readonly IRabbitMqService _mqService;

        public GenresController(ILogger<GenresController> logger, IGenresBL genresBL, IBooksBL booksBL, IRabbitMqService mqService)
        {
            _logger = logger;
            _genresBL = genresBL;
            _booksBL = booksBL;
            _mqService = mqService;
        }

        [HttpGet]
        [Route("/[controller]")]
        public async Task<ActionResult<List<Genre>>> Get()
        {
            /*            List<Genre> genres = await _genresBL.GetAllAsync();*//*
            await _genresBL.GetAllAsync();
            string genres = _mqService.ConsumeStr("GetGenres");
            return genres.ToJson();*/
            return await _genresBL.GetAllAsync();
        }

        [HttpGet("{genreId:length(24)}")]
        [Route("/Genres/{genreId}")]
        public async Task<ActionResult<IEnumerable<Book>>> Get(string genreId)
        {
            var books = await _booksBL.GetAllAsync(genreId);
            return books;
        }

        [HttpGet("{genreId:length(24)}/{bookId:length(24)}")]
        [Route("/Genres/{genreId}/{bookId}")]
        public async Task<ActionResult<Book>> GetBookById(string bookId)
        {
            var book = await _booksBL.GetByIdAsync(bookId);
            return book;
        }

    }
}
