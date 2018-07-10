using System;
using System.Linq;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using System.Threading.Tasks;

namespace SMQ.SassyMQ.Lib.RabbitMQ
{
    public partial class SMQUniverse : SMQActorBase
    {

        public SMQUniverse(String amqpConnectionString)
            : base(amqpConnectionString, "universe")
        {
        }

        protected override void CheckRouting(StandardPayload payload, BasicDeliverEventArgs  bdea)
        {
            try
            {
                switch (bdea.RoutingKey)
                {
                    
                }

            }
            catch (Exception ex)
            {
                payload.ErrorMessage = ex.Message;
            }
            this.Reply(payload, bdea.BasicProperties.ReplyTo);
        }

        
        /// <summary>
        /// YoYo - I'm ej
        /// </summary>
        public Task YoYo(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.YoYo(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }    

        /// <summary>
        /// YoYo - I'm ej
        /// </summary>
        public Task YoYo(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.YoYo(payload, replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// YoYo - I'm ej
        /// </summary>
        public Task YoYo(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("world.general.universe.yoyo", payload, replyHandler, timeoutHandler, waitTimeout);
        }
    }
}

                    
