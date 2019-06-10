using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using io.rong.models;
using io.rong.models.response;
using io.rong.models.push;
using io.rong.util;
using System.Web;

namespace io.rong.example.push
{
    public class PushExample
    {
        /**
     * 此处替换成您的appKey
     * */
        private static String appKey = "pwe86ga5pwrj6";
        /**
         * 此处替换成您的appSecret
         * */
        private static String appSecret = "rb8fWki1mJcK";
        /**
         * 自定义api地址
         * */
        private static String api = "http://api-cn.ronghub.com";


        public static void Main(String[] args)
        {

            RongCloud rongCloud = RongCloud.GetInstance(appKey, appSecret);

            /**
             *
             * API 文档:
             * https://www.rongcloud.cn/docs/push_service.html#broadcast
             *
             * 广播消息
             *
             **/
            BroadcastModel broadcast = new BroadcastModel();
            broadcast.SetFromuserid("fromuserid");
            broadcast.SetPlatform(new String[] { "ios", "android" });
            Audience audience = new Audience();
            audience.SetUserid(new String[] { "userid1", "userid2" });
            broadcast.SetAudience(audience);
            Message message = new Message();
            message.SetContent("this is message");
            message.SetObjectName("RC:TxtMsg");
            broadcast.SetMessage(message);
            Notification notification = new Notification();
            notification.SetAlert("this is broadcast");
            broadcast.SetNotification(notification);
            PushResult result = rongCloud.Broadcast.Send(broadcast);

            Console.WriteLine("broadcast: " + result.ToString());


            /**
             *
             * API 文档:
             * https://www.rongcloud.cn/docs/push_service.html#push
             *
             * 推送消息
             *
             **/
            PushModel pushmodel = new PushModel();
            pushmodel.SetPlatform(new String[] { "ios", "android" });
            audience = new Audience();
            audience.SetUserid(new String[] { "userid1", "userid2" });
            pushmodel.SetAudience(audience);
            notification = new Notification();
            notification.SetAlert("this is push");
            pushmodel.SetNotification(notification);
            result = rongCloud.Push.Send(pushmodel);

            Console.WriteLine("push: " + result.ToString());

            Console.ReadLine();
        }
    }
}
