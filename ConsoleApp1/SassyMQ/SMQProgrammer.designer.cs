using System;
using System.Linq;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using System.Threading.Tasks;

namespace SMQ.SassyMQ.Lib.RabbitMQ
{
    public partial class SMQProgrammer : SMQActorBase
    {

        public SMQProgrammer(String amqpConnectionString)
            : base(amqpConnectionString, "programmer")
        {
        }

        protected override void CheckRouting(StandardPayload payload, BasicDeliverEventArgs  bdea)
        {
            try
            {
                switch (bdea.RoutingKey)
                {
                    
                    case "programmer.general.world.whatsup":
                        this.OnWorldWhatsUpReceived(payload, bdea);
                        break;
                    
                }

            }
            catch (Exception ex)
            {
                payload.ErrorMessage = ex.Message;
            }
            this.Reply(payload, bdea.BasicProperties.ReplyTo);
        }

        
        /// <summary>
        /// Responds to: WhatsUp from World
        /// </summary>
        public event EventHandler<PayloadEventArgs> WorldWhatsUpReceived;
        protected virtual void OnWorldWhatsUpReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.WorldWhatsUpReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.WorldWhatsUpReceived(this, plea);
            }
        }

        /// <summary>
        /// Hello - The Programmer, says "Hello" to the World
        /// </summary>
        public Task Hello(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.Hello(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }    

        /// <summary>
        /// Hello - The Programmer, says "Hello" to the World
        /// </summary>
        public Task Hello(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.Hello(payload, replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// Hello - The Programmer, says "Hello" to the World
        /// </summary>
        public Task Hello(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("world.general.programmer.hello", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        /// <summary>
        /// Goodbye - Say cya
        /// </summary>
        public Task Goodbye(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.Goodbye(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }    

        /// <summary>
        /// Goodbye - Say cya
        /// </summary>
        public Task Goodbye(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.Goodbye(payload, replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// Goodbye - Say cya
        /// </summary>
        public Task Goodbye(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("world.general.programmer.goodbye", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        /// <summary>
        /// GetAllGalaxies - 
        /// </summary>
        public Task GetAllGalaxies(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.GetAllGalaxies(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }    

        /// <summary>
        /// GetAllGalaxies - 
        /// </summary>
        public Task GetAllGalaxies(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.GetAllGalaxies(payload, replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// GetAllGalaxies - 
        /// </summary>
        public Task GetAllGalaxies(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("world.general.programmer.getallgalaxies", payload, replyHandler, timeoutHandler, waitTimeout);
        }
    }
}

                    
