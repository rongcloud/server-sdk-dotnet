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
    public class User

    {
        private static readonly Encoding UTF8 = Encoding.UTF8;
        private static readonly String PATH = "chatroom/whitelist/user";
        private String appKey;
        private String appSecret;
        private RongCloud rongCloud;

        public string AppKey { get => appKey; set => appKey = value; }
        public string AppSecret { get => appSecret; set => appSecret = value; }
        internal RongCloud RongCloud { get => rongCloud; set => rongCloud = value; }

        public User(String appKey, String appSecret)
        {
            this.appKey = appKey;
            this.appSecret = appSecret;

        }
        /**
         * 添加聊天室白名单成员方法
         *
         * @param  chatroom:聊天室.Id，memberIds 聊天室中白名单成员最多不超过 5 个。（必传）
         *
         * @return ResponseResult
         **/
        public ResponseResult Add(ChatroomModel chatroom)
        {

            if (chatroom == null)
            {
                return new ResponseResult(1002, "Paramer 'chatroom' is required");
            }

            String message = CommonUtil.CheckFiled(chatroom, PATH, CheckMethod.ADD);
            if (null != message)
            {
                return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(message);
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("&chatroomId=").Append(HttpUtility.UrlEncode(chatroom.Id.ToString(), UTF8));

            ChatroomMember[] members = chatroom.Members;
            foreach (var member in members)
            {
                sb.Append("&userId=").Append(HttpUtility.UrlEncode(member.Id, UTF8));
            }
            String body = sb.ToString();
            if (body.IndexOf("&") == 0)
            {
                body = body.Substring(1, body.Length - 1);
            }
            String result = RongHttpClient.ExecutePost(appKey, appSecret, body,
                                                         rongCloud.ApiHostType.Type + "/chatroom/user/whitelist/add.json", "application/x-www-form-urlencoded");

            return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.ADD, result));
        }
        /**
         * 添加聊天室白名单成员方法
         *
         * @param  chatroom:聊天室.Id，memberIds 聊天室中白名单成员最多不超过 5 个。（必传）
         *
         * @return ResponseResult
         **/
        public ResponseResult Remove(ChatroomModel chatroom)
        {
            if (chatroom == null)
            {
                return new ResponseResult(1002, "Paramer 'chatroom' is required");
            }

            String message = CommonUtil.CheckFiled(chatroom, PATH, CheckMethod.REMOVE);
            if (null != message)
            {
                return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(message);
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("&chatroomId=").Append(HttpUtility.UrlEncode(chatroom.Id.ToString(), UTF8));

            ChatroomMember[] members = chatroom.Members;
            foreach (var member in members)
            {
                sb.Append("&userId=").Append(HttpUtility.UrlEncode(member.Id, UTF8));
            }

            String body = sb.ToString();
            if (body.IndexOf("&") == 0)
            {
                body = body.Substring(1, body.Length - 1);
            }
            String result = RongHttpClient.ExecutePost(appKey, appSecret, body,
                                                                     rongCloud.ApiHostType.Type + "/chatroom/user/whitelist/remove.json", "application/x-www-form-urlencoded");

            return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.REMOVE, result));
        }

        /**
         * 添加聊天室白名单成员方法
         *
         *
         * @return WhiteListResult
         **/
        public WhiteListResult GetList(ChatroomModel chatroom)
        {
            if (chatroom == null)
            {
                return new WhiteListResult(1002, "Paramer 'chatroom' is required");
            }

            String message = CommonUtil.CheckFiled(chatroom, PATH, CheckMethod.GETLIST);
            if (null != message)
            {
                return (WhiteListResult)RongJsonUtil.JsonStringToObj<WhiteListResult>(message);
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("&chatroomId=").Append(HttpUtility.UrlEncode(chatroom.Id.ToString(), UTF8));

            String body = sb.ToString();
            if (body.IndexOf("&") == 0)
            {
                body = body.Substring(1, body.Length - 1);
            }
            String result = RongHttpClient.ExecutePost(appKey, appSecret, body,
                                                             rongCloud.ApiHostType.Type + "/chatroom/user/whitelist/query.json", "application/x-www-form-urlencoded");

            return (WhiteListResult)RongJsonUtil.JsonStringToObj<WhiteListResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.GETLIST, result));
        }
    }
}
