using io.rong.messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.models.message
{
    class ChatroomMessage : MessageModel
    {

        public ChatroomMessage()
        {

        }

        public ChatroomMessage(String senderUserId, String[] targetId, String objectName, BaseMessage content) : base(senderUserId, targetId, objectName, content, null, null)
        {

        }

    }
}
