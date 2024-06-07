using BookShopApp.BLL.Interfaces;
using BookShopApp.DAL.Interfaces;
using BookShopApp.Shared;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookShopApp.BLL
{
    public class FeedbackBL : IFeedbackBL
    {
        public static IFeedbackDAL _feedbackDAL;
        public static IRabbitMqServiceBL _rabbitMqService;
        public FeedbackBL(IFeedbackDAL feedbackDAL, IRabbitMqServiceBL rabbitMqService)
        {
            _feedbackDAL = feedbackDAL;
            _rabbitMqService = rabbitMqService;
        }
        public FeedbackBL(IFeedbackDAL feedbackDAL)
        {
            _feedbackDAL = feedbackDAL;
        }

        public async Task<Feedback> AddAsync(Feedback feedback)
        {
            string feedbackStr = _rabbitMqService.Consume("Feedback");
            var data = JObject.Parse(feedbackStr);
            return await _feedbackDAL.AddAsync(new Feedback
            {
                //*                       Id = ObjectId.GenerateNewId().ToString(),
                Name = data["Name"].Value<string>(),
                Date = data["Date"].Value<DateTime>(),
                Message = data["Message"].Value<string>(),
                Email = data["Email"].Value<string>()
            });
        }
        public async Task<Feedback> AddAsync(string feedbackStr)
        {
            var data = JObject.Parse(feedbackStr);
            return await _feedbackDAL.AddAsync(new Feedback
            {
                //*                       Id = ObjectId.GenerateNewId().ToString(),*//*
                Name = data["Name"].Value<string>(),
                Date = data["Date"].Value<DateTime>(),
                Message = data["Message"].Value<string>(),
                Email = data["Email"].Value<string>()
            });
        }
    }
}
