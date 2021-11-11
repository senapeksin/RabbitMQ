using RabbitMQ.Client;
using System;

namespace Consumer
{
    class Program
    {
        private IModel _channel;
        private IModel channel => _channel ?? (_channel = CreateOrGetChannel());
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        private IConnection GetConnection()
        {
            ConnectionFactory factory = new ConnectionFactory()
            {
                Uri = new Uri(txtConnectionString.Text, UriKind.RelativeOrAbsolute)
            };
            return factory.CreateConnection();
        }

        private IModel CreateOrGetChannel()
        {
            //Imodel tipinde bir interface dönüyor bu da bizim channel 'ımız oluyor.
            return connection.CreateModel();
        }

    }
}
