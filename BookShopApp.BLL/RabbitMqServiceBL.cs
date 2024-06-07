using BookShopApp.BLL;
using BookShopApp.BLL.Interfaces;
using BookShopApp.Shared;
using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace BookShopApp.BLL
{
    public class RabbitMqServiceBL : IRabbitMqServiceBL
    {
        private static int MSG_COUNT = 10000;

        private string connectionString;
        private ConnectionFactory factory;
        private readonly object _lock = new object();
        public RabbitMqServiceBL()
        {
            connectionString = "amqps://vxngjiis:EyAnmCZGndIu_Dl_DFmCwXdg_PGcU6pi@cow.rmq2.cloudamqp.com/vxngjiis";
            factory = new ConnectionFactory() { Uri = new Uri(connectionString) };
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

        public string Consume(string queue) //async Task<
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
                    message = Encoding.ASCII.GetString(body);
                    /*                        Console.WriteLine(message);*/
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

            }
            return message;
        }

    }
}

