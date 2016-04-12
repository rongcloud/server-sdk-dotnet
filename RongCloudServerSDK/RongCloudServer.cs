using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Web;

namespace io.rong
{
    public class RongCloudServer
    {

        /**
         * 构建请求参数
         */
        private static String buildQueryStr(Dictionary<String, String> dicList)
        {
            String postStr = "";

            foreach (var item in dicList)
            {
                postStr += item.Key + "=" + HttpUtility.UrlEncode(item.Value,Encoding.UTF8) + "&";
            }
            postStr = postStr.Substring(0, postStr.LastIndexOf('&'));
            return postStr;
        }

        private static String buildParamStr(String[] arrParams)
        {
            String postStr = "";

            for (int i = 0; i < arrParams.Length; i++)
            {
                if (0 == i)
                {
                    postStr = "chatroomId=" + HttpUtility.UrlDecode(arrParams[0],Encoding.UTF8);
                }
                else
                {
                    postStr = postStr + "&" + "chatroomId=" + HttpUtility.UrlEncode(arrParams[i], Encoding.UTF8);
                }
            }
            return postStr;
        }

        /**
         * 获取 token
         */
        public static String GetToken(String appkey,String appSecret,String userId, String name, String portraitUri)
        {
            Dictionary<String, String> dicList = new Dictionary<String, String>();
            dicList.Add("userId", userId);
            dicList.Add("name", name);
            dicList.Add("portraitUri", portraitUri);

            String postStr = buildQueryStr(dicList);

            RongHttpClient client = new RongHttpClient(appkey, appSecret, InterfaceUrl.getTokenUrl, postStr);

            return client.ExecutePost();

        }

        /**
         * 加入 群组
         */
        public static String JoinGroup(String appkey, String appSecret, String userId, String groupId, String groupName)
        {
            Dictionary<String, String> dicList = new Dictionary<String, String>();
            dicList.Add("userId", userId);
            dicList.Add("groupId", groupId);
            dicList.Add("groupName", groupName);

            String postStr = buildQueryStr(dicList);

            RongHttpClient client = new RongHttpClient(appkey, appSecret, InterfaceUrl.joinGroupUrl, postStr);

            return client.ExecutePost();
        }

        /**
         * 退出 群组
         */
        public static String QuitGroup(String appkey, String appSecret, String userId, String groupId)
        {
            Dictionary<String, String> dicList = new Dictionary<String, String>();
            dicList.Add("userId", userId);
            dicList.Add("groupId", groupId);

            String postStr = buildQueryStr(dicList);

            RongHttpClient client = new RongHttpClient(appkey, appSecret, InterfaceUrl.quitGroupUrl, postStr);

            return client.ExecutePost();
        }

        /**
         * 解散 群组
         */
        public static String DismissGroup(String appkey, String appSecret, String userId, String groupId)
        {
            Dictionary<String, String> dicList = new Dictionary<String, String>();
            dicList.Add("userId", userId);
            dicList.Add("groupId", groupId);

            String postStr = buildQueryStr(dicList);

            RongHttpClient client = new RongHttpClient(appkey, appSecret, InterfaceUrl.dismissUrl, postStr);

            return client.ExecutePost();

        }
        
        /**
         * 同步群组
         */
        public static String syncGroup(String appkey, String appSecret, String userId, String[] groupId, String[] groupName)
        {
            
            String postStr = "userId=" + userId + "&";
            String id, name;

            for (int i = 0; i < groupId.Length; i++)
            {
                id = HttpUtility.UrlEncode(groupId[i], Encoding.UTF8);
                name = HttpUtility.UrlEncode(groupName[i], Encoding.UTF8);
                postStr += "group[" + id + "]=" + name + "&";
            }

            postStr = postStr.Substring(0, postStr.LastIndexOf('&'));

            RongHttpClient client = new RongHttpClient(appkey, appSecret, InterfaceUrl.syncGroupUrl, postStr);

            return client.ExecutePost();
        }

        
        /// <summary>
        /// 发送二人消息
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
            //此数据结构不适用多个toUserId情况,请注意
            Dictionary<String, String> dicList = new Dictionary<String, String>();
            dicList.Add("fromUserId", fromUserId);
            dicList.Add("toUserId", toUserId);
            dicList.Add("objectName", objectName);
            dicList.Add("content", content);

            String postStr = buildQueryStr(dicList);

            RongHttpClient client = new RongHttpClient(appkey, appSecret, InterfaceUrl.sendMsgUrl, postStr);

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
            Dictionary<String, String> dicList = new Dictionary<String, String>();
            dicList.Add("content", content);
            dicList.Add("fromUserId", fromUserId);
            dicList.Add("objectName", objectName);
            dicList.Add("pushContent", "");
            dicList.Add("pushData", "");

            String postStr = buildQueryStr(dicList);
            RongHttpClient client = new RongHttpClient(appkey, appSecret, InterfaceUrl.broadcastUrl, postStr);

            return client.ExecutePost();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appkey"></param>
        /// <param name="appSecret"></param>
        /// <param name="chatroomInfo">chatroom[id10001]=name1001</param>
        /// <returns></returns>
        public static String CreateChatroom(String appkey, String appSecret, String[] chatroomId, String[] chatroomName)
        {
            String postStr = null;

            String id, name;

            for (int i = 0; i < chatroomId.Length; i++)
            {
                id = HttpUtility.UrlEncode(chatroomId[i], Encoding.UTF8);
                name = HttpUtility.UrlEncode(chatroomName[i], Encoding.UTF8);
                postStr += "chatroom[" + id + "]=" + name + "&";
            }

            postStr = postStr.Substring(0, postStr.LastIndexOf('&'));

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
            
            postStr = buildParamStr(chatroomIdInfo);

            RongHttpClient client = new RongHttpClient(appkey, appSecret, InterfaceUrl.destroyChatroomUrl, postStr);

            return client.ExecutePost();
        }
        public static String queryChatroom(String appkey, String appSecret, String[] chatroomId)
        {
            String postStr = null;
            
            postStr = buildParamStr(chatroomId);

            RongHttpClient client = new RongHttpClient(appkey, appSecret, InterfaceUrl.queryChatroomUrl, postStr);

            return client.ExecutePost();
        }
    }
}
