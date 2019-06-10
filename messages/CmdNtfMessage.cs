using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.messages
{

    /**
     *
     * 通用命令通知消息。此类型消息没有 Push 通知。
     *
     */
    public class CmdNtfMessage : BaseMessage

    {
        [JsonProperty(PropertyName = "name")]
        private String name = "";
        [JsonProperty(PropertyName = "data")]
        private String data = "";
        private static readonly String TYPE = "RC:CmdNtf";

        [JsonIgnore]
        public string Name { get => name; set => name = value; }
        [JsonIgnore]
        public string Data { get => data; set => data = value; }

        public CmdNtfMessage(String name, String data)
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