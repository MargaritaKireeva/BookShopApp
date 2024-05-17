using BookShopApp.Shared;
using MongoDB.Bson;

namespace BookShopApp.DAL.Interfaces
{
    public interface IBooksDAL
    {
        public Task<List<Book>> GetAllAsync(string id);
        public Task<Book> GetByIdAsync(string bookId);
    }
}
