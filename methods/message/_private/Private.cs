using io.rong.models;
using io.rong.models.message;
using io.rong.models.response;
using io.rong.util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace io.rong.methods.messages._private
{

    /**
     * 发送单聊消息方法
     * docs : http://www.rongcloud.cn/docs/server.html#message_private_publish
     */
    public class Private

    {
        private static readonly Encoding UTF8 = Encoding.UTF8;
        private static readonly String PATH = "message/_private";
        private static readonly String RECAL_PATH = "message/recall";
        private String appKey;
        private String appSecret;
        private RongCloud rongCloud;

        public string AppKey { get => appKey; set => appKey = value; }
        public string AppSecret { get => appSecret; set => appSecret = value; }
        internal RongCloud RongCloud { get => rongCloud; set => rongCloud = value; }

        public Private(String appKey, String appSecret)
        {
            this.appKey = appKey;
            this.appSecret = appSecret;

        }

        /**
         * 发送单聊消息方法（一个用户向另外一个用户发送消息，单条消息最大 128k。每分钟最多发送 6000 条信息，每次发送用户上限为 1000 人，如：一次发送 1000 人时，示为 1000 条消息。） 
         * 
         * @param message 单聊消息
         *
         * @return ResponseResult
         * @throws Exception
         **/
        public ResponseResult Send(PrivateMessage message)
        {
            if (null == message)
            {
                return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>("Paramer 'message' is required");
            }
            String errMsg = CommonUtil.CheckFiled(message, PATH, CheckMethod.SEND);
            if (null != errMsg)
            {
                return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(errMsg);
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("&fromUserId=").Append(HttpUtility.UrlEncode(message.SenderId.ToString(), UTF8));

            for (int i = 0; i < message.TargetId.Length; i++)
            {
                String child = message.TargetId[i];
                if (null != child)
                {
                    sb.Append("&toUserId=").Append(HttpUtility.UrlEncode(child, UTF8));
                }
            }

            sb.Append("&objectName=").Append(HttpUtility.UrlEncode(message.Content.GetType(), UTF8));
            sb.Append("&content=").Append(HttpUtility.UrlEncode(message.Content.ToString(), UTF8));

            if (message.PushContent != null)
            {
                sb.Append("&pushContent=").Append(HttpUtility.UrlEncode(message.PushContent.ToString(), UTF8));
            }

            if (message.PushData != null)
            {
                sb.Append("&pushData=").Append(HttpUtility.UrlEncode(message.PushData.ToString(), UTF8));
            }

            if (message.Count != null)
            {
                sb.Append("&count=").Append(HttpUtility.UrlEncode(message.Count.ToString(), UTF8));
            }

            if (0 != message.VerifyBlacklist)
            {
                sb.Append("&verifyBlacklist=").Append(HttpUtility.UrlEncode(message.VerifyBlacklist.ToString(), UTF8));
            }

            if (0 != message.IsPersisted)
            {
                sb.Append("&isPersisted=").Append(HttpUtility.UrlEncode(message.IsPersisted.ToString(), UTF8));
            }

            if (0 != message.IsCounted)
            {
                sb.Append("&isCounted=").Append(HttpUtility.UrlEncode(message.IsCounted.ToString(), UTF8));
            }

            if (0 != message.IsIncludeSender)
            {
                sb.Append("&isIncludeSender=").Append(HttpUtility.UrlEncode(message.IsIncludeSender.ToString(), UTF8));
            }
            String body = sb.ToString();
            if (body.IndexOf("&") == 0)
            {
                body = body.Substring(1, body.Length - 1);
            }

            String result = RongHttpClient.ExecutePost(appKey, appSecret, body,
                        rongCloud.ApiHostType.Type + "/message/private/publish.json", "application/x-www-form-urlencoded");

            return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.PUBLISH, result));
        }

        /**
         * 发送单聊模板消息方法（一个用户向多个用户发送不同消息内容，单条消息最大 128k。每分钟最多发送 6000 条信息，每次发送用户上限为 1000 人。） 
         * 
         * @param  message:单聊模版消息。
         *
         * @return ResponseResult
         * @throws Exception
         **/
        public ResponseResult SendTemplate(TemplateMessage message)
        {

            String errMsg = CommonUtil.CheckFiled(message, PATH, CheckMethod.SENDTEMPLATE);
            if (null != errMsg)
            {
                return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(errMsg);
            }

            Templates templateMessage = new Templates();

            List<String> toUserIds = new List<String>();
            List<Dictionary<String, String>> values = new List<Dictionary<String, String>>();
            List<String> push = new List<String>();

            foreach (var vo in message.Content)
            {
                toUserIds.Add(vo.Key);
                values.Add(vo.Value.Data);
                push.Add(vo.Value.Push);
            }
            templateMessage.FromUserId = message.SenderId;
            templateMessage.ToUserId = toUserIds.ToArray();
            templateMessage.ObjectName = message.ObjectName;
            templateMessage.Content = message.Template.ToString();
            templateMessage.Values = values;
            templateMessage.PushContent = push.ToArray();
            templateMessage.PushData = push.ToArray();
            templateMessage.VerifyBlacklist = message.VerifyBlacklist;
            templateMessage.ContentAvailable = message.ContentAvailable;

            String result = RongHttpClient.ExecutePost(appKey, appSecret, templateMessage.ToString(),
                                rongCloud.ApiHostType.Type + "/message/private/publish_template.json", "application/json");

            return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.PUBLISHTEMPLATE, result));
        }

        /**
         * 设置用户某会话接收新消息时是否进行消息提醒。
         *
         * @param message
         *
         * @return ResponseResult
         * @throws Exception
         **/
        public Result Recall(RecallMessage message)
        {

            String errMsg = CommonUtil.CheckFiled(message, RECAL_PATH, CheckMethod.RECALL);
            if (null != errMsg)
            {
                return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(errMsg);
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("&conversationType=").Append(HttpUtility.UrlEncode("1", UTF8));
            sb.Append("&fromUserId=").Append(HttpUtility.UrlEncode(message.SenderId.ToString(), UTF8));
            sb.Append("&targetId=").Append(HttpUtility.UrlEncode(message.TargetId.ToString(), UTF8));
            sb.Append("&messageUID=").Append(HttpUtility.UrlEncode(message.UId.ToString(), UTF8));
            sb.Append("&sentTime=").Append(HttpUtility.UrlEncode(message.SentTime.ToString(), UTF8));
            String body = sb.ToString();
            if (body.IndexOf("&") == 0)
            {
                body = body.Substring(1, body.Length - 1);
            }

            String result = RongHttpClient.ExecutePost(appKey, appSecret, body,
                                rongCloud.ApiHostType.Type + "/message/recall.json", "application/x-www-form-urlencoded");

            return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.RECALL, result));
        }
    }

}