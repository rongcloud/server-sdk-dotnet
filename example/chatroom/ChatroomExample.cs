using io.rong.methods.chatroom;
using io.rong.models.chatroom;
using io.rong.models.response;
using System;

namespace io.rong.example.chatroom
{
    class ChatroomExample
    {
        /**
         * 此处替换成您的appKey
         * */
        private static readonly String appKey = "n19jmcy59f1q9";
        /**
         * 此处替换成您的appSecret
         * */
        private static readonly String appSecret = "CuhqdZMeuLsKj";
        /**
         * 自定义api地址
         * */
        private static readonly String api = "http://api.cn.ronghub.com";


        static void Main(String[] args)
        {

            RongCloud rongCloud = RongCloud.GetInstance(appKey, appSecret);
            //自定义 api地址方式
            //RongCloud rongCloud = RongCloud.getInstance(appKey, appSecret,api);

            Chatroom chatroom = rongCloud.chatroom;

            /**
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/chatroom/chatroom.html#create
             *
             * 创建聊天室
             *
             * */
            ChatroomModel[] chatrooms = {
                new ChatroomModel(){ Id = "OIBbeKlkx", Name = "chatroomName1"},
                new ChatroomModel(){ Id = "chatroomId2", Name = "chatroomName2"}
        };
            ResponseResult result = chatroom.Create(chatrooms);

            Console.WriteLine("create:  " + result.ToString());

            /**
             *
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/chatroom/chatroom.html#destory
             * 销毁聊天室
             *
             * */
            ChatroomModel chatroomModel = new ChatroomModel()
            {
                Id = "chatroomId2"
            };

            //ResponseResult chatroomDestroyResult = chatroom.Destroy(chatroomModel);
            //Console.WriteLine("destroy:  " + chatroomDestroyResult.ToString());


            /**
             *
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/chatroom/chatroom.html#getMembers
             * 查询聊天室成员demo
             *
             * */

            chatroomModel = new ChatroomModel()
            {
                Id = "OIBbeKlkx",
                Count = 10,
                Order = 1
            };

            ChatroomUserQueryResult chatroomQueryUserResult = chatroom.Get(chatroomModel);
            Console.WriteLine("queryUser:  " + chatroomQueryUserResult.ToString());

            /**
             *
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/chatroom/chatroom.html#isExist
             * 查询聊天室成员是否存在
             *
             * */
            ChatroomMember member = new ChatroomMember()
            {
                Id = "e5ZnCtyfE",
                ChatroomId = "OIBbeKlkx"
            };

            CheckChatRoomUserResult checkMemberResult = chatroom.IsExist(member);
            Console.WriteLine("checkChatroomUserResult:  " + checkMemberResult.IsInChrm);
            Console.ReadLine();

        }

    }
}
