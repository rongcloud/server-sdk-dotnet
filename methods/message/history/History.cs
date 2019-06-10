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

namespace io.rong.methods.messages.history
{
    /**
     * 消息历史记录服务
     *
     * docs : http://www.rongcloud.cn/docs/server.html#history_message
     * @author RongCloud
     *
     */
    public class History

    {
        private static readonly Encoding UTF8 = Encoding.UTF8;
        private static readonly String PATH = "message/history";
        private String appKey;
        private String appSecret;
        private RongCloud rongCloud;

      
        public History(String appKey, String appSecret)
        {
            this.appKey = appKey;
            this.appSecret = appSecret;

        }

        public string AppKey { get => appKey; set => appKey = value; }
        public string AppSecret { get => appSecret; set => appSecret = value; }
        internal RongCloud RongCloud { get => rongCloud; set => rongCloud = value; }

        /**
* 消息历史记录下载地址获取 方法消息历史记录下载地址获取方法。获取 APP 内指定某天某小时内的所有会话消息记录的下载地址。（目前支持二人会话、讨论组、群组、聊天室、客服、系统通知消息历史记录下载）
*
* @param  date:指定北京时间某天某小时，格式为2014010101,表示：2014年1月1日凌晨1点。（必传）
*
* @return HistoryMessageResult
* @throws Exception
**/
        public HistoryMessageResult Get(String date)
        {
            if (date == null)
            {
                return new HistoryMessageResult(1002, "", "", "Paramer 'date' is required");
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("&date=").Append(HttpUtility.UrlEncode(date.ToString(), UTF8));
            String body = sb.ToString();
            if (body.IndexOf("&") == 0)
            {
                body = body.Substring(1, body.Length - 1);
            }
            String result = RongHttpClient.ExecutePost(appKey, appSecret, body,
                                          rongCloud.ApiHostType.Type + "/message/history.json", "application/x-www-form-urlencoded");

            return (HistoryMessageResult)RongJsonUtil.JsonStringToObj<HistoryMessageResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.GET, result));
        }

        /**
         * 消息历史记录删除方法（删除 APP 内指定某天某小时内的所有会话消息记录。调用该接口返回成功后，date参数指定的某小时的消息记录文件将在随后的5-10分钟内被永久删除。）
         *
         * @param  date:指定北京时间某天某小时，格式为2014010101,表示：2014年1月1日凌晨1点。（必传）
         *
         * @return ResponseResult
         * @throws Exception
         **/
        public ResponseResult Remove(String date)
        {
            if (date == null)
            {
                return new ResponseResult(1002, "Paramer 'date' is required");
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("&date=").Append(HttpUtility.UrlEncode(date.ToString(), UTF8));
            String body = sb.ToString();
            if (body.IndexOf("&") == 0)
            {
                body = body.Substring(1, body.Length - 1);
            }
            String result = RongHttpClient.ExecutePost(appKey, appSecret, body,
                                              rongCloud.ApiHostType.Type + "/message/history/delete.json", "application/x-www-form-urlencoded");

            return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.REMOVE, result));

        }
    }
}
