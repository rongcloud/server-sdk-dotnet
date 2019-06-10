using io.rong.util;
using io.rong.methods.user.blacklist;
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

namespace io.rong.methods.conversation
{
    /**
     *
     * 会话消息免打扰服务
     * docs: "http://www.rongcloud.cn/docs/server.html#conversation_notification"
     *
     * */
    public class Conversation

    {
        private static readonly Encoding UTF8 = Encoding.UTF8;
        private static readonly String PATH = "conversation";
        private static String method = "";
        private String appKey;
        private String appSecret;
        private RongCloud rongCloud;

        public string AppKey { get => appKey; set => appKey = value; }
        public string AppSecret { get => appSecret; set => appSecret = value; }
        internal RongCloud RongCloud { get => rongCloud; set => rongCloud = value; }
        
        public Conversation(String appKey, String appSecret)
        {
            this.appKey = appKey;
            this.appSecret = appSecret;

        }
        /**
         * 设置用户某会话接收新消息时是否进行消息提醒。
         *
         * @param conversation 会话信息 其中type(必传)
         * @return ResponseResult
         **/
        public ResponseResult Mute(ConversationModel conversation)
        {
            String message = CommonUtil.CheckFiled(conversation, PATH, CheckMethod.MUTE);
            if (null != message)
            {
                return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(message);
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("&conversationType=").Append(HttpUtility.UrlEncode(conversation.Type.ToString(), UTF8));
            sb.Append("&requestId=").Append(HttpUtility.UrlEncode(conversation.UserId.ToString(), UTF8));
            sb.Append("&targetId=").Append(HttpUtility.UrlEncode(conversation.TargetId.ToString(), UTF8));
            sb.Append("&isMuted=").Append(HttpUtility.UrlEncode("1", UTF8));
            String body = sb.ToString();
            if (body.IndexOf("&") == 0)
            {
                body = body.Substring(1, body.Length - 1);
            }
            String result = RongHttpClient.ExecutePost(appKey, appSecret, body,
                        rongCloud.ApiHostType.Type + "/conversation/notification/set.json", "application/x-www-form-urlencoded");

            return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.MUTE, result));
        }

        /**
         * 设置用户某会话接收新消息时是否进行消息提醒。
         *
         * @param conversation 会话信息 其中type(必传)
         * @return ResponseResult
         **/
        public ResponseResult UnMute(ConversationModel conversation)
        {
            String message = CommonUtil.CheckFiled(conversation, PATH, CheckMethod.UNMUTE);
            if (null != message)
            {
                return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(message);
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("&conversationType=").Append(HttpUtility.UrlEncode(conversation.Type.ToString(), UTF8));
            sb.Append("&requestId=").Append(HttpUtility.UrlEncode(conversation.UserId.ToString(), UTF8));
            sb.Append("&targetId=").Append(HttpUtility.UrlEncode(conversation.TargetId.ToString(), UTF8));
            sb.Append("&isMuted=").Append(HttpUtility.UrlEncode("0", UTF8));
            String body = sb.ToString();
            if (body.IndexOf("&") == 0)
            {
                body = body.Substring(1, body.Length - 1);
            }

            String result = RongHttpClient.ExecutePost(appKey, appSecret, body,
                           rongCloud.ApiHostType.Type + "/conversation/notification/set.json", "application/x-www-form-urlencoded");

            return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.UNMUTE, result));

        }
    }
}