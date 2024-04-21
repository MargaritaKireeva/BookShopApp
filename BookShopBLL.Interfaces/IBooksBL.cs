using BookShopApp.Shared;
using BookShopApp.DAL.Interfaces;
using MongoDB.Bson;
namespace BookShopApp.BLL.Interfaces
{
    public interface IBooksBL
    {
        public Task<List<Book>> GetAllAsync(string Genre);
       /* public Task<Book> GetByIDAsync(int BookID);*/
    }
}
