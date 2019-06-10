using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.models.chatroom
{
    public class ChatroomMember

    {
        /**
         * 聊天室用户Id。
         * */
        [JsonProperty(PropertyName = "id")]
        private String id;
        /**
         * 加入聊天室时间。
         * */
        [JsonProperty(PropertyName = "time")]
        private String time;
        /**
         * 聊天室ID
         * */
        [JsonProperty(PropertyName = "chatroomId")]
        private String chatroomId;

        [JsonProperty(PropertyName = "munite")]
        private int munite;

        [JsonIgnore]
        public string Id { get => id; set => id = value; }
        [JsonIgnore]
        public string Time { get => time; set => time = value; }
        [JsonIgnore]
        public string ChatroomId { get => chatroomId; set => chatroomId = value; }
        [JsonIgnore]
        public int Munite { get => munite; set => munite = value; }

        public ChatroomMember():base()
        {
            
        }
        public ChatroomMember(String id, String time)
        {
            this.id = id;
            this.time = time;
        }

        public ChatroomMember(String id, String chatroomId, String time)
        {
            this.id = id;
            this.chatroomId = chatroomId;
            this.time = time;
        }
        
        /**
         * 获取禁言时长
         *
         * @return String
         */
        public int getMunite()
        {
            return this.munite;
        }
        /**
         * 设置munite
         *
         *
         */
        public void setMunite(int munite)
        {
            this.munite = munite;
        }
        override
        public String ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }

    }
}
