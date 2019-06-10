using io.rong.models.user;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.models.response
{
    class ChatroomDemotionMsgResult : Result
    {
        [JsonProperty(PropertyName = "objectNames")]
        private String[] objectNames;

        [JsonIgnore]
        public string[] ObjectNames { get => objectNames; set => objectNames = value; }

        public ChatroomDemotionMsgResult()
        {

        }

        public ChatroomDemotionMsgResult(int code, String msg, String[] objectNames) : base(code, msg)
        {
            this.objectNames = objectNames;
        }

        public ChatroomDemotionMsgResult(String[] objectNames)
        {
            this.objectNames = objectNames;
        }

        override
        public String ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
