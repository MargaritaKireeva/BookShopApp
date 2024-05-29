using BookShopApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.DAL.Interfaces
{
    public interface IFeedbackDAL
    {
        public Task<Feedback> AddAsync(Feedback feedback);
    }
}
