using io.rong.methods.user.block;
using io.rong.methods.user.onlineStatus;
using io.rong.models.conversation;
using io.rong.models;
using io.rong.models.response;
using io.rong.models.user;
using io.rong.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using io.rong.models.chatroom;

namespace io.rong.methods.chatroom.distribute
{
    class Distribute
    {
        private static readonly Encoding UTF8 = Encoding.UTF8;
        private static readonly String PATH = "chatroom/distribute";
        private String appKey;
        private String appSecret;
        private RongCloud rongCloud;

        public string AppKey { get => appKey; set => appKey = value; }
        public string AppSecret { get => appSecret; set => appSecret = value; }
        internal RongCloud RongCloud { get => rongCloud; set => rongCloud = value; }

        public Distribute(String appKey, String appSecret)
        {
            this.appKey = appKey;
            this.appSecret = appSecret;

        }

        /**
         * 停止聊天室消息分发（可实现控制对聊天室中消息是否进行分发，停止分发后聊天室中用户发送的消息，融云服务端不会再将消息发送给聊天室中其他用户。）
         *
         * @param  chatroom:聊天室信息，其中聊天室 Id。（必传）
         *
         * @return ResponseResult
         **/
        public ResponseResult Stop(ChatroomModel chatroom)
        {
            String message = CommonUtil.CheckFiled(chatroom, PATH, CheckMethod.STOP_DISTRIBUTION);
            if (null != message)
            {
                return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(message);
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("&chatroomId=").Append(HttpUtility.UrlEncode(chatroom.Id.ToString(), UTF8));
            String body = sb.ToString();
            if (body.IndexOf("&") == 0)
            {
                body = body.Substring(1, body.Length - 1);
            }

            String result = RongHttpClient.ExecutePost(appKey, appSecret, body,
                                           rongCloud.ApiHostType.Type + "/chatroom/message/stopDistribution.json", "application/x-www-form-urlencoded");

            return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.STOP_DISTRIBUTION, result));

        }

        /**
         * 恢复聊天室消息分发
         *
         * @param  chatroom:聊天室 Id。（必传）
         *
         * @return ResponseResult
         **/
        public ResponseResult Resume(ChatroomModel chatroom)
        {
            String message = CommonUtil.CheckFiled(chatroom, PATH, CheckMethod.RESUME_DISTRIBUTION);
            if (null != message)
            {
                return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(message);
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("&chatroomId=").Append(HttpUtility.UrlEncode(chatroom.Id.ToString(), UTF8));
            String body = sb.ToString();
            if (body.IndexOf("&") == 0)
            {
                body = body.Substring(1, body.Length - 1);
            }
            String result = RongHttpClient.ExecutePost(appKey, appSecret, body,
                                               rongCloud.ApiHostType.Type + "/chatroom/message/resumeDistribution.json", "application/x-www-form-urlencoded");

            return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.RESUME_DISTRIBUTION, result));
        }
    }
}
