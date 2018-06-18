using SMQ.SassyMQ.Lib.RabbitMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            var world = new SMQWorld("amqp://guest:guest@localhost/SMQ");

            world.ProgrammerHelloReceived += World_ProgrammerHelloReceived;

            world.ProgrammerGoodbyeReceived += World_ProgrammerGoodbyeReceived;
        }

        private static void World_ProgrammerGoodbyeReceived(object sender, PayloadEventArgs e)
        {
            Console.WriteLine("Got goodbye from programmer");
        }

        private static void World_ProgrammerHelloReceived(object sender, PayloadEventArgs e)
        {
            Console.WriteLine("got hello from the programmer");
        }
    }
}
