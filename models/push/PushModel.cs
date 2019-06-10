using System;
using Newtonsoft.Json;

namespace io.rong.models.push
{
    public class PushModel : BroadcastPushPublicPart
    {
        override
        public String ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
