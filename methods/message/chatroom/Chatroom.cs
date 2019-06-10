using io.rong.models;
using io.rong.models.response;
using System;
using System.Collections.Generic;
using System.Text;
using io.rong.models.message;
using io.rong.exception;
using io.rong.util;
using System.Web;
using io.rong.util;

namespace io.rong.methods.messages.chatroom
{
    /**
     * 发送聊天室消息方法
     * docs : http://www.rongcloud.cn/docs/server.html#message_chatroom_publish
     *
     */
    public class Chatroom

    {
        private static readonly Encoding UTF8 = Encoding.UTF8;
        private static readonly String PATH = "message/chatroom";
        private String appKey;
        private String appSecret;
        private RongCloud rongCloud;

        public string AppKey { get => appKey; set => appKey = value; }
        public string AppSecret { get => appSecret; set => appSecret = value; }
        internal RongCloud RongCloud { get => rongCloud; set => rongCloud = value; }

        public Chatroom(String appKey, String appSecret)
        {
            this.appKey = appKey;
            this.appSecret = appSecret;

        }

        /**
         * 发送聊天室消息方法（一个用户向聊天室发送消息，单条消息最大 128k。每秒钟限 100 次。）
         *
         * @param  message:发送消息内容，参考融云消息类型表.示例说明；如果 objectName 为自定义消息类型，该参数可自定义格式。融云消息类型在messages下，自定义消息继承BaseMessage即可（必传）
         *
         * @return ResponseResult
         * @throws Exception
         **/
        public ResponseResult Send(ChatroomMessage message)
        {

            String errMsg = CommonUtil.CheckFiled(message, PATH, CheckMethod.SEND);
            if (null != errMsg)
            {
                return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(errMsg);
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("&fromUserId=").Append(HttpUtility.UrlEncode(message.SenderId, UTF8));

            for (int i = 0; i < message.TargetId.Length; i++)
            {
                String child = message.TargetId[i];
                if (null != child)
                {
                    sb.Append("&toChatroomId=").Append(HttpUtility.UrlEncode(child, UTF8));
                }
            }

            sb.Append("&objectName=").Append(HttpUtility.UrlEncode(message.Content.GetType(), UTF8));
            sb.Append("&content=").Append(HttpUtility.UrlEncode(message.Content.ToString(), UTF8));
            String body = sb.ToString();
            if (body.IndexOf("&") == 0)
            {
                body = body.Substring(1, body.Length - 1);
            }

            String result = RongHttpClient.ExecutePost(appKey, appSecret, body,
                                   rongCloud.ApiHostType.Type + "/message/chatroom/publish.json", "application/x-www-form-urlencoded");

            return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.PUBLISH, result));
        }

        /**
         * 发送聊天室消广播消息方法（一个用户向聊天室发送消息，单条消息最大 128k。每秒钟限 100 次。）
         *
         * @param  message:发送消息内容，参考融云消息类型表.示例说明；如果 objectName 为自定义消息类型，该参数可自定义格式。融云消息类型在messages下，自定义消息继承BaseMessage即可（必传）
         *
         * @return ResponseResult
         * @throws Exception
         **/
        public ResponseResult Broadcast(ChatroomMessage message)
        {

            String code = CommonUtil.CheckFiled(message, PATH, CheckMethod.BROADCAST);
            if (null != code)
            {
                return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(code);
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("&fromUserId=").Append(HttpUtility.UrlEncode(message.SenderId.ToString(), UTF8));


            sb.Append("&objectName=").Append(HttpUtility.UrlEncode(message.Content.GetType(), UTF8));
            sb.Append("&content=").Append(HttpUtility.UrlEncode(message.Content.ToString(), UTF8));
            String body = sb.ToString();
            if (body.IndexOf("&") == 0)
            {
                body = body.Substring(1, body.Length - 1);
            }

            String result = RongHttpClient.ExecutePost(appKey, appSecret, body,
                                      rongCloud.ApiHostType.Type + "/message/chatroom/broadcast.json", "application/x-www-form-urlencoded");

            return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.BROADCAST, result));

        }
    }
}
