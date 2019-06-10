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

namespace io.rong.methods.messages.discussion
{

    /**
     * 发送讨论组消息方法
     *
     * docs : http://www.rongcloud.cn/docs/server.html#message_discussion_publish
     * @author RongCloud
     *
     */
    public class Discussion

    {

        private static readonly Encoding UTF8 = Encoding.UTF8;
        private static readonly String PATH = "message/discussion";
        private String appKey;
        private String appSecret;
        private RongCloud rongCloud;

        public string AppKey { get => appKey; set => appKey = value; }
        public string AppSecret { get => appSecret; set => appSecret = value; }
        internal RongCloud RongCloud { get => rongCloud; set => rongCloud = value; }

        public RongCloud getRongCloud()
        {
            return rongCloud;
        }

        public void setRongCloud(RongCloud rongCloud)
        {
            this.rongCloud = rongCloud;
        }
        public Discussion(String appKey, String appSecret)
        {
            this.appKey = appKey;
            this.appSecret = appSecret;

        }
        /**
         * 发送讨论组消息方法（以一个用户身份向讨论组发送消息，单条消息最大 128k，每秒钟最多发送 20 条消息.）
         *
         *
         * @param  message:发送消息内容，参考融云消息类型表.示例说明；如果 objectName 为自定义消息类型，该参数可自定义格式。（必传）
         *
         * @return ResponseResult
         * @throws Exception
         **/
        public ResponseResult Send(DiscussionMessage message)
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
                    sb.Append("&toDiscussionId=").Append(HttpUtility.UrlEncode(child, UTF8));
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

            if (0 == message.IsPersisted || message.IsPersisted != null)
            {
                sb.Append("&isPersisted=").Append(HttpUtility.UrlEncode(message.IsPersisted.ToString(), UTF8));
            }

            if (0 == message.IsCounted || message.IsCounted != null)
            {
                sb.Append("&isCounted=").Append(HttpUtility.UrlEncode(message.IsCounted.ToString(), UTF8));
            }

            if (0 == message.IsIncludeSender || message.IsIncludeSender != null)
            {
                sb.Append("&isIncludeSender=").Append(HttpUtility.UrlEncode(message.IsIncludeSender.ToString(), UTF8));
            }
            String body = sb.ToString();
            if (body.IndexOf("&") == 0)
            {
                body = body.Substring(1, body.Length - 1);
            }

            String result = RongHttpClient.ExecutePost(appKey, appSecret, body,
                                      rongCloud.ApiHostType.Type + "/message/discussion/publish.json", "application/x-www-form-urlencoded");

            return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.PUBLISH, result));
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
            //需要校验的字段
            String msgErr = CommonUtil.CheckFiled(message, PATH, CheckMethod.RECALL);
            if (null != msgErr)
            {
                return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(msgErr);
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("&conversationType=").Append(HttpUtility.UrlEncode("2", UTF8));
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
