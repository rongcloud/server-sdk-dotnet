using io.rong.models.response;
using io.rong.methods.chatroom;
using io.rong.methods.chatroom.demotion;
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
    class DemotionExample
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

            Demotion demotion = rongCloud.chatroom.demotion;

            /**
             *
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/chatroom/demotion.html#add
             * 添加应用内聊天室降级消息
             *
             * */
            String[] messageType = { "RC:VcMsg", "RC:ImgTextMsg", "RC:ImgMsg" };
            ResponseResult addResult = demotion.Add(messageType);
            Console.WriteLine("add demotion:  " + addResult.ToString());

            /**
             *
             *API 文档: http://www.rongcloud.cn/docs/server_sdk_api/chatroom/demotion.html#remove
             * 移除应用内聊天室降级消息
             *
             * */
            ResponseResult removeResult = demotion.Remove(messageType);
            Console.WriteLine("remove demotion:  " + removeResult.ToString());


            /**
             *
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/chatroom/demotion.html#getList
             * 添加聊天室消息优先级demo
             *
             * */
            ChatroomDemotionMsgResult demotionMsgResult = demotion.GetList();
            Console.WriteLine("get demotion:  " + demotionMsgResult.ToString());

            Console.ReadLine();

        }
    }
}
