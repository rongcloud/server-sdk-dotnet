using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.models.conversation
{
    class ConversationModel
    {
        [JsonProperty(PropertyName = "type")]
        private String type;
        [JsonProperty(PropertyName = "userId")]
        private String userId;
        [JsonProperty(PropertyName = "targetId")]
        private String targetId;

        [JsonIgnore]
        public string Type { get => type; set => type = value; }
        [JsonIgnore]
        public string UserId { get => userId; set => userId = value; }
        [JsonIgnore]
        public string TargetId { get => targetId; set => targetId = value; }

        public ConversationModel()
        {
        }

        /**
         * 构造函数。
         *
         * @param type:会话类型。
         * @param userId:设置消息免打扰的用户 Id
         * @param targetId:目标Id
         *
         **/
        public ConversationModel(String type, String userId, String targetId)
        {
            this.type = type;
            this.userId = userId;
            this.targetId = targetId;
        }
    }
}
