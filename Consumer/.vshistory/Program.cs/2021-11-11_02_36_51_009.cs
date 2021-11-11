using RabbitMQ.Client;
using System;

namespace Consumer
{
    public class Program
    {
        private static IModel _channel;
        private static IModel channel => _channel ?? (_channel = CreateOrGetChannel());
        private static IConnection connection;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        private static IConnection GetConnection()
        {
            ConnectionFactory factory = new ConnectionFactory()
            {
                Uri = new Uri(txtConnectionString.Text, UriKind.RelativeOrAbsolute)
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
