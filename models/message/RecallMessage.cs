using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.models.message
{
    public class RecallMessage
    {
        /**
         * 撤回消息体
         * 发送人id
         * */
        private String senderId;
        /**
         * 接收人id
         * */
        private String targetId;
        /**
         * 消息唯一标识 各端 SDK 发送消息成功后会返回 uId
         * */
        private String uId;
        /**
         * 消息的发送时间，各端 SDK 发送消息成功后会返回 sentTime
         * */
        private String sentTime;

        public string SenderId { get => senderId; set => senderId = value; }
        public string TargetId { get => targetId; set => targetId = value; }
        public string UId { get => uId; set => uId = value; }
        public string SentTime { get => sentTime; set => sentTime = value; }

        public RecallMessage()
        {
        }

        /**
         * @param senderId	String	消息发送人用户 Id。（必传）
         * @param conversationType	Int	会话类型，二人会话是 1 、讨论组会话是 2 、群组会话是 3 。（必传）
         * @param targetId	String	目标 Id，根据不同的 ConversationType，可能是用户 Id、讨论组 Id、群组 Id。（必传）
         * @param uId	String	消息唯一标识，可通过服务端实时消息路由获取，对应名称为 msgUID。（必传）
         * @param sentTime
         *
         * */
        public RecallMessage(String senderId, String conversationType, String targetId,
                             String uId, String sentTime)
        {
            this.senderId = senderId;
            this.targetId = targetId;
            this.uId = uId;
            this.sentTime = sentTime;
        }
    }
}