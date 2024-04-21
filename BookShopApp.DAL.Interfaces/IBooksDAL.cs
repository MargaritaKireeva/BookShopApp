using BookShopApp.Shared;
using MongoDB.Bson;

namespace BookShopApp.DAL.Interfaces
{
    public interface IBooksDAL
    {
        public Task<List<Book>> GetAllAsync(string Genre);
       /* public Task<Book> GetByIDAsync(int BookID);*/
    }
}
