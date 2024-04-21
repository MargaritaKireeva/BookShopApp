using BookShopApp.DAL.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using BookShopApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.DAL
{
    public class GenresDAL : IGenresDAL
    {
        private static string _connectionString = "mongodb://localhost:27017";

        private readonly IMongoCollection<Genre> _collection;
        public GenresDAL()
        {
            MongoClient mongoClient = new MongoClient(_connectionString);
            _collection = mongoClient.GetDatabase("books_db").GetCollection<Genre>("genres");
        }
        public GenresDAL(IMongoClient mongoClient)
        {
            _collection = mongoClient.GetDatabase("books_db").GetCollection<Genre>("genres");
        }

        public async Task<List<Genre>> GetAllAsync()
        {
            return await _collection.Find(new BsonDocument()).ToListAsync();
        }

/*        public async Task InsertOneAsync(Genre genre)
        {
            await _collection.InsertOneAsync(genre);
        }*/
    }
}
