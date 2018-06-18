using helloworld.Lib.DataClasses;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SMQ.SassyMQ.Lib.RabbitMQ
{
    public partial class StandardPayload
    {
        public const int DEFAULT_TIMEOUT = 30;

        public StandardPayload()
            : this(default(SMQActorBase))
        {

        }

        public StandardPayload(SMQActorBase actor)
            : this(actor, String.Empty)
        {

        }
        
        public StandardPayload(SMQActorBase actor, string content)
            : this(actor, content, true)
        {
        }

        public List<Galaxy> Galaxies { get; set; }
    }
}