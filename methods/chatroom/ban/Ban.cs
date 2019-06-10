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

namespace io.rong.methods.chatroom.ban
{

    /**
     * 聊天室全局禁言服务
     * docs:http://www.rongcloud.cn/docs/server.html#chatroom_user_ban
     *
     * */
    public class Ban

    {
        private static readonly Encoding UTF8 = Encoding.UTF8;
        private static readonly String PATH = "chatroom/global-gag";
        private String appKey;
        private String appSecret;
        private RongCloud rongCloud;

        public Ban(String appKey, String appSecret)
        {
            this.appKey = appKey;
            this.appSecret = appSecret;
        }

        public string AppKey { get => appKey; set => appKey = value; }
        public string AppSecret { get => appSecret; set => appSecret = value; }
        internal RongCloud RongCloud { get => rongCloud; set => rongCloud = value; }

        /**
        * 添加用户聊天室全局禁言方法
        *
        * @param  chatroom : Id,minute。（必传）
        *
        * @return ResponseResult
        **/
        public ResponseResult Add(ChatroomModel chatroom)
        {
            String errMsg = CommonUtil.CheckFiled(chatroom, PATH, CheckMethod.ADD);
            if (null != errMsg)
            {
                return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(errMsg);
            }

            StringBuilder sb = new StringBuilder();
            ChatroomMember[] members = chatroom.Members;
            foreach (var member in members)
            {
                sb.Append("&userId=").Append(HttpUtility.UrlEncode(member.Id, UTF8));
            }
            sb.Append("&minute=").Append(HttpUtility.UrlEncode(chatroom.Minute.ToString(), UTF8));
            String body = sb.ToString();
            if (body.IndexOf("&") == 0)
            {
                body = body.Substring(1, body.Length - 1);
            }

            String result = RongHttpClient.ExecutePost(appKey, appSecret, body,
                            rongCloud.ApiHostType.Type + "/chatroom/user/ban/add.json", "application/x-www-form-urlencoded");

            return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.ADD, result));
        }

        /**
         * 查询被聊天室全局禁言用户方法
         *
         * @return ListGagChatroomUserResult
         **/
        public ListGagChatroomUserResult GetList()
        {
            String result = RongHttpClient.ExecutePost(appKey, appSecret, "",
                            rongCloud.ApiHostType.Type + "/chatroom/user/ban/query.json", "application/x-www-form-urlencoded");

            return (ListGagChatroomUserResult)RongJsonUtil.JsonStringToObj<ListGagChatroomUserResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.GETLIST, result));
        }

        /**
         * 移除用户聊天室全局禁言方法
         *
         * @param  chatroom: memberIds。（必传）
         *
         * @return ResponseResult
         **/
        public ResponseResult Remove(ChatroomModel chatroom)
        {
            if (chatroom == null)
            {
                return new ResponseResult(1002, "Paramer 'chatroom' is required");
            }

            String errMsg = CommonUtil.CheckFiled(chatroom, PATH, CheckMethod.REMOVE);
            if (null != errMsg)
            {
                return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(errMsg);
            }

            StringBuilder sb = new StringBuilder();
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
                               rongCloud.ApiHostType.Type + "/chatroom/user/ban/remove.json", "application/x-www-form-urlencoded");

            return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.REMOVE, result));
        }
    }
}


