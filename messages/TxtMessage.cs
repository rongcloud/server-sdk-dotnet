using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.messages
{
    /**
     *
     * 文本消息。
     *
     */
    public class TxtMessage : BaseMessage

    {
        [JsonProperty(PropertyName = "content")]
        private String content = "";
        [JsonProperty(PropertyName = "extra")]
        private String extra = "";
        private static readonly String TYPE = "RC:TxtMsg";

        [JsonIgnore]
        public string Content { get => content; set => content = value; }
        [JsonIgnore]
        public string Extra { get => extra; set => extra = value; }

        public TxtMessage(String content, String extra)
        {
            this.content = content;
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