using io.rong.models.chatroom;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.models.response
{
    class ListGagChatroomUserResult : Result
    {
        /**
         * 聊天室被禁言用户列表。
         *
         */
        [JsonProperty(PropertyName = "members")]
        List<ChatroomMember> members;

        [JsonIgnore]
        internal List<ChatroomMember> Members { get => members; set => members = value; }

        public ListGagChatroomUserResult()
        {

        }

        public ListGagChatroomUserResult(int code, String msg, List<ChatroomMember> members) : base(code, msg)
        {
            this.members = members;
        }

        public ListGagChatroomUserResult(List<ChatroomMember> members)
        {
            this.members = members;
        }

        override
        public String ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
