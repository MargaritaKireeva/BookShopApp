using BookShopApp.BLL;
using BookShopApp.BLL.Interfaces;
using MongoDB.Bson;
using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using BookShopApp.Shared;
using BookShopApp.DAL.Interfaces;
using BookShopApp.DAL;
using System.Threading.Channels;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization;
using BookShopApp.Server.RabbitMQ;
using System.Configuration;
using MongoDB.Driver.Core.Configuration;

namespace Consumer
{
    public class Program
    {
        static void Main(string[] args)
        {
            ListenForIntegrationEvents();

        }
        static void ListenForIntegrationEvents()
        {
            DbSettings dbSettings = new DbSettings
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["MongoConnection"].ConnectionString,
                DbName = ConfigurationManager.AppSettings.Get("MongoDbName"),
                FeedbackCollectionName = ConfigurationManager.AppSettings.Get("FeedbackCollectionName"),
            };
            RabbitMqConnection rabbitMqConnection = new RabbitMqConnection
            {
                ConnectionString = ConfigurationManager.AppSettings.Get("RabbitMqString")
            };
            IFeedbackDAL feedbackDAL = new FeedbackDAL(dbSettings);
            IFeedbackBL _feedbackBL = new FeedbackBL(feedbackDAL);
            
            var _mqService = new RabbitMqService(_feedbackBL, rabbitMqConnection);
            _mqService.Consume("Feedback");
/*            string message = null;
            var factory = new ConnectionFactory() { Uri = new Uri(connectionString) };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            *//*            lock (_lock)
                        { if (string.IsNullOrEmpty(message))
                            {*//*
            {
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += async (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(message);
                        await _feedbackBL.AddAsync(message);
               *//*     channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);*//*
                };
                channel.BasicConsume(queue: "Feedback",
                     autoAck: true,
                     consumer: consumer);
                *//*                    Console.WriteLine(" Press [enter] to exit.");
                                    Console.ReadLine();*/
                /*                     await Task.Run(() =>
                         while (string.IsNullOrEmpty(message))
                                     {
                                         Monitor.Wait(_lock);
                                     }

                                 });*//*
                Console.WriteLine("Press Enter to exit");
                Console.ReadLine();*/
     /*       }*/

        }
    }

}
