using io.rong.messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.models.message
{
    public class MessageModel

    {
        [JsonProperty(PropertyName = "senderId")]
        private String senderId;
        /**
         *
         * 接受 Id 可能是用户Id，聊天Id ，群组Id，讨论组Id（必传）
         **/
        [JsonProperty(PropertyName = "targetId")]
        private String[] targetId;
        /**
         *消息类型 （必传）
         **/
        [JsonProperty(PropertyName = "objectName")]
        private String objectName;
        /**
         * 发送消息内容，参考融云消息类型表.示例说明；如果 objectName
         * 为自定义消息类型，该参数可自定义格式。（必传）。
         **/
        [JsonProperty(PropertyName = "content")]
        private BaseMessage content;
        /**
         * 定义显示的 Push 内容，如果 objectName 为融云内置消息类型时，
         * 则发送后用户一定会收到 Push 信息。如果为自定义消息，则 pushContent
         * 为自定义消息显示的 Push 内容，如果不传则用户不会收到 Push 通知。（可选）
         */
        [JsonProperty(PropertyName = "pushContent")]
        private String pushContent;
        /**
         * 针对 iOS 平台为 Push 通知时附加到 payload 中，Android 客户端收到推送消息时对应字段名为 pushData。（可选）
         */
        [JsonProperty(PropertyName = "pushData")]
        private String pushData;

        [JsonIgnore]
        public string SenderId { get => senderId; set => senderId = value; }
        [JsonIgnore]
        public string[] TargetId { get => targetId; set => targetId = value; }
        [JsonIgnore]
        public string ObjectName { get => objectName; set => objectName = value; }
        [JsonIgnore]
        public BaseMessage Content { get => content; set => content = value; }
        [JsonIgnore]
        public string PushContent { get => pushContent; set => pushContent = value; }
        [JsonIgnore]
        public string PushData { get => pushData; set => pushData = value; }

        public MessageModel()
        {
        }

        public MessageModel(String senderId, String[] targetId, String objectName, BaseMessage content,
                            String pushContent, String pushData)
        {
            this.senderId = senderId;
            this.targetId = targetId;
            this.objectName = objectName;
            this.content = content;
            this.pushContent = pushContent;
            this.pushData = pushData;
        }
    }
}
