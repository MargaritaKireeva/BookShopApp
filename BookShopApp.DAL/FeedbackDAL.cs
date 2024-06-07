using BookShopApp.DAL.Interfaces;
using BookShopApp.Shared;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.DAL
{
    public class FeedbackDAL : IFeedbackDAL
    {
        private readonly IMongoCollection<Feedback> _collection;

        public FeedbackDAL(IOptions<DbSettings> dbSettings)
        {
            MongoClient mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            _collection = mongoClient.GetDatabase(dbSettings.Value.DbName).GetCollection<Feedback>(dbSettings.Value.FeedbackCollectionName);
        }

        public FeedbackDAL(DbSettings dbSettings)
        {
            MongoClient mongoClient = new MongoClient(dbSettings.ConnectionString);
            _collection = mongoClient.GetDatabase(dbSettings.DbName).GetCollection<Feedback>(dbSettings.FeedbackCollectionName);
        }

        public async Task<Feedback> AddAsync(Feedback feedback) 
        {
            await _collection.InsertOneAsync(feedback);
            return await _collection.Find(x => x.Id == feedback.Id).FirstOrDefaultAsync();

        }
    }
}
