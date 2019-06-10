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

namespace io.rong.methods.chatroom.keepalive
{
    class Keepalive
    {
        private static readonly Encoding UTF8 = Encoding.UTF8;
        private static readonly String PATH = "chatroom/keepalive";
        private String appKey;
        private String appSecret;
        private RongCloud rongCloud;

        public string AppKey { get => appKey; set => appKey = value; }
        public string AppSecret { get => appSecret; set => appSecret = value; }
        internal RongCloud RongCloud { get => rongCloud; set => rongCloud = value; }

        public Keepalive(String appKey, String appSecret)
        {
            this.appKey = appKey;
            this.appSecret = appSecret;

        }
        /**
         * 添加聊天室保活方法
         *
         * @param   chatroom: 聊天室信息，id（必传）
         *
         * @return ResponseResult
         **/
        public ResponseResult Add(ChatroomModel chatroom)
        {

            String message = CommonUtil.CheckFiled(chatroom, PATH, CheckMethod.ADD);
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
                                                 rongCloud.ApiHostType.Type + "/chatroom/keepalive/add.json", "application/x-www-form-urlencoded");

            return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.ADD, result));
        }
        /**
         * 删除聊天室保活方法
         *
         * @param  chatroom: 聊天室信息，id（必传）
         *
         * @return ResponseResult
         **/
        public ResponseResult Remove(ChatroomModel chatroom)
        {
            String message = CommonUtil.CheckFiled(chatroom, PATH, CheckMethod.REMOVE);
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
                                                     rongCloud.ApiHostType.Type + "/chatroom/keepalive/remove.json", "application/x-www-form-urlencoded");

            return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.REMOVE, result));
        }
        /**
         * 获取聊天室保活
         *
         *
         * @return ResponseResult
         **/
        public ChatroomKeepaliveResult GetList()
        {
            String result = RongHttpClient.ExecutePost(appKey, appSecret, "",
                           rongCloud.ApiHostType.Type + "/chatroom/keepalive/query.json", "application/x-www-form-urlencoded");

            return (ChatroomKeepaliveResult)RongJsonUtil.JsonStringToObj<ChatroomKeepaliveResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.GETLIST, result));
        }
    }
}
