using io.rong.util;
using io.rong.models;
using io.rong.models.response;
using io.rong.models.push;
using io.rong.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace io.rong.methods.user.onlineStatus
{
    public class OnlineStatus

    {
        private static readonly Encoding UTF8 = Encoding.UTF8;
        private static readonly String PATH = "user/online-status";
        private String appKey;
        private String appSecret;
        private RongCloud rongCloud;

        public RongCloud RongCloud
        {
            get { return this.rongCloud; }
            set { this.rongCloud = value; }
        }

        public RongCloud getRongCloud()
        {
            return rongCloud;
        }

        public OnlineStatus(String appKey, String appSecret)
        {
            this.appKey = appKey;
            this.appSecret = appSecret;

        }
        /**
         * 检查用户在线状态 方法（每秒钟限100次）
         * 请不要频繁循环调用此接口，而是选择合适的频率和时机调用，此接口设置了一定的频率限制。
         *
         * url /user/checkOnline
         * docs http://www.rongcloud.cn/docs/server.html#user_check_online
         *
         * @param  user:用户 id(必传)
         *
         * @return CheckOnlineResult
         **/
        public CheckOnlineResult Check(UserModel user)
        {
            //参数校验
            String message = CommonUtil.CheckFiled(user, PATH, CheckMethod.CHECK);
            if (null != message)
            {
                return (CheckOnlineResult)RongJsonUtil.JsonStringToObj<CheckOnlineResult>(message);
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("&userId=").Append(HttpUtility.UrlEncode(user.id.ToString(), UTF8));
            String body = sb.ToString();
            if (body.IndexOf("&") == 0)
            {
                body = body.Substring(1, body.Length);
            }

            String result = RongHttpClient.ExecutePost(appKey, appSecret, body,
                    RongCloud.ApiHostType.Type + "/user/checkOnline.json", "application/x-www-form-urlencoded");

            return (CheckOnlineResult)RongJsonUtil.JsonStringToObj<CheckOnlineResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.CHECK, result));

        }
    }
}
