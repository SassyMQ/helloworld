using helloworld.Lib.DataClasses;
using helloworld.Lib.SqlDataManagement;
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

            world.ProgrammerGetAllGalaxiesReceived += World_ProgrammerGetAllGalaxiesReceived;
        }

        private static void World_ProgrammerGetAllGalaxiesReceived(object sender, PayloadEventArgs e)
        {
            var sdm = new SqlDataManager("data source=.;Initial Catalog=helloworld; Integrated Security=SSPI");
            e.Payload.Galaxies = sdm.GetAllGalaxies<Galaxy>();
            e.Payload.Stars = sdm.GetAllStars<Star>();
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
