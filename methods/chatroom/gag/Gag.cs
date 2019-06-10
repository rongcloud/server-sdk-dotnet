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

namespace io.rong.methods.chatroom.gag
{
    class Gag
    {
        private static readonly Encoding UTF8 = Encoding.UTF8;
        private static readonly String PATH = "chatroom/member-gag";
        private String appKey;
        private String appSecret;
        private RongCloud rongCloud;

        public string AppKey { get => appKey; set => appKey = value; }
        public string AppSecret { get => appSecret; set => appSecret = value; }
        internal RongCloud RongCloud { get => rongCloud; set => rongCloud = value; }

        public RongCloud getRongCloud()
        {
            return rongCloud;
        }
        public void setRongCloud(RongCloud rongCloud)
        {
            this.rongCloud = rongCloud;
        }
        public Gag(String appKey, String appSecret)
        {
            this.appKey = appKey;
            this.appSecret = appSecret;

        }
        /**
         * 添加禁言聊天室成员方法（在 App 中如果不想让某一用户在聊天室中发言时，可将此用户在聊天室中禁言，被禁言用户可以接收查看聊天室中用户聊天信息，但不能发送消息.）
         *
         * @param  chatroom:封禁的聊天室信息，其中聊天室 d（必传）,minute(必传), memberIds（必传支持多个最多20个）
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
            /* message = CommonUtil.checkParam("minute",minute,PATH,CheckMethod.ADD);
             if(null != message){
                 return (ResponseResult)RongJsonUtil.JsonStringToObj(message,ResponseResult.class);
             }*/

            StringBuilder sb = new StringBuilder();
            ChatroomMember[] members = chatroom.Members;
            foreach (var member in members)
            {
                sb.Append("&userId=").Append(HttpUtility.UrlEncode(member.Id, UTF8));
            }
            sb.Append("&chatroomId=").Append(HttpUtility.UrlEncode(chatroom.Id.ToString(), UTF8));
            sb.Append("&minute=").Append(HttpUtility.UrlEncode(chatroom.Minute.ToString(), UTF8));
            String body = sb.ToString();
            if (body.IndexOf("&") == 0)
            {
                body = body.Substring(1, body.Length - 1);
            }
            String result = RongHttpClient.ExecutePost(appKey, appSecret, body,
                                              rongCloud.ApiHostType.Type + "/chatroom/user/gag/add.json", "application/x-www-form-urlencoded");

            return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.ADD, result));
        }

        /**
         * 查询聊天室被禁言成员方法
         *
         * @param  chatroom:聊天室信息 Id。（必传）
         *
         * @return ListGagChatroomUserResult
         **/
        public ListGagChatroomUserResult GetList(ChatroomModel chatroom)
        {
            String message = CommonUtil.CheckFiled(chatroom, PATH, CheckMethod.GETLIST);
            if (null != message)
            {
                return (ListGagChatroomUserResult)RongJsonUtil.JsonStringToObj<ListGagChatroomUserResult>(message);
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("&chatroomId=").Append(HttpUtility.UrlEncode(chatroom.Id.ToString(), UTF8));
            String body = sb.ToString();
            if (body.IndexOf("&") == 0)
            {
                body = body.Substring(1, body.Length - 1);
            }
            String result = RongHttpClient.ExecutePost(appKey, appSecret, body,
                                                  rongCloud.ApiHostType.Type + "/chatroom/user/gag/list.json", "application/x-www-form-urlencoded");

            return (ListGagChatroomUserResult)RongJsonUtil.JsonStringToObj<ListGagChatroomUserResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.GETLIST, result));

        }

        /**
         * 移除禁言聊天室成员方法
         *
         * @param  chatroom:封禁的聊天室信息，其中聊天室 Id。（必传）,用户 Id。（必传支持多个最多20个）
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
            ChatroomMember[] members = chatroom.Members;
            foreach (var member in members)
            {
                sb.Append("&userId=").Append(HttpUtility.UrlEncode(member.Id, UTF8));
            }
            sb.Append("&chatroomId=").Append(HttpUtility.UrlEncode(chatroom.Id.ToString(), UTF8));
            String body = sb.ToString();
            if (body.IndexOf("&") == 0)
            {
                body = body.Substring(1, body.Length - 1);
            }

            String result = RongHttpClient.ExecutePost(appKey, appSecret, body,
                                          rongCloud.ApiHostType.Type + "/chatroom/user/gag/rollback.json", "application/x-www-form-urlencoded");

            return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.REMOVE, result));

        }
    }

}
