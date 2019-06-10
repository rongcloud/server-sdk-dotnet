using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.models.message
{
    public class MentionMessage

    {
        private String senderId;
        /**
         * 接收群 Id，提供多个本参数可以实现向多群发送消息，最多不超过 3 个群组。（必传）
         */
        private String[] targetId;
        private String objectName;
        /**
         * 消息 内容
         */
        private MentionMessageContent content;
        private String pushContent;
        private String pushData;
        private int isPersisted;
        private int isCounted;
        private int isIncludeSender;
        private int contentAvailable;

        public string[] TargetId { get => targetId; set => targetId = value; }
        public string ObjectName { get => objectName; set => objectName = value; }
        public MentionMessageContent Content { get => content; set => content = value; }
        public string PushContent { get => pushContent; set => pushContent = value; }
        public string PushData { get => pushData; set => pushData = value; }
        public int IsPersisted { get => isPersisted; set => isPersisted = value; }
        public int IsCounted { get => isCounted; set => isCounted = value; }
        public int IsIncludeSender { get => isIncludeSender; set => isIncludeSender = value; }
        public int ContentAvailable { get => contentAvailable; set => contentAvailable = value; }
        public string SenderId { get => senderId; set => senderId = value; }

        public MentionMessage()
        {
        }

        public MentionMessage(String senderId, String[] targetId, String objectName, MentionMessageContent content, String pushContent, String pushData,
                              int isPersisted, int isCounted, int isIncludeSender, int contentAvailable)
        {
            this.senderId = senderId;
            this.targetId = targetId;
            this.objectName = objectName;
            this.content = content;
            this.pushContent = pushContent;
            this.pushData = pushData;
            this.isPersisted = isPersisted;
            this.isCounted = isCounted;
            this.isIncludeSender = isIncludeSender;
            this.contentAvailable = contentAvailable;
        }
    }
}
