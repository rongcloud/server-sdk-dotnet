using System;
using System.Text;
using io.rong.models.response;
using io.rong.models;
using io.rong.util;
using io.rong.models.push.tag;
using System.Web;

namespace io.rong.methods.user.tag
{
    public class Tag
    {
        private static readonly Encoding UTF8 = Encoding.UTF8;
        private static readonly String PATH = "user/tag";
        private String appKey;
        private String appSecret;

        private RongCloud rongCloud;

        public RongCloud RongCloud
        {
            get { return this.rongCloud; }
            set
            {
                this.rongCloud = value;
            }
        }

        public Tag(String appKey, String appSecret)
        {
            this.appKey = appKey;
            this.appSecret = appSecret;
        }

        /**
         * 设置用户标签
         */
        public ResponseResult Set(TagModel tagModel)
        {
            //需要校验的字段
            String message = CommonUtil.CheckFiled(tagModel, PATH, CheckMethod.TAG_SET);
            if (null != message)
            {
                return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(message);
            }

            String body = RongJsonUtil.ObjToJsonString(tagModel);

            String result = RongHttpClient.ExecutePost(appKey, appSecret, body,
                    rongCloud.ApiHostType.Type + "/user/tag/set.json", "application/json");

            return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.TAG_SET, result));
        }

        /**
         * 批量设置用户标签
         */
        public ResponseResult BatchSet(TagModel tagModel)
        {
            String message = CommonUtil.CheckFiled(tagModel, PATH, CheckMethod.TAG_BATCH_SET);
            if (null != message)
            {
                return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(message);
            }

            String body = RongJsonUtil.ObjToJsonString(tagModel);

            String result = RongHttpClient.ExecutePost(appKey, appSecret, body,
                    rongCloud.ApiHostType.Type + "/user/tag/batch/set.json", "application/json");

            return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.TAG_BATCH_SET, result));
        }


        /**
         * 获取用户标签
         */
        public Result Get(String[] userIds)
        {
           if (userIds.Length < 1)
            {
                return new Result(20005, "用户 Id 不能为空");
            }

            StringBuilder sb = new StringBuilder();
            foreach (String userId in userIds)
            {
                sb.Append("&userIds=").Append(HttpUtility.UrlEncode(userId, UTF8));
            }

            String body = sb.ToString();
            if (body.IndexOf("&") == 0)
            {
                body = body.Substring(1, body.Length - 1);
            }

            String result = RongHttpClient.ExecutePost(appKey, appSecret, body,
                    rongCloud.ApiHostType.Type + "/user/tags/get.json", "application/x-www-form-urlencoded");

            return (TagListResult)RongJsonUtil.JsonStringToObj<TagListResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.TAG_GET, result));
        }
    }
}
