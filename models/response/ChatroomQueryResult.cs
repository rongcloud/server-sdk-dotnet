using io.rong.models.chatroom;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.models.response
{
    class ChatroomQueryResult : Result
    {
        [JsonProperty(PropertyName = "chatRooms")]
        List<ChatroomModel> chatRooms;

        [JsonIgnore]
        internal List<ChatroomModel> ChatRooms { get => chatRooms; set => chatRooms = value; }

        public ChatroomQueryResult()
        {

        }
        public ChatroomQueryResult(int code, String errorMessage, List<ChatroomModel> chatRooms) : base(code, errorMessage)
        {
            this.chatRooms = chatRooms;
        }

        override
        public String ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
