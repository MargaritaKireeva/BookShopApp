using BookShopApp.DAL.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using BookShopApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace BookShopApp.DAL
{
    public class GenresDAL : IGenresDAL
    {

        private readonly IMongoCollection<Genre> _collection;
        public GenresDAL(IOptions<DbSettings> dbSettings)
        {
            MongoClient mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            _collection = mongoClient.GetDatabase(dbSettings.Value.DbName).GetCollection<Genre>(dbSettings.Value.GenresCollectionName);
        }
        public GenresDAL(IMongoClient mongoClient, IOptions<DbSettings> dbSettings)
        {
            _collection = mongoClient.GetDatabase(dbSettings.Value.DbName).GetCollection<Genre>(dbSettings.Value.GenresCollectionName);
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
