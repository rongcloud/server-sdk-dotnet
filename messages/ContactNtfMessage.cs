using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.messages
{
    /**
     *
     * 添加联系人消息。
     *
     */
    public class ContactNtfMessage : BaseMessage

    {
        [JsonProperty(PropertyName = "operation")]
        private String operation = "";
        [JsonProperty(PropertyName = "extra")]
        private String extra = "";
        [JsonProperty(PropertyName = "sourceUserId")]
        private String sourceUserId = "";
        [JsonProperty(PropertyName = "targetUserId")]
        private String targetUserId = "";
        [JsonProperty(PropertyName = "message")]
        private String message = "";
        private static readonly String TYPE = "RC:ContactNtf";

        [JsonIgnore]
        public string Operation { get => operation; set => operation = value; }
        [JsonIgnore]
        public string Extra { get => extra; set => extra = value; }
        [JsonIgnore]
        public string SourceUserId { get => sourceUserId; set => sourceUserId = value; }
        [JsonIgnore]
        public string TargetUserId { get => targetUserId; set => targetUserId = value; }
        [JsonIgnore]
        public string Message { get => message; set => message = value; }

        public ContactNtfMessage(String operation, String extra, String sourceUserId, String targetUserId, String message)
        {
            this.operation = operation;
            this.extra = extra;
            this.sourceUserId = sourceUserId;
            this.targetUserId = targetUserId;
            this.message = message;
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