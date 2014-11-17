using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace io.rong
{
    public class RongCloudServer
    {
        public static String GetToken(String appkey,String appSecret,String userId, String name, String portraitUri)
        {
            String postStr = "userId=" + userId + "&" + "name=" + name + "&" + "portraitUri=" + portraitUri;

            RongHttpClient client = new RongHttpClient(appkey, appSecret, InterfaceUrl.getTokenUrl, postStr);

            return client.ExecutePost();

        }

        public static String JoinGroup(String appkey, String appSecret, String userId, String groupId, String groupName)
        {
            String postStr = "userId=" + userId + "&" + "groupId=" + groupId + "&" + "groupName=" + groupName;

            RongHttpClient client = new RongHttpClient(appkey, appSecret, InterfaceUrl.joinGroupUrl, postStr);

            return client.ExecutePost();
        }

        public static String QuitGroup(String appkey, String appSecret, String userId, String groupId)
        {
            String postStr = "userId=" + userId + "&" + "groupId=" + groupId ;

            RongHttpClient client = new RongHttpClient(appkey, appSecret, InterfaceUrl.quitGroupUrl, postStr);

            return client.ExecutePost();
        }
        public static String DismissGroup(String appkey, String appSecret, String userId, String groupId)
        {
            String postStr = "userId=" + userId + "&" + "groupId=" + groupId;

            RongHttpClient client = new RongHttpClient(appkey, appSecret, InterfaceUrl.dismissUrl, postStr);

            return client.ExecutePost();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appkey"></param>
        /// <param name="appSecret"></param>
        /// <param name="userId"></param>
        /// <param name="groupInfo">groupInfo格式group[groupid10001]=groupname1001</param>
        /// <returns></returns>
        public static String syncGroup(String appkey, String appSecret, String userId,String[] groupInfo)
        {
            String postStr = "userId=" + userId;

            for (int i = 0; i < groupInfo.Length; i++)
            {
                postStr = postStr + "&" + groupInfo;
            }


            RongHttpClient client = new RongHttpClient(appkey, appSecret, InterfaceUrl.syncGroupUrl, postStr);

            return client.ExecutePost();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appkey"></param>
        /// <param name="appSecret"></param>
        /// <param name="fromUserId"></param>
        /// <param name="toUserId"></param>
        /// <param name="objectName"></param>
        /// <param name="content">RC:TxtMsg消息格式{"content":"hello"}  RC:ImgMsg消息格式{"content":"ergaqreg", "imageKey":"http://www.demo.com/1.jpg"}  RC:VcMsg消息格式{"content":"ergaqreg","duration":3}</param>
        /// <returns></returns>
        public static String PublishMessage(String appkey, String appSecret, String fromUserId, String toUserId, String objectName, String content)
        {
            String postStr = "content=" + content + "&" + "fromUserId=" + fromUserId + "&" + "toUserId=" + toUserId + "&" + "objectName=" + objectName;
            RongHttpClient client = new RongHttpClient(appkey, appSecret, InterfaceUrl.SendMsgUrl, postStr);

            return client.ExecutePost();
        }
        /// <summary>
        /// 广播消息暂时未开放
        /// </summary>
        /// <param name="appkey"></param>
        /// <param name="appSecret"></param>
        /// <param name="fromUserId"></param>
        /// <param name="objectName"></param>
        /// <param name="content">RC:TxtMsg消息格式{"content":"hello"}  RC:ImgMsg消息格式{"content":"ergaqreg", "imageKey":"http://www.demo.com/1.jpg"}  RC:VcMsg消息格式{"content":"ergaqreg","duration":3}</param>
        /// <returns></returns>
        public static String BroadcastMessage(String appkey, String appSecret, String fromUserId, String objectName, String content)
        {
            String postStr = "content=" + content+ "&" +"fromUserId=" + fromUserId + "&" + "objectName=" + objectName ;
            RongHttpClient client = new RongHttpClient(appkey, appSecret, InterfaceUrl.SendMsgUrl, postStr);

            return client.ExecutePost();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appkey"></param>
        /// <param name="appSecret"></param>
        /// <param name="chatroomInfo">chatroom[id10001]=name1001</param>
        /// <returns></returns>
        public static String CreateChatroom(String appkey, String appSecret, String[] chatroomInfo)
        {
            String postStr = null;
            for (int i = 0; i < chatroomInfo.Length; i++)
            {
                if (0 == i)
                {
                    postStr = chatroomInfo[0];
                }
                else
                {
                    postStr = postStr + "&" + chatroomInfo[i];
                }
            }
            RongHttpClient client = new RongHttpClient(appkey, appSecret, InterfaceUrl.createChatroomUrl, postStr);

            return client.ExecutePost();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appkey"></param>
        /// <param name="appSecret"></param>
        /// <param name="chatroomIdInfo">chatroomId=id1001</param>
        /// <returns></returns>
        public static String DestroyChatroom(String appkey, String appSecret, String[] chatroomIdInfo)
        {
            String postStr = null;
            for (int i = 0; i < chatroomIdInfo.Length; i++)
            {
                if (0 == i)
                {
                    postStr = chatroomIdInfo[0];
                }
                else
                {
                    postStr = postStr + "&" + chatroomIdInfo[i];
                }
            }
            RongHttpClient client = new RongHttpClient(appkey, appSecret, InterfaceUrl.destroyChatroomUrl, postStr);

            return client.ExecutePost();
        }
        public static String queryChatroom(String appkey, String appSecret, String[] chatroomId)
        {
            String postStr = null;
            for (int i = 0; i < chatroomId.Length; i++)
            {
                if (0 == i)
                {
                    postStr = "chatroomId+" + chatroomId[0];
                }
                else
                {
                    postStr = postStr + "chatroomId+" + "&" + chatroomId[i];
                }
            }
            RongHttpClient client = new RongHttpClient(appkey, appSecret, InterfaceUrl.queryChatroomUrl, postStr);

            return client.ExecutePost();
        }
    }
}
