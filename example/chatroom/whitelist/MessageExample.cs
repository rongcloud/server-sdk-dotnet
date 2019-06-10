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
    public class MessageExample

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

        static void Main(String[] args)
        {
            RongCloud rongCloud = RongCloud.GetInstance(appKey, appSecret);
            //自定义 api地址方式
            //RongCloud rongCloud = RongCloud.getInstance(appKey, appSecret,api);

            Whitelist whitelist = rongCloud.Chatroom.whiteList;
            String[] messageType = { "RC:VcMsg", "RC:ImgTextMsg", "RC:ImgMsg" };

            /**
             * API: 文档http://www.rongcloud.cn/docs/server_sdk_api/chatroom/whitelist/message.html#add
             * 添加聊天室全局禁言
             * */

            ResponseResult addResult = whitelist.Message.Add(messageType);
            Console.WriteLine("add whitelist:  " + addResult.ToString());
            /**
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/chatroom/whitelist/message.html#getList
             * 添加聊天室全局禁言
             * */

            ChatroomWhitelistMsgResult getResult = whitelist.Message.GetList();
            Console.WriteLine("get whitelist:  " + getResult.ToString());

            /**
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/chatroom/whitelist/message.html#remove
             * 添加聊天室全局禁言
             * */

            ResponseResult removeResult = whitelist.Message.Remove(messageType);
            Console.WriteLine("remove whitelist:  " + addResult.ToString());

            Console.ReadLine();
        }
    }
}
