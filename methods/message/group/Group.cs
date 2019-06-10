using io.rong.models;
using io.rong.models.response;
using System;
using System.Collections.Generic;
using System.Text;
using io.rong.models.message;
using io.rong.exception;
using io.rong.util;
using System.Web;
using io.rong.util;

namespace io.rong.methods.messages.group
{
    /**
     * 发送群组消息方法
     *
     * docs : http://www.rongcloud.cn/docs/server.html#message_group_publish
     * @author RongCloud
     *
     */
    public class Group

    {

        private static readonly Encoding UTF8 = Encoding.UTF8;
        private static readonly String PATH = "message/group";
        private static readonly String RECAL_PATH = "message/recall";
        private String appKey;
        private String appSecret;
        private RongCloud rongCloud;

        public string AppKey { get => appKey; set => appKey = value; }
        public string AppSecret { get => appSecret; set => appSecret = value; }
        internal RongCloud RongCloud { get => rongCloud; set => rongCloud = value; }

        public Group(String appKey, String appSecret)
        {
            this.appKey = appKey;
            this.appSecret = appSecret;

        }
        /**
         * 发送群组消息方法（以一个用户身份向群组发送消息，单条消息最大 128k.每秒钟最多发送 20 条消息，每次最多向 3 个群组发送，如：一次向 3 个群组发送消息，示为 3 条消息。）
         *
         * @param message
         *
         * @return ResponseResult
         * @throws Exception
         **/
        public ResponseResult Send(GroupMessage message)
        {

            String code = CommonUtil.CheckFiled(message, PATH, CheckMethod.PUBLISH);
            if (null != code)
            {
                return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(code);
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("&fromUserId=").Append(HttpUtility.UrlEncode(message.SenderId.ToString(), UTF8));

            for (int i = 0; i < message.TargetId.Length; i++)
            {
                String child = message.TargetId[i];
                if (null != child)
                {
                    sb.Append("&toGroupId=").Append(HttpUtility.UrlEncode(child, UTF8));
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

            if (0 != message.IsPersisted || message.IsPersisted != null)
            {
                sb.Append("&isPersisted=").Append(HttpUtility.UrlEncode(message.IsPersisted.ToString(), UTF8));
            }

            if (0 != message.IsCounted || message.IsCounted != null)
            {
                sb.Append("&isCounted=").Append(HttpUtility.UrlEncode(message.IsCounted.ToString(), UTF8));
            }

            if (0 != message.IsIncludeSender || message.IsIncludeSender != null)
            {
                sb.Append("&isIncludeSender=").Append(HttpUtility.UrlEncode(message.IsIncludeSender.ToString(), UTF8));
            }
            if (0 != message.ContentAvailable || message.ContentAvailable != null)
            {
                sb.Append("&contentAvailable=").Append(HttpUtility.UrlEncode(message.ContentAvailable.ToString(), UTF8));
            }
            String body = sb.ToString();
            if (body.IndexOf("&") == 0)
            {
                body = body.Substring(1, body.Length - 1);
            }
            String result = RongHttpClient.ExecutePost(appKey, appSecret, body,
                                          rongCloud.ApiHostType.Type + "/message/group/publish.json", "application/x-www-form-urlencoded");

            return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.PUBLISH, result));
        }

        /**
         * 发送群组@消息方法（以一个用户身份向群组发送消息，单条消息最大 128k.每秒钟最多发送 20 条消息，每次最多向 3 个群组发送，如：一次向 3 个群组发送消息，示为 3 条消息。）
         *
         * @param message
         *
         * @return ResponseResult
         * @throws Exception
         **/
        public ResponseResult SendMention(MentionMessage message)
        {

            String code = CommonUtil.CheckFiled(message, PATH, CheckMethod.PUBLISH);
            if (null != code)
            {
                return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(code);
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("&fromUserId=").Append(HttpUtility.UrlEncode(message.SenderId.ToString(), UTF8));
            String[] groupIds = message.TargetId;
            for (int i = 0; i < groupIds.Length; i++)
            {
                String child = groupIds[i];
                sb.Append("&toGroupId=").Append(HttpUtility.UrlEncode(child, UTF8));
            }

            sb.Append("&objectName=").Append(HttpUtility.UrlEncode(message.Content.Content.GetType(), UTF8));
            sb.Append("&content=").Append(HttpUtility.UrlEncode(message.Content.Content.ToString(), UTF8));

            if (message.PushContent != null)
            {
                sb.Append("&pushContent=").Append(HttpUtility.UrlEncode(message.PushContent.ToString(), UTF8));
            }

            if (message.PushContent != null)
            {
                sb.Append("&pushData=").Append(HttpUtility.UrlEncode(message.PushContent.ToString(), UTF8));
            }

            if (0 != message.IsPersisted || message.IsPersisted != null)
            {
                sb.Append("&isPersisted=").Append(HttpUtility.UrlEncode(message.IsPersisted.ToString(), UTF8));
            }

            if (0 != message.IsCounted || message.IsCounted != null)
            {
                sb.Append("&isCounted=").Append(HttpUtility.UrlEncode(message.IsCounted.ToString(), UTF8));
            }

            if (0 != message.IsIncludeSender || message.IsIncludeSender != null)
            {
                sb.Append("&isIncludeSender=").Append(HttpUtility.UrlEncode(message.IsIncludeSender.ToString(), UTF8));
            }

            sb.Append("&isMentioned=").Append(HttpUtility.UrlEncode("1", UTF8));

            if (0 != message.ContentAvailable || message.ContentAvailable != null)
            {
                sb.Append("&contentAvailable=").Append(HttpUtility.UrlEncode(message.ContentAvailable.ToString(), UTF8));
            }
            String body = sb.ToString();
            if (body.IndexOf("&") == 0)
            {
                body = body.Substring(1, body.Length - 1);
            }

            String result = RongHttpClient.ExecutePost(appKey, appSecret, body,
                                             rongCloud.ApiHostType.Type + "/message/group/publish.json", "application/x-www-form-urlencoded");

            return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.PUBLISH, result));
        }

        /**
         * 撤回群组消息。
         *
         * @param message
         *
         * @return ResponseResult
         * @throws Exception
         **/
        public Result Recall(RecallMessage message)
        {
            //需要校验的字段
            String errMsg = CommonUtil.CheckFiled(message, RECAL_PATH, CheckMethod.RECALL);
            if (null != errMsg)
            {
                return (Result)RongJsonUtil.JsonStringToObj<ResponseResult>(errMsg);
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("&conversationType=").Append(HttpUtility.UrlEncode("3", UTF8));
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
