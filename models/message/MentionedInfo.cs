using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.models.message
{
    public class MentionedInfo
    {
        [JsonProperty(PropertyName = "type")]
        private int type;
        [JsonProperty(PropertyName = "userIds")]
        private String[] userIds;
        [JsonProperty(PropertyName = "pushContent")]
        private String pushContent;

        [JsonIgnore]
        public int Type { get => type; set => type = value; }
        [JsonIgnore]
        public string[] UserIds { get => userIds; set => userIds = value; }
        [JsonIgnore]
        public string PushContent { get => pushContent; set => pushContent = value; }

        public MentionedInfo(int type, String[] userIds, String pushContent)
        {
            this.type = type;
            this.userIds = userIds;
            this.pushContent = pushContent;
        }
    }
}
