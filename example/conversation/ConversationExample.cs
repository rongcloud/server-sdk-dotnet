using io.rong.methods.conversation;
using io.rong.models.conversation;
using io.rong.models.response;
using io.rong.util;
using System;

namespace io.rong.example.conversation
{
    /**
     *
     * 会话示例
     * @author RongCloud
     *
     */
    class ConversationExample
    {
        /**
         * 此处替换成您的appKey
         * */
        private static readonly String appKey = "pwe86ga5pwrj6";
        /**
         * 此处替换成您的appSecret
         * */
        private static readonly String appSecret = "rb8fWki1mJcK";
        /**
         * 自定义api地址
         * */
        private static readonly String api = "http://api.cn.ronghub.com";

        static void Main(String[] args)
        {

            RongCloud rongCloud = RongCloud.GetInstance(appKey, appSecret);
            //自定义 api 地址方式
            // RongCloud rongCloud = RongCloud.getInstance(appKey, appSecret,api);

            Conversation Conversation = rongCloud.conversation;

            ConversationModel conversation = new ConversationModel()
            {
                Type = CodeUtil.ConversationType.PRIVATE.Name,
                UserId = "uPj70HUrRSUk-ixtt7iIGc",
                TargetId = "Vu-oC0_LQ6kgPqltm_zYtI"
            };

            /**
             *
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/conversation/conversation.html#mute
             * 设置消息免打扰
             *
             */
            ResponseResult muteConversationResult = Conversation.Mute(conversation);

            Console.WriteLine("muteConversationResult:  " + muteConversationResult.ToString());

            /**
             *
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/conversation/conversation.html#unmute
             * 解除消息免打扰
             *
             * */
            ResponseResult unMuteConversationResult = Conversation.UnMute(conversation);

            Console.WriteLine("unMuteConversationResult:  " + unMuteConversationResult.ToString());
            Console.ReadLine();
        }
    }
}
