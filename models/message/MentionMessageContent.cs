using io.rong.messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.models.message
{
    public class MentionMessageContent

    {
        [JsonProperty(PropertyName = "content")]
        private BaseMessage content;
        [JsonProperty(PropertyName = "mentionedInfo")]
        private MentionedInfo mentionedInfo;

        [JsonIgnore]
        internal BaseMessage Content { get => content; set => content = value; }
        [JsonIgnore]
        public MentionedInfo MentionedInfo { get => mentionedInfo; set => mentionedInfo = value; }

        public MentionMessageContent(BaseMessage content, MentionedInfo mentionedInfo)
        {
            this.content = content;
            this.mentionedInfo = mentionedInfo;
        }

        override
        public String ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
