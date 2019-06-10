using io.rong.messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.models.message
{

    /**
     * 讨论组消息体
     * @author hc
     */
    public class DiscussionMessage : MessageModel

    {

        /**
         * 针对 iOS 平台，Push 时用来控制未读消息显示数，只有在 toUserId 为一个用户 Id 的时候有效。（可选）
         */
        private int isPersisted;
        /**
         * 当前版本有新的自定义消息，而老版本没有该自定义消息时，老版本客户端收到消息后是否进行未读消息计数，
         * 0 表示为不计数、 1 表示为计数，默认为 1 计数，未读消息数增加 1。（可选）
         */
        private int isCounted;

        /**
         * 当前版本有新的自定义消息，而老版本没有该自定义消息时，老版本客户端收到消息后是否进行未读消息计数，
         * 0 表示为不计数、 1 表示为计数，默认为 1 计数，未读消息数增加 1。（可选）
         */
        private int isIncludeSender;

        /**
         * ios静默推送 0关闭 1开启
         **/
        private int contentAvailable;

        public int IsPersisted { get => isPersisted; set => isPersisted = value; }
        public int IsCounted { get => isCounted; set => isCounted = value; }
        public int IsIncludeSender { get => isIncludeSender; set => isIncludeSender = value; }
        public int ContentAvailable { get => contentAvailable; set => contentAvailable = value; }

        public DiscussionMessage()
        {
        }

        public DiscussionMessage(String senderId, String[] targetId, String objectName, BaseMessage content, String pushContent, String pushData,
                                 int isPersisted, int isCounted, int isIncludeSender, int contentAvailable):base(senderId, targetId, objectName, content, pushContent, pushData)
        {
            
            this.isPersisted = isPersisted;
            this.isCounted = isCounted;
            this.isIncludeSender = isIncludeSender;
            this.contentAvailable = contentAvailable;
        }
    }
}
