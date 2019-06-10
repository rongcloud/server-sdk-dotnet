using io.rong.methods.user.block;
using io.rong.methods.user.onlineStatus;
using io.rong.models.conversation;
using io.rong.models;
using io.rong.models.response;
using io.rong.models.push;
using io.rong.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using io.rong.models.chatroom;

namespace io.rong.methods.chatroom.whitelist
{
    public class Whitelist

    {
        private static readonly Encoding UTF8 = Encoding.UTF8;
        private static readonly String PATH = "chatroom/whitelist";
        private String appKey;
        private String appSecret;
        private RongCloud rongCloud;
        private User user;
        private Messages message;

        public string AppKey { get => appKey; set => appKey = value; }
        public string AppSecret { get => appSecret; set => appSecret = value; }
        internal RongCloud RongCloud
        {
            get => rongCloud;
            set
            {
                rongCloud = value;
                message.RongCloud = value;
                user.RongCloud = value;
            }
        }
        internal User User { get => user; set => user = value; }
        internal Messages Message { get => message; set => message = value; }

        public Whitelist(String appKey, String appSecret)
        {
            this.appKey = appKey;
            this.appSecret = appSecret;
            this.message = new Messages(appKey, appSecret);
            this.user = new User(appKey, appSecret);
        }
    }
}
