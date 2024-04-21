using BookShopApp.DAL.Interfaces;
using BookShopApp.Shared;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopApp.DAL
{
    public class BooksDAL : IBooksDAL
    {
        private static string _connectionString = "mongodb://localhost:27017";


        private readonly IMongoCollection<Book> _collection;
        public BooksDAL()
        {
            MongoClient mongoClient = new MongoClient(_connectionString);
            _collection = mongoClient.GetDatabase("books_db").GetCollection<Book>("books");
        }

        public async Task<List<Book>> GetAllAsync(string Genre)
        {
            var filter = Builders<Book>.Filter.Eq(b => b.Genre, Genre);
            return await _collection.Find(filter).ToListAsync();
        }

/*        public async Task InsertOneAsync(Book book)
        {
            await _collection.InsertOneAsync(book);
        }*/
    }
/*        public async Task<List<Entities.Book>> GetAllBooksAsync(int CategoryID)
        {
            using (var context = new DefaultDbContext())
            {
                return context.Books.ToList().Select(book => new Entities.Book()
                {
                    ID = book.Id,
                    Name = book.Name,
                    Author = book.Author,
                    Amount = book.Amount,
                    ReleaseYear = book.ReleaseYear,
                    PagesNumber = book.PagesNumber,
                    AgeRestriction = book.AgeRestriction,
                    Description = book.Description,
                    Picture = book.Picture,
                    Price = book.Price,
                    CategoryID = book.CategoryId
                }).Where(item => item.CategoryID == CategoryID).ToList();
            }
        }
        public async Task<Entities.Book> GetByIDAsync(int BookID)
        {
            using (var context = new DefaultDbContext())
            {
                var book = context.Books.ToList().Where(book => book.Id == BookID).FirstOrDefault();
                return new Entities.Book()
                {
                    ID = book.Id,
                    Name = book.Name,
                    Author = book.Author,
                    Amount = book.Amount,
                    ReleaseYear = book.ReleaseYear,
                    PagesNumber = book.PagesNumber,
                    AgeRestriction = book.AgeRestriction,
                    Description = book.Description,
                    Picture = book.Picture,
                    Price = book.Price,
                    CategoryID = book.CategoryId
                };
            }
        }*/
}
