using BookShopApp.BLL.Interfaces;
using BookShopApp.DAL;
using BookShopApp.DAL.Interfaces;
using BookShopApp.Shared;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace BookShopApp.BLL
{
    public class BooksBL : IBooksBL
    {
        public static IBooksDAL _booksDAL;
        public BooksBL(IBooksDAL booksDAL)
        {
            _booksDAL = booksDAL;
        }
        public async Task<List<Book>> GetAllAsync(string id)
        {
            return await _booksDAL.GetAllAsync(id);
        }
        public async Task<Book?> GetByIdAsync(string BookId)
        {
            return await _booksDAL.GetByIdAsync(BookId);
        }
    }
}
