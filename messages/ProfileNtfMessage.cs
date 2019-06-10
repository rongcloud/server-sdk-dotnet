using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.messages
{
    /**
     *
     * 资料通知消息。此类型消息没有 Push 通知。
     *
     */
    class ProfileNtfMessage : BaseMessage
    {
        [JsonProperty(PropertyName = "operation")]
        private String operation = "";
        [JsonProperty(PropertyName = "data")]
        private String data = "";
        [JsonProperty(PropertyName = "extra")]
        private String extra = "";
        private static readonly String TYPE = "RC:ProfileNtf";

        [JsonIgnore]
        public string Operation { get => operation; set => operation = value; }
        [JsonIgnore]
        public string Data { get => data; set => data = value; }
        [JsonIgnore]
        public string Extra { get => extra; set => extra = value; }

        public ProfileNtfMessage(String operation, String data, String extra)
        {
            this.operation = operation;
            this.data = data;
            this.extra = extra;
        }
        override
        public String GetType()
        {
            return TYPE;
        }



        override
        public String ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}