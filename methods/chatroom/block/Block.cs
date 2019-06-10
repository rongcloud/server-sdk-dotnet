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

namespace io.rong.methods.chatroom.block
{
    /**
     *
     * 聊天室封禁服务
     * docs: "http://www.rongcloud.cn/docs/server.html#chatroom_user_block"
     *
     * */
    class Block
    {
        private static readonly Encoding UTF8 = Encoding.UTF8;
        private static readonly String PATH = "chatroom/block";
        private String appKey;
        private String appSecret;
        private RongCloud rongCloud;

        public Block(String appKey, String appSecret)
        {
            this.appKey = appKey;
            this.appSecret = appSecret;

        }

        public string AppKey { get => appKey; set => appKey = value; }
        public string AppSecret { get => appSecret; set => appSecret = value; }
        internal RongCloud RongCloud { get => rongCloud; set => rongCloud = value; }

        /**
* 添加封禁聊天室成员方法
*
* @param  chatroom:聊天室信息，memberIds（必传支持多个最多20个）,minute:封禁时长，以分钟为单位，最大值为43200分钟。（必传）
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
                           rongCloud.ApiHostType.Type + "/chatroom/user/block/add.json", "application/x-www-form-urlencoded");

            return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.ADD, result));
        }

        /**
         * 查询被封禁聊天室成员方法
         *
         * @param  chatroomId:聊天室 Id。（必传）
         *
         * @return ListBlockChatroomUserResult
         **/
        public ListBlockChatroomUserResult GetList(String chatroomId)
        {
            String message = CommonUtil.CheckParam("id", chatroomId, PATH, CheckMethod.GETLIST);
            if (null != message)
            {
                return (ListBlockChatroomUserResult)RongJsonUtil.JsonStringToObj<ListBlockChatroomUserResult>(message);
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("&chatroomId=").Append(HttpUtility.UrlEncode(chatroomId.ToString(), UTF8));
            String body = sb.ToString();
            if (body.IndexOf("&") == 0)
            {
                body = body.Substring(1, body.Length - 1);
            }
            String result = RongHttpClient.ExecutePost(appKey, appSecret, body,
                              rongCloud.ApiHostType.Type + "/chatroom/user/block/list.json", "application/x-www-form-urlencoded");

            return (ListBlockChatroomUserResult)RongJsonUtil.JsonStringToObj<ListBlockChatroomUserResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.GETLIST, result));
        }

        /**
         * 移除封禁聊天室成员方法
         *
         * @param  chatroom: 封禁的聊天室信息 其中聊天室 Id。（必传）,用户 Id。（必传）
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
                                 rongCloud.ApiHostType.Type + "/chatroom/user/block/rollback.json", "application/x-www-form-urlencoded");

            return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.REMOVE, result));
        }
    }
}
