using io.rong.util;
using io.rong;
using io.rong.models;
using io.rong.models.response;
using io.rong.models.push;
using io.rong.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

/**
 *
 * 用户黑名单服务
 * docs: "http://www.rongcloud.cn/docs/server.html#black"
 *
 * @author RongCloud
 * @version
 * */
namespace io.rong.methods.user.blacklist
{
    public class Blacklist

    {
        private static readonly Encoding UTF8 = Encoding.UTF8;
        private static readonly String PATH = "user/blacklist";
        private String appKey;
        private String appSecret;
        private RongCloud rongCloud;

        public RongCloud RongCloud
        {
            get { return this.rongCloud; }
            set { this.rongCloud = value; }
        }
        public Blacklist(String appKey, String appSecret)
        {
            this.appKey = appKey;
            this.appSecret = appSecret;

        }

        /**
         * 添加用户到黑名单方法（每秒钟限 100 次）
         *
         * @param  user:用户 Id,blacklist（必传）
         *
         * @return ResponseResult
         **/
        public Result Add(UserModel user)
        {

            String message = CommonUtil.CheckFiled(user, PATH, CheckMethod.ADD);
            if (null != message)
            {
                return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(message);
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("&userId=").Append(HttpUtility.UrlEncode(user.Id.ToString(), UTF8));
            foreach (UserModel blackUser in user.GetBlacklist())
            {
                sb.Append("&blackUserId=").Append(HttpUtility.UrlEncode(blackUser.Id.ToString(), UTF8));
            }
            String body = sb.ToString();
            if (body.IndexOf("&") == 0)
            {
                body = body.Substring(1, body.Length - 1);
            }

            String result = RongHttpClient.ExecutePost(appKey, appSecret, body,
                RongCloud.ApiHostType.Type + "/user/blacklist/add.json", "application/x-www-form-urlencoded");

            return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.ADD, result));

        }

        /**
         * 获取某用户的黑名单列表方法（每秒钟限 100 次）
         *
         * @param  user:用户 Id。（必传）
         *
         * @return QueryBlacklistUserResult
         **/
        public BlackListResult GetList(UserModel user)
        {
            String message = CommonUtil.CheckFiled(user, PATH, CheckMethod.GETLIST);
            if (null != message)
            {
                return (BlackListResult)RongJsonUtil.JsonStringToObj<BlackListResult>(message);
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("&userId=").Append(HttpUtility.UrlEncode(user.Id.ToString(), UTF8));
            String body = sb.ToString();
            if (body.IndexOf("&") == 0)
            {
                body = body.Substring(1, body.Length - 1);
            }

            String result = RongHttpClient.ExecutePost(appKey, appSecret, body,
                RongCloud.ApiHostType.Type + "/user/blacklist/query.json", "application/x-www-form-urlencoded");

            return (BlackListResult)RongJsonUtil.JsonStringToObj<BlackListResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.GETLIST, result));
        }

        /**
         * 从黑名单中移除用户方法（每秒钟限 100 次）
         *
         * @param  user:用户 Id,blacklist（必传）
         *
         * @return ResponseResult
         **/
        public Result Remove(UserModel user)
        {
            String message = CommonUtil.CheckFiled(user, PATH, CheckMethod.REMOVE);
            if (null != message)
            {
                return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(message);
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("&userId=").Append(HttpUtility.UrlEncode(user.Id.ToString(), UTF8));
            foreach (UserModel blackUser in user.GetBlacklist())
            {
                sb.Append("&blackUserId=").Append(HttpUtility.UrlEncode(blackUser.Id.ToString(), UTF8));
            }
            String body = sb.ToString();
            if (body.IndexOf("&") == 0)
            {
                body = body.Substring(1, body.Length - 1);
            }
            String result = RongHttpClient.ExecutePost(appKey, appSecret, body,
                    RongCloud.ApiHostType.Type + "/user/blacklist/remove.json", "application/x-www-form-urlencoded");

            return (BlackListResult)RongJsonUtil.JsonStringToObj<BlackListResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.REMOVE, result));

        }
    }
}
