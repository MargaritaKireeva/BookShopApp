using BookShopApp.Shared;
using BookShopApp.DAL.Interfaces;
using MongoDB.Bson;
namespace BookShopApp.BLL.Interfaces
{
    public interface IBooksBL
    {
        public Task<List<Book>> GetAllAsync(string id);
        public Task<Book> GetByIdAsync(string bookId);
    }
}
