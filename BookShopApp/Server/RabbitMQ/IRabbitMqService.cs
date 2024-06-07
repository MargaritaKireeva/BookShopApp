
namespace BookShopApp.Server.RabbitMQ
{
    public interface IRabbitMqService
    {

        void SendMessage(object obj, string queue);
        void SendMessage(string message, string queue);
        string ConsumeStr(string queue);
        void Consume(string queue);
    }
}
