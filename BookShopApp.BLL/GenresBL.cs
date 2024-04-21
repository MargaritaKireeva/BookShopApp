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
        public GenresBL(IGenresDAL genresDAL)
        {
            _genresDAL = genresDAL;
        }
        public async Task<List<Genre>> GetAllAsync()
        {
            return await _genresDAL.GetAllAsync();
        }
/*        public async Task<Genre> GetByIDAsync(int BookID)
        {
            return await _genresDAL.GetByIDAsync(BookID);
        }*/
    }
}
