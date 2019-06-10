using io.rong.methods.user.blacklist;
using io.rong.models;
using io.rong.models.response;
using io.rong.models.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using io.rong.messages;
using io.rong.models.message;
using io.rong.methods.messages._private;
using System.Text.RegularExpressions;
using io.rong.methods.messages.group;
using io.rong;
using io.rong.methods.messages.chatroom;
using io.rong.methods.messages.discussion;
using io.rong.methods.messages.history;
using System.IO;
using Newtonsoft.Json;
using io.rong.methods.messages.system;

namespace io.rong.example.messages
{
    /**
     * 消息发送示例
     *
     */
    public class MessageExample
    {
        /**
         * 此处替换成您的appKey
         * */
        private static readonly String appKey = "n19jmcy59f1q9";
        /**
         * 此处替换成您的appSecret
         * */
        private static readonly String appSecret = "CuhqdZMeuLsKj";

        private static readonly TxtMessage txtMessage = new TxtMessage(".NET hello", "helloExtra");
        private static readonly VoiceMessage voiceMessage = new VoiceMessage(".NET hello", "helloExtra", 20L);
        /**
         * 自定义api地址
         * */
        //private static readonly String api = "http://api.cn.ronghub.com";

        static void Main(String[] args)
        {

            RongCloud rongCloud = RongCloud.GetInstance(appKey, appSecret);
            //自定义 api 地址方式
            //RongCloud rongCloud = RongCloud.getInstance(appKey, appSecret,api);

            Private Private = rongCloud.message.msgPrivate;
            // TODO
            MsgSystem system = rongCloud.message.system;
            methods.messages.group.Group group = rongCloud.message.group;
            Chatroom chatroom = rongCloud.message.chatroom;
            Discussion discussion = rongCloud.message.discussion;
            History history = rongCloud.message.history;

            /**
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/message/system.html#send
             *
             * 发送系统消息
             *
             */
            String[] targetIds = { "uPj70HUrRSUk-ixtt7iIGc" };
            SystemMessage systemMessage = new SystemMessage()
            {
                SenderId = "Vu-oC0_LQ6kgPqltm_zYtI",
                TargetId = targetIds,
                ObjectName = txtMessage.GetType(),
                Content = txtMessage,
                PushContent = ".NET this is a push system",
                PushData = "{'pushData':'.NET hello'}",
                IsPersisted = 0,
                IsCounted = 0,
                ContentAvailable = 0
            };

            ResponseResult result = rongCloud.message.system.Send(systemMessage);
            Console.WriteLine("send system message:  " + result.ToString());

            /**
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/message/system.html#sendTemplate
             *
             * 发送系统模板消息方法
             *
             */
            StreamReader file = null;
            try
            {
                file = System.IO.File.OpenText("jsonsource/message/TemplateMessage.json");
                TemplateMessage template = JsonConvert.DeserializeObject<TemplateMessage>(file.ReadToEnd());
                ResponseResult messagePublishTemplateResult = system.SendTemplate(template);

                Console.WriteLine("send systemTemplate message:  " + messagePublishTemplateResult.ToString());

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                file.Close();
            }


            /**
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/message/system.html#sendTemplate
             *
             * 发送系统模板消息方法
             *
             */
            BroadcastMessage message = new BroadcastMessage()
            {
                SenderId = "Vu-oC0_LQ6kgPqltm_zYtI",
                ObjectName = txtMessage.GetType(),
                Content = txtMessage,
                Os = "Android"
            };

            ResponseResult broadcastResult = rongCloud.message.system.Broadcast(message);
            Console.WriteLine("send broadcast:  " + broadcastResult.ToString());


            /**
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/message/private.html#send
             *
             * 发送单聊消息
             * */
            PrivateMessage privateMessage = new PrivateMessage()
            {
                SenderId = "Vu-oC0_LQ6kgPqltm_zYtI",
                TargetId = targetIds,
                ObjectName = txtMessage.GetType(),
                Content = txtMessage,
                PushContent = ".NET this is a push private",
                PushData = "{\"pushData\":\".NET hello\"}",
                VerifyBlacklist = 0,
                IsPersisted = 0,
                IsCounted = 0,
                ContentAvailable = 0,
                IsIncludeSender = 0
            };

            ResponseResult privateResult = Private.Send(privateMessage);
            Console.WriteLine("send private message:  " + privateResult.ToString());

             /**
              * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/message/private.html#sendTemplate
              *
              * 发送单聊模板消息方法
              */
            try
            {
                file = System.IO.File.OpenText("jsonsource/message/TemplateMessage.json");
                TemplateMessage template = JsonConvert.DeserializeObject<TemplateMessage>(file.ReadToEnd());
                ResponseResult messagePublishTemplateResult = Private.SendTemplate(template);

                Console.WriteLine("send privateTemplate message:  " + messagePublishTemplateResult.ToString());

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                file.Close();
            }
            /**
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/message/private.html#recall
             *
             * 撤回单聊消息
             * */
            RecallMessage recallMessage = new RecallMessage()
            {
                SenderId = "0fn8TiuHTUgjrZ1QJ8o50M",
                TargetId = "qHPBAoUS6DmEBtJH72RSDi",
                UId = "5H6P-CGC6-44QR-VB3R",
                SentTime = "1519444243981"
            };

            ResponseResult recallPrivateResult = (ResponseResult)Private.Recall(recallMessage);
            Console.WriteLine("recall private:  " + recallPrivateResult.ToString());

            /**
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/message/group.html#send
             *
             * 群组消息
             * */
            GroupMessage groupMessage = new GroupMessage()
            {
                SenderId = "Vu-oC0_LQ6kgPqltm_zYtI",
                TargetId = new string[]{ "STRe0shISpQlSOBvek1FfU" },
                ObjectName = txtMessage.GetType(),
                Content = txtMessage,
                PushContent = "this is a push",
                PushData = "{\"pushData\":\"hello\"}",
                IsPersisted = 0,
                IsCounted = 0,
                IsIncludeSender = 0,
                ContentAvailable = 0
            };

            ResponseResult groupResult = group.Send(groupMessage);

            Console.WriteLine("send Group message:  " + groupResult.ToString());

            /**
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/message/group.html#recall
             *
             * 群组撤回消息
             * */
            recallMessage = new RecallMessage()
            {
                SenderId = "sea9901",
                TargetId = "markoiwm",
                UId = "5GSB-RPM1-KP8H-9JHF",
                SentTime = "1507778882124"
            };

            ResponseResult recallMessageResult = (ResponseResult)group.Recall(recallMessage);

            Console.WriteLine("send recall group message:  " + recallMessageResult.ToString());

            /**
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/message/group.html#sendMention
             *
             * 群组@消息
             * */
            //要@的人
            String[] mentionIds = { "uPj70HUrRSUk-ixtt7iIGc", "Vu-oC0_LQ6kgPqltm_zYtI" };

            MentionedInfo mentionedInfo = new MentionedInfo(1, mentionIds, "");
            //@内容
            MentionMessageContent content = new MentionMessageContent(txtMessage, mentionedInfo);

            MentionMessage mentionMessage = new MentionMessage()
            {
                SenderId = "Vu-oC0_LQ6kgPqltm_zYtI",
                TargetId = new string[] { "STRe0shISpQlSOBvek1FfU" },
                ObjectName = txtMessage.GetType(),
                Content = content,
                PushContent = "this is a push",
                PushData = "{\"pushData\":\"hello\"}",
                IsPersisted = 0,
                IsCounted = 0,
                IsIncludeSender = 0,
                ContentAvailable = 0
            };
            ResponseResult mentionResult = rongCloud.message.group.SendMention(mentionMessage);

            Console.WriteLine("group mention result:  " + mentionResult.ToString());

            /**
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/message/discussion.html#send
             *
             * 发送讨论组消息
             * */
            String[] discussionIds = { "lijhGk87", "lijhGk88" };
            DiscussionMessage discussionMessage = new DiscussionMessage()
            {
                SenderId = "JuikH78ko",
                TargetId = discussionIds,
                ObjectName = txtMessage.GetType(),
                Content = txtMessage,
                PushContent = "this is a push",
                PushData = "{\"pushData\":\"hello\"}",
                IsPersisted = 0,
                IsCounted = 0,
                IsIncludeSender = 0,
                ContentAvailable = 0
            };

            ResponseResult discussionResult = discussion.Send(discussionMessage);

            Console.WriteLine("send discussion message:  " + discussionResult.ToString());

            /**
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/message/discussion.html#recall
             *
             * 撤回讨论组消息
             * */
            recallMessage = new RecallMessage()
            {
                SenderId = "sea9901",
                TargetId = "IXQhMs3ny",
                UId = "5GSB-RPM1-KP8H-9JHF",
                SentTime = "1519444243981"
            };
            ResponseResult recallDiscussionResult = (ResponseResult)discussion.Recall(recallMessage);

            Console.WriteLine("recall discussion message:  " + recallDiscussionResult.ToString());


            /**
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/message/chatroom.html#send
             *
             * 聊天室消息
             * */

            String[] chatroomIds = { "OIBbeKlkx" };

            CustomTxtMessage ctm = new CustomTxtMessage("hello world");
            ChatroomMessage chatroomMessage = new ChatroomMessage()
            {
                SenderId = "aP9uvganV",
                TargetId = chatroomIds,
                Content = ctm,
                ObjectName = ctm.GetType()
            };

            ResponseResult chatroomResult = chatroom.Send(chatroomMessage);
            Console.WriteLine("send chatroom message:  " + chatroomResult.ToString());


            /**
             *
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/message/chatroom.html#broadcast
             *
             * 聊天室广播消息
             *
             * 此功能需开通专有服务: http://www.rongcloud.cn/deployment#overseas-cloud
             *
             * */
            chatroomMessage = new ChatroomMessage()
            {
                SenderId = "aP9uvganV",
                Content = txtMessage,
                ObjectName = txtMessage.GetType()
            };


            ResponseResult chatroomBroadcastresult = chatroom.Broadcast(chatroomMessage);
            Console.WriteLine("send chatroom broadcast message:  " + chatroomBroadcastresult.ToString());


            /**
             *
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/message/history.html#get
             *
             * 获取历史消息日志文件
             *
             * */

            HistoryMessageResult historyMessageResult = history.Get("2019011711");
            Console.WriteLine("get history  message:  " + historyMessageResult.ToString());

            /**
             *
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/message/history.html#get
             *
             * 删除历史消息日志文件
             *
             * */
            ResponseResult removeHistoryMessageResult = history.Remove("2018030210");
            Console.WriteLine("remove history  message:  " + removeHistoryMessageResult.ToString());
            Console.ReadLine();

        }
    }
}
