using RabbitMQ.Client;
using System;

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
            Console.WriteLine("Hello World!");
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
