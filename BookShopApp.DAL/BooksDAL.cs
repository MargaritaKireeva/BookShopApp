using BookShopApp.DAL.Interfaces;
using BookShopApp.Shared;
using Microsoft.Extensions.Options;
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
        private readonly IMongoCollection<Book> _collection;
        public BooksDAL(IOptions<DbSettings> dbSettings)
        {
            MongoClient mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            _collection = mongoClient.GetDatabase(dbSettings.Value.DbName).GetCollection<Book>(dbSettings.Value.BooksCollectionName);
        }

        public async Task<List<Book>> GetAllAsync(string id)
        {
            /*            var filter = Builders<Book>.Filter.Eq(b => b.Genre, Genre);
                        List<Book> books = await _collection.Find(filter).ToListAsync();
                        return books;*/
            var books = await _collection.Find(new BsonDocument("GenreId", ObjectId.Parse(id))).ToListAsync();

            return books;
        }

        public async Task<Book?> GetByIdAsync(string bookId) =>
            await _collection.Find(x => x.Id == bookId).FirstOrDefaultAsync();
    }
}
