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

namespace io.rong.methods.chatroom.whitelist
{
    class Messages
    {
        private static readonly Encoding UTF8 = Encoding.UTF8;
        private static readonly String PATH = "chatroom/whitelist/message";
        private String appKey;
        private String appSecret;
        private RongCloud rongCloud;

        public string AppKey { get => appKey; set => appKey = value; }
        public string AppSecret { get => appSecret; set => appSecret = value; }
        internal RongCloud RongCloud { get => rongCloud; set => rongCloud = value; }

        public Messages(String appKey, String appSecret)
        {
            this.appKey = appKey;
            this.appSecret = appSecret;
        }
        /**
         * 添加聊天室消息白名单成员方法
         *
         * @param  objectNames:消息类型列表
         *
         * @return ResponseResult
         **/
        public ResponseResult Add(String[] objectNames)
        {
            if (objectNames == null)
            {
                return new ResponseResult(1002, "Paramer 'objectNames' is required");
            }

            String errMsg = CommonUtil.CheckParam("objectNames", objectNames, PATH, CheckMethod.ADD);
            if (null != errMsg)
            {
                return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(errMsg);
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < objectNames.Length; i++)
            {
                String child = objectNames[i];
                sb.Append("&objectnames=").Append(HttpUtility.UrlEncode(child, UTF8));
            }

            String body = sb.ToString();
            if (body.IndexOf("&") == 0)
            {
                body = body.Substring(1, body.Length - 1);
            }

            String result = RongHttpClient.ExecutePost(appKey, appSecret, body,
                                                     rongCloud.ApiHostType.Type + "/chatroom/whitelist/add.json", "application/x-www-form-urlencoded");

            return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.ADD, result));
        }

        /**
         * 删除聊天室消息白名单方法
         *
         * @param  objectNames:消息类型列表
         *
         * @return ResponseResult
         **/
        public ResponseResult Remove(String[] objectNames)
        {
            if (objectNames == null)
            {
                return new ResponseResult(1002, "Paramer 'objectNames' is required");
            }
            String errMsg = CommonUtil.CheckParam("objectNames", objectNames, PATH, CheckMethod.REMOVE);
            if (null != errMsg)
            {
                return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(errMsg);
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < objectNames.Length; i++)
            {
                String child = objectNames[i];
                sb.Append("&objectnames=").Append(HttpUtility.UrlEncode(child, UTF8));
            }
            String body = sb.ToString();
            if (body.IndexOf("&") == 0)
            {
                body = body.Substring(1, body.Length - 1);
            }
            String result = RongHttpClient.ExecutePost(appKey, appSecret, body,
                                                         rongCloud.ApiHostType.Type + "/chatroom/whitelist/delete.json", "application/x-www-form-urlencoded");

            return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.REMOVE, result));
        }

        /**
         * 获取聊天室消息类型白名单列表
         *
         *
         * @return ResponseResult
         **/
        public ChatroomWhitelistMsgResult GetList()
        {
            String result = RongHttpClient.ExecutePost(appKey, appSecret, "",
                          rongCloud.ApiHostType.Type + "/chatroom/whitelist/query.json", "application/x-www-form-urlencoded");

            return (ChatroomWhitelistMsgResult)RongJsonUtil.JsonStringToObj<ChatroomWhitelistMsgResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.GETLIST, result));

        }
    }
}

