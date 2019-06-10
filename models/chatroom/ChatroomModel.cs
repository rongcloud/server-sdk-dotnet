using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.models.chatroom
{
    class ChatroomModel
    {
        /**
         * 聊天室 id。
         */
         [JsonProperty(PropertyName ="id")]
        String id;
        /**
         * 聊天室名。
         */
         [JsonProperty(PropertyName = "name")]
        String name;
        /**
         * 聊天室创建时间。
         */
        [JsonProperty(PropertyName = "time")]
        String time;
        /**
         * 聊天室成员。
         */
        [JsonProperty(PropertyName = "members")]
        ChatroomMember[] members;
        /**
         * 聊天室成员数。
         */
        [JsonProperty(PropertyName = "count")]
        int count;
        /**
         * 加入聊天室的先后顺序,1正序，2倒叙。
         */
        [JsonProperty(PropertyName = "order")]
        int order;

        /**
         * 禁言时间
         * */
        [JsonProperty(PropertyName = "minute")]
        int minute;

        [JsonIgnore]
        public string Id { get => id; set => id = value; }
        [JsonIgnore]
        public string Name { get => name; set => name = value; }
        [JsonIgnore]
        public string Time { get => time; set => time = value; }
        [JsonIgnore]
        public ChatroomMember[] Members { get => members; set => members = value; }
        [JsonIgnore]
        public int Count { get => count; set => count = value; }
        [JsonIgnore]
        public int Order { get => order; set => order = value; }
        [JsonIgnore]
        public int Minute { get => minute; set => minute = value; }

        public ChatroomModel() : base()
        {

        }
        /**
         * 聊天室构造函数 全量
         * */
        public ChatroomModel(String id, String name, String time, ChatroomMember[] members,
                             int count, int order, int minute)
        {
            this.id = id;
            this.name = name;
            this.time = time;
            this.members = members;
            this.count = count;
            this.order = order;
            this.minute = minute;
        }

        override
        public String ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
