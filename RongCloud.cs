using io.rong.methods.conversation;
using io.rong.methods.message;
using io.rong.methods.user;
using io.rong.methods.group;
using io.rong.methods.sensitive;
using io.rong.methods.chatroom;
using io.rong.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong
{
    class RongCloud
    {
        private static Dictionary<String, RongCloud> rongCloud = new Dictionary<String, RongCloud>();

        public User user;
        public Message message;
        public Wordfilter wordfilter;
        public SensitiveWord sensitiveword;
        public Group group;
        public Chatroom chatroom;
        public Conversation conversation;

        private List<HostType> apiHostType = new List<HostType> {
            new HostType("https://api.cn.ronghub.com"),
            new HostType("https://api-cn.ronghub.com")
        };
        private volatile int errNum = 0;
        private volatile int apiIndex = 0;
        private HostType smsHostType = new HostType("http://api.sms.ronghub.com");

        public int ErrNum
        {
            get { return errNum; }
            set { errNum = value; }
        }

        public HostType ApiHostType
        {
            get {
                if (apiIndex < apiHostType.Count && errNum <= 3)
                {
                    return apiHostType[apiIndex];
                } else
                {
                    return apiHostType[0];
                }
            }
        }

        public HostType SmsHostType
        {
            get { return this.smsHostType; }
            set { this.smsHostType = value; }
        }

        private RongCloud(String appKey, String appSecret)
        {
            user = new User(appKey, appSecret);
            user.RongCloud = this;
            message = new Message(appKey, appSecret);
            message.RongCloud = this;
            conversation = new Conversation(appKey, appSecret);
            conversation.RongCloud = this;
            group = new Group(appKey, appSecret);
            group.RongCloud = this;
            wordfilter = new Wordfilter(appKey, appSecret);
            wordfilter.RongCloud = this;
            sensitiveword = new SensitiveWord(appKey, appSecret);
            sensitiveword.RongCloud = this;
            chatroom = new Chatroom(appKey, appSecret);
            chatroom.RongCloud = this;
        }

        public static RongCloud GetInstance(String appKey, String appSecret)
        {
            if (!rongCloud.ContainsKey(appKey))
            {
                rongCloud.Add(appKey, new RongCloud(appKey, appSecret));
            }
            return rongCloud[appKey];
        }

        public static RongCloud GetInstance(String appKey, String appSecret, String api)
        {
            if (null == rongCloud[appKey])
            {
                RongCloud rc = new RongCloud(appKey, appSecret);
                if (api != null && api.Trim().Length > 0)
                {
                    rc.apiHostType.Add(new HostType(api));
                }
                rongCloud.Add(appKey, rc);
            }
            return rongCloud[appKey];
        }
    }
}
