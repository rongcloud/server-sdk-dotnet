using io.rong.messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.models.message
{

    public class BroadcastMessage : MessageModel

    {

        private String os;

        public BroadcastMessage()
        {
        }

        public BroadcastMessage(String senderUserId, String[] targetId, String objectName, BaseMessage content, String pushContent, String pushData,
                                String os) : base(senderUserId, targetId, objectName, content, pushContent, pushData)
        {
            this.os = os;
        }

        public string Os { get => os; set => os = value; }
    }
}