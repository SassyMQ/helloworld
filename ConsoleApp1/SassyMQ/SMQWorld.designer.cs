using System;
using System.Linq;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using System.Threading.Tasks;

namespace SMQ.SassyMQ.Lib.RabbitMQ
{
    public partial class SMQWorld : SMQActorBase
    {

        public SMQWorld(String amqpConnectionString)
            : base(amqpConnectionString, "world")
        {
        }

        protected override void CheckRouting(StandardPayload payload, BasicDeliverEventArgs  bdea)
        {
            try
            {
                switch (bdea.RoutingKey)
                {
                    
                    case "world.general.programmer.hello":
                        this.OnProgrammerHelloReceived(payload, bdea);
                        break;
                    
                    case "world.general.programmer.goodbye":
                        this.OnProgrammerGoodbyeReceived(payload, bdea);
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
        /// Responds to: Hello from Programmer
        /// </summary>
        public event EventHandler<PayloadEventArgs> ProgrammerHelloReceived;
        protected virtual void OnProgrammerHelloReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.ProgrammerHelloReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.ProgrammerHelloReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: Goodbye from Programmer
        /// </summary>
        public event EventHandler<PayloadEventArgs> ProgrammerGoodbyeReceived;
        protected virtual void OnProgrammerGoodbyeReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.ProgrammerGoodbyeReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.ProgrammerGoodbyeReceived(this, plea);
            }
        }

        /// <summary>
        /// WhatsUp - The World, says "Wassup?" back to the Programmer
        /// </summary>
        public Task WhatsUp(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.WhatsUp(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }    

        /// <summary>
        /// WhatsUp - The World, says "Wassup?" back to the Programmer
        /// </summary>
        public Task WhatsUp(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.WhatsUp(payload, replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// WhatsUp - The World, says "Wassup?" back to the Programmer
        /// </summary>
        public Task WhatsUp(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("programmer.general.world.whatsup", payload, replyHandler, timeoutHandler, waitTimeout);
        }
    }
}

                    
