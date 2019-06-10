using io.rong.models.response;
using io.rong.methods.chatroom;
using io.rong.methods.chatroom.ban;
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
    class BanExample
    {
        /**
         * 此处替换成您的appKey
         * */
        private static readonly String appKey = "kj7swf8okyqt2";
        /**
         * 此处替换成您的appSecret
         * */
        private static readonly String appSecret = "mFe3U1UClx4gx";
        /**
         * 自定义api地址C:\Users\rc\Downloads\server-sdk-dotnet-master\example\chatroom\BanExample.cs
         * */
        private static readonly String api = "http://api.cn.ronghub.com";

        static void Main(String[] args)
        {
            RongCloud rongCloud = RongCloud.GetInstance(appKey, appSecret);
            //自定义 api地址方式
            //RongCloud rongCloud = RongCloud.getInstance(appKey, appSecret,api);

            Ban ban = rongCloud.chatroom.ban;

            /**
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/chatroom/ban.html#add
             * 添加聊天室全局禁言
             * */
            ChatroomMember[] members = {
                new ChatroomMember(){
                Id = "qawr34h"
                }, new ChatroomMember() {
                    Id = "qawr35h"
                } };
            ChatroomModel chatroom = new ChatroomModel()
            {
                Members = members,
                Minute = 5
            };

            ResponseResult result = ban.Add(chatroom);
            Console.WriteLine("addGagUser:  " + result.ToString());

            /**
             *
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/chatroom/ban.html#getList
             * 获取聊天时全局禁言列表
             */

            ListGagChatroomUserResult chatroomListGagUserResult = ban.GetList();
            Console.WriteLine("ListGagUser:  " + chatroomListGagUserResult.ToString());

            /**
             *
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/chatroom/ban.html#remove
             * 删除聊天时全局禁言
             */
            chatroom = new ChatroomModel()
            {
                Members = members
            };
            ResponseResult removeResult = ban.Remove(chatroom);
            Console.WriteLine("removeBanUser:  " + removeResult.ToString());
            Console.ReadLine();
        }
    }
}
