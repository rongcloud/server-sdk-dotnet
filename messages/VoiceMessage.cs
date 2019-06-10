using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.messages
{
    /**
     *
     * 语音消息。
     *
     */
    public class VoiceMessage : BaseMessage

    {
        [JsonProperty(PropertyName = "content")]
        private String content = "";
        [JsonProperty(PropertyName = "extra")]
        private String extra = "";
        [JsonProperty(PropertyName = "duration")]
        private long duration = 0L;
        private static readonly String TYPE = "RC:VcMsg";

        [JsonIgnore]
        public string Content { get => content; set => content = value; }
        [JsonIgnore]
        public string Extra { get => extra; set => extra = value; }
        [JsonIgnore]
        public long Duration { get => duration; set => duration = value; }

        public VoiceMessage(String content, String extra, long duration)
        {
            this.content = content;
            this.extra = extra;
            this.duration = duration;
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