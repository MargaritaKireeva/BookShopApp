using BookShopApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.BLL.Interfaces
{
    public interface IFeedbackBL
    {
        public Task<Feedback> AddAsync(Feedback feedback);
    }
}
