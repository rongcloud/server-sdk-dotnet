using io.rong.models.response;
using io.rong.methods.chatroom;
using io.rong.methods.chatroom.whitelist;
using io.rong.models.chatroom;
using io.rong.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using io.rong.models.conversation;

namespace io.rong.example.chatroom.whitelist
{
    class UserExample
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
         * 自定义api地址
         * */
        private static readonly String api = "http://api.cn.ronghub.com";

        static void main(String[] args)
        {
            RongCloud rongCloud = RongCloud.GetInstance(appKey, appSecret);
            //自定义 api地址方式
            //RongCloud rongCloud = RongCloud.getInstance(appKey, appSecret,api);

            Whitelist whitelist = rongCloud.chatroom.whiteList;

            /**
             * API: 文档http://www.rongcloud.cn/docs/server_sdk_api/chatroom/whitelist/user.html#add
             * 添加聊天室用户白名单
             * */
            ChatroomMember[] members = {
                new ChatroomMember(){ Id = "qawr34h"},new ChatroomMember(){ Id = "qawr35h"}
        };
            ChatroomModel chatroom = new ChatroomModel()
            {
                Id = "d7ec7a8b8d8546c98b0973417209a548",
                Members = members
            };

            ResponseResult addResult = whitelist.User.Add(chatroom);
            Console.WriteLine("add whitelist:  " + addResult.ToString());

            /**
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/chatroom/whitelist/user.html#getList
             * 获取聊天室用户白名单
             * */

            WhiteListResult getResult = whitelist.User.GetList(chatroom);
            Console.WriteLine("get whitelist:  " + getResult.ToString());


            /**
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/chatroom/whitelist/user.html#remove
             * 删除聊天室用户白名单
             * */

            ResponseResult removeResult = whitelist.User.Remove(chatroom);
            Console.WriteLine("remove whitelist:  " + removeResult.ToString());

            Console.ReadLine();
        }
    }
}
