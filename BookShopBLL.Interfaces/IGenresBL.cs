
using BookShopApp.DAL.Interfaces;
using BookShopApp.Shared;
namespace BookShopApp.BLL.Interfaces
{
    public interface IGenresBL
    {
        public Task<List<Genre>> GetAllAsync();
    }
}
