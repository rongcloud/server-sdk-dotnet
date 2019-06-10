using io.rong.util;
using io.rong.methods.chatroom.block;
using io.rong.methods.chatroom.ban;
using io.rong.methods.chatroom.demotion;
using io.rong.methods.chatroom.distribute;
using io.rong.methods.chatroom.gag;
using io.rong.methods.chatroom.keepalive;
using io.rong.methods.chatroom.whitelist;
using io.rong.models;
using io.rong.models.response;
using io.rong.models.chatroom;
using io.rong.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace io.rong.methods.chatroom
{
    /**
 *
 * 聊天室服务
 * docs: "http://www.rongcloud.cn/docs/server.html#chatroom"
 *
 * */
    class Chatroom
    {

        private static readonly Encoding UTF8 = Encoding.UTF8;
        private static readonly String PATH = "chatroom";
        private String appKey;
        private String appSecret;
        public Block block;
        public Gag gag;
        public Ban ban;
        public Keepalive keepalive;
        public Demotion demotion;
        public Whitelist whiteList;
        public Distribute distribute;
        private RongCloud rongCloud;

        internal RongCloud RongCloud
        {
            get => rongCloud; set
            {
                rongCloud = value;
                gag.RongCloud = value;
                keepalive.RongCloud = value;
                demotion.RongCloud = value;
                whiteList.RongCloud = value;
                block.RongCloud = value;
                demotion.RongCloud = value;
                distribute.RongCloud = value;
                ban.RongCloud = value;
            }
        }

        public Chatroom(String appKey, String appSecret)
        {
            this.appKey = appKey;
            this.appSecret = appSecret;
            this.gag = new Gag(appKey, appSecret);
            this.keepalive = new Keepalive(appKey, appSecret);
            this.demotion = new Demotion(appKey, appSecret);
            this.whiteList = new Whitelist(appKey, appSecret);
            this.block = new Block(appKey, appSecret);
            this.distribute = new Distribute(appKey, appSecret);
            this.ban = new Ban(appKey, appSecret);

        }
        /**
         * 创建聊天室方法 
         * 
         * @param  chatrooms:chatroom.id,name（必传）
         *
         * @return ResponseResult
         **/
        public ResponseResult Create(ChatroomModel[] chatrooms)
        {
            if (chatrooms == null)
            {
                return new ResponseResult(1002, "Paramer 'chatrooms' is required");
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < chatrooms.Length; i++)
            {
                ChatroomModel chatroom = chatrooms[i];
                sb.Append("&chatroom[" + chatroom.Id + "]=").Append(HttpUtility.UrlEncode(chatroom.Name, UTF8));
            }

            String body = sb.ToString();
            if (body.IndexOf("&") == 0)
            {
                body = body.Substring(1, body.Length - 1);
            }

            String result = RongHttpClient.ExecutePost(appKey, appSecret, body,
                                                     rongCloud.ApiHostType.Type + "/chatroom/create.json", "application/x-www-form-urlencoded");

            return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.CREATE, result));

        }
        /**
         * 销毁聊天室方法
         *
         * @param  chatroom:要销毁的聊天室 Id。（必传）
         *
         * @return ResponseResult
         **/
        public ResponseResult Destroy(ChatroomModel chatroom)
        {
            if (chatroom == null)
            {
                return new ResponseResult(1002, "Paramer 'chatroomId' is required");
            }
            String message = CommonUtil.CheckFiled(chatroom, PATH, CheckMethod.DESTORY);
            if (null != message)
            {
                return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(message);
            }
            StringBuilder sb = new StringBuilder();

            sb.Append("&chatroomId=").Append(HttpUtility.UrlEncode(chatroom.Id, UTF8));

            String body = sb.ToString();
            if (body.IndexOf("&") == 0)
            {
                body = body.Substring(1, body.Length - 1);
            }
            String result = RongHttpClient.ExecutePost(appKey, appSecret, body,
                                             rongCloud.ApiHostType.Type + "/chatroom/destroy.json", "application/x-www-form-urlencoded");

            return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.DESTORY, result));
        }
        /**
         * 查询聊天室内用户方法
         *
         * @param  chatroom:聊天室.id,count,order（必传）
         *
         * @return ChatroomUserQueryResult
         **/
        public ChatroomUserQueryResult Get(ChatroomModel chatroom)
        {
            String message = CommonUtil.CheckFiled(chatroom, PATH, CheckMethod.GET);
            if (null != message)
            {
                return (ChatroomUserQueryResult)RongJsonUtil.JsonStringToObj<ChatroomUserQueryResult>(message);
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("&chatroomId=").Append(HttpUtility.UrlEncode(chatroom.Id.ToString(), UTF8));
            sb.Append("&count=").Append(HttpUtility.UrlEncode(chatroom.Count.ToString(), UTF8));
            sb.Append("&order=").Append(HttpUtility.UrlEncode(chatroom.Order.ToString(), UTF8));
            String body = sb.ToString();
            if (body.IndexOf("&") == 0)
            {
                body = body.Substring(1, body.Length - 1);
            }
            String result = RongHttpClient.ExecutePost(appKey, appSecret, body,
                                     rongCloud.ApiHostType.Type + "/chatroom/user/query.json", "application/x-www-form-urlencoded");

            return (ChatroomUserQueryResult)RongJsonUtil.JsonStringToObj<ChatroomUserQueryResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.GET, result));
        }
        /**
         * 查询用户是否存在聊天室
         *
         * @param  member:聊天室成员。（必传）
         *
         * @return ResponseResult
         **/
        public CheckChatRoomUserResult IsExist(ChatroomMember member)
        {
            String message = CommonUtil.CheckFiled(member, PATH, CheckMethod.ISEXIST);
            if (null != message)
            {
                return (CheckChatRoomUserResult)RongJsonUtil.JsonStringToObj<CheckChatRoomUserResult>(message);
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("&chatroomId=").Append(HttpUtility.UrlEncode(member.ChatroomId.ToString(), UTF8));
            sb.Append("&userId=").Append(HttpUtility.UrlEncode(member.Id.ToString(), UTF8));
            String body = sb.ToString();
            if (body.IndexOf("&") == 0)
            {
                body = body.Substring(1, body.Length - 1);
            }
            String result = RongHttpClient.ExecutePost(appKey, appSecret, body,
                             rongCloud.ApiHostType.Type + "/chatroom/user/exist.json", "application/x-www-form-urlencoded");

            return (CheckChatRoomUserResult)RongJsonUtil.JsonStringToObj<CheckChatRoomUserResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.ISEXIST, result));
        }
    }
}