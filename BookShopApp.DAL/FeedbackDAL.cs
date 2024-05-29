using BookShopApp.DAL.Interfaces;
using BookShopApp.Shared;
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
        private static string _connectionString = "mongodb://localhost:27017";

        private readonly IMongoCollection<Feedback> _collection;
        public FeedbackDAL()
        {
            MongoClient mongoClient = new MongoClient(_connectionString);
            _collection = mongoClient.GetDatabase("books_db").GetCollection<Feedback>("feedbacks");
        }
        public async Task<Feedback> AddAsync(Feedback feedback) 
        {
            await _collection.InsertOneAsync(feedback);
            return await _collection.Find(x => x.Id == feedback.Id).FirstOrDefaultAsync();

        }
    }
}
