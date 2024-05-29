using BookShopApp.BLL.Interfaces;
using BookShopApp.DAL.Interfaces;
using BookShopApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.BLL
{
    public class FeedbackBL : IFeedbackBL
    {
        public static IFeedbackDAL _feedbackDAL;
        public FeedbackBL(IFeedbackDAL feedbackDAL)
        {
            _feedbackDAL = feedbackDAL;
        }

        public async Task<Feedback> AddAsync(Feedback feedback)
        {
            return await _feedbackDAL.AddAsync(feedback);
        }
    }
}
