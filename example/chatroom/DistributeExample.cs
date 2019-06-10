using io.rong.models.response;
using io.rong.methods.chatroom;
using io.rong.methods.chatroom.distribute;
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
    class DistributeExample
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

            Distribute distribute = rongCloud.chatroom.distribute;

            /**
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/chatroom/distribute.html#stop
             *
             * 聊天室消息停止分发
             *
             */
            ChatroomModel chatroomModel = new ChatroomModel()
            {
                Id = "d7ec7a8b8d8546c98b0973417209a548"
            };
            ResponseResult result = distribute.Stop(chatroomModel);

            Console.WriteLine("stopDistributionMessage:  " + result.ToString());

            /**
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/chatroom/distribute.html#resume
             *
             * 聊天室消息恢复分发方法（每秒钟限 100 次）
             */
            ResponseResult resumeResult = distribute.Resume(chatroomModel);
            Console.WriteLine("resumeDistributionMessage:  " + resumeResult.ToString());
            Console.ReadLine();
        }
    }
}
