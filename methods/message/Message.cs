using io.rong.methods.messages._private;
using io.rong.methods.messages.chatroom;
using io.rong.methods.messages.discussion;
using io.rong.methods.messages.system;
using io.rong.methods.messages.history;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace io.rong.methods.message
{
    class Message
    {

        private static readonly Encoding UTF8 = Encoding.UTF8;
        private static readonly String PATH = "message";
        private static String method = "";
        private String appKey;
        private String appSecret;
        public Private msgPrivate;
        public Chatroom chatroom;
        public Discussion discussion;
        public messages.group.Group group;
        public History history;
        public MsgSystem system;
        private RongCloud rongCloud;

        public RongCloud RongCloud
        {
            get => rongCloud;
            set
            {
                this.rongCloud = value;
                msgPrivate.RongCloud = value;
                chatroom.RongCloud = value;
                discussion.RongCloud = value;
                group.RongCloud = value;
                history.RongCloud = value;
                system.RongCloud = value;
            }
        }

        public Message(String appKey, String appSecret)
        {
            this.appKey = appKey;
            this.appSecret = appSecret;
            this.msgPrivate = new Private(appKey, appSecret);
            this.chatroom = new Chatroom(appKey, appSecret);
            this.discussion = new Discussion(appKey, appSecret);
            this.group = new messages.group.Group(appKey, appSecret);
            this.history = new History(appKey, appSecret);
            this.system = new MsgSystem(appKey, appSecret);

        }
    }
}
