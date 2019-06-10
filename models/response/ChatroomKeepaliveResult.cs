using io.rong.models.push;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.models.response
{
    public class ChatroomKeepaliveResult : Result

    {
        [JsonProperty(PropertyName = "chatrooms")]
        private String[] chatrooms;

        public ChatroomKeepaliveResult(int code, String msg, String[] chatrooms) : base(code, msg)
        {
            this.chatrooms = chatrooms;
        }
        [JsonIgnore]
        public string[] Chatrooms { get => chatrooms; set => chatrooms = value; }


        override
        public String ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
