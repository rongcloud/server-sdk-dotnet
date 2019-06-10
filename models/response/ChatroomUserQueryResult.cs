using io.rong.models.chatroom;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.models.response
{
    public class ChatroomUserQueryResult : Result

    {
        /**
         * 聊天室中用户数。
         *
         */
         [JsonProperty(PropertyName = "total")]
        int total;
        /**
         * 聊天室成员列表。
         *
         */
         [JsonProperty(PropertyName = "members")]
        List<ChatroomMember> members;

        [JsonIgnore]
        public int Total { get => total; set => total = value; }
        [JsonIgnore]
        internal List<ChatroomMember> Members { get => members; set => members = value; }

        public ChatroomUserQueryResult()
        {

        }

        public ChatroomUserQueryResult(int code, String msg, int total, List<ChatroomMember> members) : base(code, msg)
        {
            this.total = total;
            this.members = members;
        }

        public ChatroomUserQueryResult(int total, List<ChatroomMember> members)
        {
            this.total = total;
            this.members = members;
        }

        override
        public String ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
