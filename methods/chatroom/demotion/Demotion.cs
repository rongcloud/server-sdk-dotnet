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

namespace io.rong.methods.chatroom.demotion
{
    public class Demotion

    {
        private static readonly Encoding UTF8 = Encoding.UTF8;
        private static readonly String PATH = "chatroom/demotion";
        private String appKey;
        private String appSecret;
        private RongCloud rongCloud;

        public string AppKey { get => appKey; set => appKey = value; }
        public string AppSecret { get => appSecret; set => appSecret = value; }
        internal RongCloud RongCloud { get => rongCloud; set => rongCloud = value; }

        public Demotion(String appKey, String appSecret)
        {
            this.appKey = appKey;
            this.appSecret = appSecret;

        }
        /**
         * 添加应用内聊天室降级消息
         *
         * @param  objectName:消息类型，每次最多提交 5 个，设置的消息类型最多不超过 20 个。（必传）
         *
         * @return ResponseResult
         **/
        public ResponseResult Add(String[] objectName)
        {
            String message = CommonUtil.CheckParam("type", objectName, PATH, CheckMethod.ADD);
            if (null != message)
            {
                return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(message);
            }
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < objectName.Length; i++)
            {
                String child = objectName[i];
                sb.Append("&objectName=").Append(HttpUtility.UrlEncode(child, UTF8));
            }

            String body = sb.ToString();
            if (body.IndexOf("&") == 0)
            {
                body = body.Substring(1, body.Length - 1);
            }
            String result = RongHttpClient.ExecutePost(appKey, appSecret, body,
                                       rongCloud.ApiHostType.Type + "/chatroom/message/priority/add.json", "application/x-www-form-urlencoded");

            return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.ADD, result));
        }

        /**
         * 移除应用内聊天室降级消息
         *
         * @param  objectNames:要销毁消息类型表。（必传）
         *
         * @return ResponseResult
         **/
        public ResponseResult Remove(String[] objectNames)
        {
            String message = CommonUtil.CheckParam("type", objectNames, PATH, CheckMethod.REMOVE);
            if (null != message)
            {
                return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(message);
            }
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < objectNames.Length; i++)
            {
                String child = objectNames[i];
                sb.Append("&objectName=").Append(HttpUtility.UrlEncode(child, UTF8));
            }

            String body = sb.ToString();
            if (body.IndexOf("&") == 0)
            {
                body = body.Substring(1, body.Length - 1);
            }

            String result = RongHttpClient.ExecutePost(appKey, appSecret, body,
                                          rongCloud.ApiHostType.Type + "/chatroom/message/priority/remove.json", "application/x-www-form-urlencoded");

            return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.REMOVE, result));


        }
        /**
         * 获取应用内聊天室降级消息
         *
         *
         * @return ResponseResult
         **/
        public ChatroomDemotionMsgResult GetList()
        {
            String result = RongHttpClient.ExecutePost(appKey, appSecret, "",
                            rongCloud.ApiHostType.Type + "/chatroom/message/priority/query.json", "application/x-www-form-urlencoded");

            return (ChatroomDemotionMsgResult)RongJsonUtil.JsonStringToObj<ChatroomDemotionMsgResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.GETLIST, result));
        }
    }
}
