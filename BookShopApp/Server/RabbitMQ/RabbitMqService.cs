using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace BookShopApp.Server.RabbitMQ
{
    public class RabbitMqService : IRabbitMqService
    {
        public void SendMessage(object obj)
        {
            var message = JsonSerializer.Serialize(obj);
            SendMessage(message);
        }

        public void SendMessage(string message)
        {
            var factory = new ConnectionFactory() { Uri = new Uri("amqps://vxngjiis:EyAnmCZGndIu_Dl_DFmCwXdg_PGcU6pi@cow.rmq2.cloudamqp.com/vxngjiis") };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "MyQueue",
                               durable: false,
                               exclusive: false,
                               autoDelete: false,
                               arguments: null);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                               routingKey: "MyQueue",
                               basicProperties: null,
                               body: body);
            }
        }
    }
}
