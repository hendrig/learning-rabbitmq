using System;
using RabbitMQ.Client;
using System.Text;
using System.Threading;

namespace EmitLog
{
    class EmitLog
    {
        static void Main(string[] args)
        {
            var i = 0;

            for(i = 0; i < 100; i++){
                var dots = new string('.', i % 10);
                var message = "Message number " + i.ToString() + dots;

                SendMessage(new [] { message });
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }

        private static void SendMessage(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchange: "logs", type: ExchangeType.Fanout);

                    string message = GetMessage(args);
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "logs",
                                         routingKey: "",
                                         basicProperties: null,
                                         body: body);

                    Console.WriteLine(" [x] Sent {0}", message);
                }
            }
        }

        private static string GetMessage(string[] args)
        {
            return ((args.Length) > 0 ? string.Join(" ", args) : "info: Hello World");
        }
    }
}
