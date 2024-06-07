using BookShopApp.BLL.Interfaces;
using BookShopApp.Server.RabbitMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Shared
{
    public class SingleRabbitMQ
    {

        private static SingleRabbitMQ _instance;
        public static IFeedbackBL _feedbackBL { get; set; }
        public SingleRabbitMQ(IFeedbackBL feedbackBL)
        {
            _feedbackBL = feedbackBL;
        }
        public static SingleRabbitMQ Instance => _instance = _instance ?? new SingleRabbitMQ(_feedbackBL);
        public RabbitMqService Rabbit => new RabbitMqService(_feedbackBL);
    }
}
