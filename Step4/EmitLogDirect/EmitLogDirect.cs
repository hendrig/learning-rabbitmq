using System;
using RabbitMQ.Client;
using System.Text;
using System.Linq;
using System.Threading;

namespace EmitLogDirect
{
    class EmitLogDirect
    {
        static void Main(string[] args)
        {
            foreach(var severity in args)
            {
                for(var i = 0; i < 10; i++){
                    var dots = new string('.', i % 10);
                    var message = "Message number " + i.ToString() + dots;

                    SendMessage(new [] { severity, message });
                }
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
                    channel.ExchangeDeclare(exchange: "direct_logs",
                                            type: "direct");

                    var severity = (args.Length > 0) ? args[0] : "info";
                    
                    var message = GetMessage(args);

                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "direct_logs",
                                         routingKey: severity,
                                         basicProperties: null,
                                         body: body);

                    Console.WriteLine(" [x] Sent '{0}':'{1}'", severity, message);
                }
            }
        }

        private static string GetMessage(string[] args)
        {
            return ((args.Length) > 1 ? string.Join(" ", args.Skip(1).ToArray()) : "info: Hello World");
        }
    }
}
