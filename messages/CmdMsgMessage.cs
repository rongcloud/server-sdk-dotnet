using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.messages
{
    /**
     *
     * 通用命令通知消息。此类型消息没有 Push 通知。此类型消息没有 Push 通知，与通用命令通知消息的区别是不存储、不计数。
     *
     */
    class CmdMsgMessage : BaseMessage
    {
        [JsonProperty(PropertyName = "name")]
        private String name = "";
        [JsonProperty(PropertyName = "data")]
        private String data = "";
        private static readonly String TYPE = "RC:CmdMsg";

        [JsonIgnore]
        public string Name { get => name; set => name = value; }
        [JsonIgnore]
        public string Data { get => data; set => data = value; }

        public CmdMsgMessage(String name, String data)
        {
            this.name = name;
            this.data = data;
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