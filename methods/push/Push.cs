using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using io.rong.models;
using io.rong.models.response;
using io.rong.models.push;
using io.rong.util;
using System.Web;

namespace io.rong.methods.push
{
    /**
     * 推送服务
     *
     * docs https://www.rongcloud.cn/docs/push_service.html#broadcast
     * https://www.rongcloud.cn/docs/push_service.html#push
     */
    public class Push
    {

        private static String UTF8 = "UTF-8";
        private static String PATH = "push";
        private String appKey;
        private String appSecret;
        public RongCloud RongCloud;

        public RongCloud GetRongCloud()
        {
            return RongCloud;
        }

        public void SetRongCloud(RongCloud rongCloud)
        {
            this.RongCloud = rongCloud;
        }

        public Push(String appKey, String appSecret)
        {
            this.appKey = appKey;
            this.appSecret = appSecret;
        }

        /**
         * 推送
         *
         * @param push 推送数据
         * @return PushResult
         **/
        public PushResult Send(PushModel push)
        {
            // 需要校验的字段
            String message = CommonUtil.CheckFiled(push, PATH, CheckMethod.PUSH);
            if (null != message)
            {
                return (PushResult)RongJsonUtil.JsonStringToObj<PushResult>(message);
            }

            String body = RongJsonUtil.ObjToJsonString(push);

            String result = RongHttpClient.ExecutePost(appKey, appSecret, body,
                    RongCloud.ApiHostType.Type + "/push.json", "application/json");

            return (PushResult)RongJsonUtil.JsonStringToObj<PushResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.BROADCAST, result));

        }
    }
}
