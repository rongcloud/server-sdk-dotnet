using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using io.rong;

namespace RongSDKDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            String retstr = null;
            String appKey = "uwd1c0sxdlx91";
            String appSecret = "hhetmryhVm";
            retstr = RongCloudServer.GetToken(appKey, appSecret, "232424", "xugang", "http://www.qqw21.com/article/UploadPic/2012-11/201211259378560.jpg");
            Console.WriteLine("getToken: " + retstr);
            Console.ReadKey();

            retstr = RongCloudServer.JoinGroup(appKey, appSecret, "232424", "group001","wsw");
            Console.WriteLine("joinGroup: " + retstr);
            Console.ReadKey();

            string[] arrId = { "group001", "group002", "group003" };
            string[] arrName = {"测试 01", "测试 02", "测试 03"};
            retstr = RongCloudServer.syncGroup(appKey, appSecret, "42424", arrId, arrName );
            Console.WriteLine("syncGroup: " + retstr);
            Console.ReadKey();

            retstr = RongCloudServer.DismissGroup(appKey, appSecret, "42424", "group001");
            Console.WriteLine("dismissgroup: " + retstr);
            Console.ReadKey();

            retstr = RongCloudServer.PublishMessage(appKey, appSecret, "2191", "2191", "RC:TxtMsg", "{\"content\":\"c#hello\"}");
            Console.WriteLine("PublishMsg: "  + retstr);
            Console.ReadKey();

            retstr = RongCloudServer.BroadcastMessage(appKey, appSecret, "2191", "RC:TxtMsg", "{\"content\":\"c#hello\"}");
            Console.WriteLine("Broad: " + retstr);
            Console.ReadKey();

            retstr = RongCloudServer.JoinGroup(appKey, appSecret, "423424", "dwef", "dwef");
            Console.WriteLine("JoinGroup: " + retstr);
            Console.ReadKey();

            retstr = RongCloudServer.CreateChatroom(appKey, appSecret, arrId, arrName);
            Console.WriteLine("createChat: " + retstr);
            Console.ReadKey();

            retstr = RongCloudServer.DestroyChatroom(appKey, appSecret, new String[]{"001", "002"});
            Console.WriteLine("Destroy: " + retstr);
            Console.ReadKey();

            string[] aaa = { "group002", "group003" };

            retstr = RongCloudServer.queryChatroom(appKey, appSecret, aaa);
            Console.WriteLine("queryChatroom: " + retstr);

            Console.ReadKey();

            Console.WriteLine("接口测试结束！")
            Console.ReadKey();
        }
    }
}
