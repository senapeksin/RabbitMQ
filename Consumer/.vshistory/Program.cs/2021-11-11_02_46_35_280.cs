using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Consumer
{
    public class Program
    {
        private static string connectionString = "amqp://guest:guest@localhost:5672";
        private static string queueName;
        private static IModel _channel;
        private static IModel channel => _channel ?? (_channel = CreateOrGetChannel());
        private static IConnection connection;
        static void Main(string[] args)
        {
            queueName = args.Length > 0 ? args[0] : "";
            connection = GetConnection();
            var consumer_event = new EventingBasicConsumer(channel);
            consumer_event.Received += (ch, e) =>
            {
                var byteArr = e.Body.ToArray();
                var bodyStr = Encoding.UTF8.GetString(byteArr);
                Console.WriteLine($"Received Data:{bodyStr}");
            };
            channel.BasicConsume(queueName, true, consumer_event);
            Console.WriteLine($"{queueName} listening ..... \n\n\n");

        }

        private static IConnection GetConnection()
        {
            ConnectionFactory factory = new ConnectionFactory()
            {
                Uri = new Uri(connectionString, UriKind.RelativeOrAbsolute)
            };
            return factory.CreateConnection();
        }

        private static IModel CreateOrGetChannel()
        {
            //Imodel tipinde bir interface dönüyor bu da bizim channel 'ımız oluyor.
            return connection.CreateModel();
        }

    }
}
