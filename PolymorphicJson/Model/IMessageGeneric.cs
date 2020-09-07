using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphicJson.Model
{
    public interface IMessageGeneric<out TPayload>
        where TPayload : Payload
    {
        string Type { get; set; }
        TPayload Payload { get; }
    }
}
