using io.rong.models.response;
using io.rong.methods.chatroom;
using io.rong.methods.chatroom.gag;
using io.rong.models.chatroom;
using io.rong.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using io.rong.models.conversation;

namespace io.rong.example.chatroom
{
    public class GagExample

    {
        /**
         * 此处替换成您的appKey
         * */
        private static readonly String appKey = "appKey";
        /**
         * 此处替换成您的appSecret
         * */
        private static readonly String appSecret = "appSecret";
        /**
         * 自定义api地址
         * */
        private static readonly String api = "http://api.cn.ronghub.com";


        static void main(String[] args)
        {
            RongCloud rongCloud = RongCloud.GetInstance(appKey, appSecret);
            //自定义 api地址方式
            //RongCloud rongCloud = RongCloud.getInstance(appKey, appSecret,api);

            Gag gag = rongCloud.Chatroom.gag;

            /**
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/chatroom/gag.html#add
             * 添加禁言聊天室成员方法想（在 App 中如果不让某一用户在聊天室中发言时，可将此用户在聊天室中禁言，
             * 被禁言用户可以接收查看聊天室中用户聊天信息，但不能发送消息.）获取某用户的黑名单列表方法（每秒钟限 100 次）
             */

            ChatroomMember[] members = {
                new ChatroomMember() {
                    Id = "qawr34h"
                },
                new ChatroomMember(){ Id = "qawr35h"}
        };
            ChatroomModel chatroom = new ChatroomModel()
            {
                Id = "hjhf07kk",
                Members = members,
                Minute = 5
            };

            ResponseResult result = gag.Add(chatroom);
            Console.WriteLine("addGagUser:  " + result.ToString());

            /**
             *
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/chatroom/gag.html#remove
             * 查询被禁言聊天室成员方法
             */
            chatroom = new ChatroomModel()
            {
                Id = "hjhf07kk"
            };
            ListGagChatroomUserResult chatroomListGagUserResult = gag.GetList(chatroom);
            Console.WriteLine("ListGagUser:  " + chatroomListGagUserResult.ToString());

            /**
             *
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/chatroom/gag.html#getList
             *
             * 移除禁言聊天室成员
             */
            chatroom = new ChatroomModel()
            {
                Id = "hjhf07kk",
                Members = members
            };

            ResponseResult removeResult = gag.Remove(chatroom);
            Console.WriteLine("rollbackGagUser:  " + result.ToString());

            Console.ReadLine();
        }
    }
}
