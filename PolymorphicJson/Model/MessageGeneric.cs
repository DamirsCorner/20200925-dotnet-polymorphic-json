using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphicJson.Model
{
    public class MessageGeneric<TPayload> : IMessageGeneric<TPayload>
        where TPayload: Payload
    {
        public string Type { get; set; }
        public TPayload Payload { get; set; }
    }
}
