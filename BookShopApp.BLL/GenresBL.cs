using BookShopApp.BLL.Interfaces;
using BookShopApp.DAL;
using BookShopApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookShopApp.Shared;
namespace BookShopApp.BLL
{
    public class GenresBL : IGenresBL
    {
        public static IGenresDAL _genresDAL;
        public static IRabbitMqServiceBL _rabbitMqService;
        public GenresBL(IGenresDAL genresDAL, IRabbitMqServiceBL rabbitMqService)
        {
            _genresDAL = genresDAL;
            _rabbitMqService = rabbitMqService;
        }
        public async Task<List<Genre>> GetAllAsync()
        {
            var genres = await _genresDAL.GetAllAsync();
            /*_rabbitMqService.SendMessage(genres, "GetGenres");*/
            return genres;
        }
/*        public async Task<Genre> GetByIDAsync(int BookID)
        {
            return await _genresDAL.GetByIDAsync(BookID);
        }*/
    }
}
