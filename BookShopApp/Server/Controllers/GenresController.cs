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
        private readonly ILogger<GenresController> _logger;

        public GenresController(ILogger<GenresController> logger, IGenresBL genresBL)
        {
            _logger = logger;
            _genresBL = genresBL;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> Get()
        {
/*            List<Genre> genres = await _genresBL.GetAllAsync();*/
            return await _genresBL.GetAllAsync();
        }

    }
}
