
namespace BookShopApp.BLL
{
    public interface IRabbitMqServiceBL
    {

        void SendMessage(object obj, string queue);
        void SendMessage(string message, string queue);
        string Consume(string queue);
    }
}
