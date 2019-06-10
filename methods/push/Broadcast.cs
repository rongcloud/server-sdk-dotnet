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
    public class Broadcast
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

        public Broadcast(String appKey, String appSecret)
        {
            this.appKey = appKey;
            this.appSecret = appSecret;
        }

        /**
         * 广播
         *
         * @param broadcast 广播数据
         * @return PushResult
         **/
        public PushResult Send(BroadcastModel broadcast)
        {
            // 需要校验的字段
            String message = CommonUtil.CheckFiled(broadcast, PATH, CheckMethod.BROADCAST);
            if (null != message)
            {
                return (PushResult)RongJsonUtil.JsonStringToObj<PushResult>(message);
            }

            String body = RongJsonUtil.ObjToJsonString(broadcast);

            String result = RongHttpClient.ExecutePost(appKey, appSecret, body,
                    RongCloud.ApiHostType.Type + "/push.json", "application/json");

            return (PushResult)RongJsonUtil.JsonStringToObj<PushResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.BROADCAST, result));

        }

    }
}
