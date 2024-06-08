using BookShopApp.BLL;
using BookShopApp.BLL.Interfaces;
using BookShopApp.Shared;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace BookShopApp.Server.RabbitMQ
{
    public class RabbitMqService : IRabbitMqService
    {
        private IFeedbackBL _feedbackBL;
        private ConnectionFactory factory;
        public RabbitMqService(IFeedbackBL feedbackBL, IOptions<RabbitMqConnection> connection)
        {
            _feedbackBL = feedbackBL;
           /* connectionString = "amqps://vxngjiis:EyAnmCZGndIu_Dl_DFmCwXdg_PGcU6pi@cow.rmq2.cloudamqp.com/vxngjiis";*/
            factory = new ConnectionFactory() { Uri = new Uri(connection.Value.ConnectionString) };
        }
        public RabbitMqService(IFeedbackBL feedbackBL, RabbitMqConnection connection)
        {
            _feedbackBL = feedbackBL;
            /* connectionString = "amqps://vxngjiis:EyAnmCZGndIu_Dl_DFmCwXdg_PGcU6pi@cow.rmq2.cloudamqp.com/vxngjiis";*/
            factory = new ConnectionFactory() { Uri = new Uri(connection.ConnectionString) };
        }
        public RabbitMqService()
        {
        }
        public void SendMessage(object obj, string queue)
        {
            var message = JsonSerializer.Serialize(obj);
            SendMessage(message, queue);
        }

        public void SendMessage(string message, string queue)
        {

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queue,
                               durable: false,
                               exclusive: false,
                               autoDelete: false,
                               arguments: null);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                               routingKey: queue,
                               basicProperties: null,
                               body: body);

            };
        }

        public string ConsumeStr(string queue) //async Task<
        {
            string message = null;
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            /*            lock (_lock)
                        { if (string.IsNullOrEmpty(message))
                            {*/
            {
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += async (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(message);
                    if (queue.Equals("Feedback"))
                    {
                       await _feedbackBL.AddAsync(message);
                    }
                    channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                };
                channel.BasicConsume(queue: queue,
                     autoAck: false,
                     consumer: consumer);
                /*                    Console.WriteLine(" Press [enter] to exit.");
                                    Console.ReadLine();*/
                /*                     await Task.Run(() =>
                         while (string.IsNullOrEmpty(message))
                                     {
                                         Monitor.Wait(_lock);
                                     }

                                 });*/
                Console.WriteLine("Press Enter to exit");
                Console.ReadLine();
            }

            return message;
        }
        public void Consume(string queueName) //async Task<
        {
            string message = null;
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            /*            lock (_lock)
                        { if (string.IsNullOrEmpty(message))
                            {*/
            {
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += async (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(message);
                    if (queueName.Equals("Feedback"))
                    {
                        await _feedbackBL.AddAsync(message);
                    }
                    channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                };
                channel.BasicConsume(queue: queueName,
                     autoAck: false,
                     consumer: consumer);
                /*                    Console.WriteLine(" Press [enter] to exit.");
                                    Console.ReadLine();*/
                /*                     await Task.Run(() =>
                         while (string.IsNullOrEmpty(message))
                                     {
                                         Monitor.Wait(_lock);
                                     }

                                 });*/
                Console.WriteLine("Press Enter to exit");
                Console.ReadLine();
            }


        }
    }
}
