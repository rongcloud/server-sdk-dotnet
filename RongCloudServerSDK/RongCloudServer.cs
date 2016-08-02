using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Web;
using io.rong.util;
using io.rong.models;
using Newtonsoft.Json;

namespace io.rong {
    public class RongCloudServer {
        private String appKey, appSecret;
        private static RongCloudServer rongServer;
        //确保线程同步
        private static readonly object locker = new object();

        private RongCloudServer(String appKey, String appSecret) {
            this.appKey = appKey;
            this.appSecret = appSecret;
        }

        public static RongCloudServer getInstance(String appKey, String appSecret) {
            lock (locker) {
                if (rongServer == null) {
                    rongServer = new RongCloudServer(appKey, appSecret);
                }
            }
            return rongServer;
        }

        /**
         * 构建请求参数
         */
        private String buildQueryStr(IDictionary<String, Object> dicList) {
            String postStr = "";

            foreach (var item in dicList) {
                if (typeof(List<String>).IsInstanceOfType(item.Value)) {
                    foreach (String value in (List<String>)item.Value) {
                        postStr += item.Key + "=" + HttpUtility.UrlEncode(value, Encoding.UTF8) + "&";
                    }
                } else {
                    postStr += item.Key + "=" + HttpUtility.UrlEncode(item.Value.ToString(), Encoding.UTF8) + "&";
                }
            }
            postStr = postStr.Substring(0, postStr.LastIndexOf('&'));
            return postStr;
        }

        /// <summary>
        /// 构建请求字符串
        /// </summary>
        /// <param name="arrParams">key => value</param>
        /// <returns></returns>
        private String buildParamStr(String[] arrParams) {
            String postStr = "";

            for (int i = 0; i < arrParams.Length; i++) {
                if (0 == i) {
                    postStr = "chatroomId=" + HttpUtility.UrlDecode(arrParams[0], Encoding.UTF8);
                } else {
                    postStr = postStr + "&" + "chatroomId=" + HttpUtility.UrlEncode(arrParams[i], Encoding.UTF8);
                }
            }
            return postStr;
        }

        /// <summary>
        /// 获取用户 token
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="name"></param>
        /// <param name="portraitUri"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public RongHttpResult getToken(String userId, String name, String portraitUri, FormatType format = null) {
            Dictionary<String, Object> dicList = new Dictionary<String, Object>();
            dicList.Add("userId", userId);
            dicList.Add("name", name);
            dicList.Add("portraitUri", portraitUri);

            String postStr = buildQueryStr(dicList);

            RongHttpClient client = new RongHttpClient(appKey, appSecret, InterfaceUrl.getTokenUrl, postStr, format);

            return client.ExecutePost();

        }
        /// <summary>
        /// 刷新用户信息
        /// </summary>
        /// <param name="userId">用户 id</param>
        /// <param name="name">用户昵称</param>
        /// <param name="portraitUri">用户头像</param>
        /// <returns></returns>
        public RongHttpResult refreshUserInfo(String userId, String name, String portraitUri, FormatType format = null) {
            Dictionary<String, Object> dicList = new Dictionary<String, Object>();
            dicList.Add("userId", userId);
            dicList.Add("name", name);
            dicList.Add("portraitUri", portraitUri);

            String postStr = buildQueryStr(dicList);

            RongHttpClient client = new RongHttpClient(appKey, appSecret, InterfaceUrl.refreshInfoUrl, postStr, format);

            return client.ExecutePost();
        }

        /// <summary>
        /// 检查用户在线状态 
        /// </summary>
        /// <param name="userId">用户 id</param>
        /// <returns></returns>
        public RongHttpResult checkOnline(String userId, FormatType format = null) {
            Dictionary<String, Object> dicList = new Dictionary<String, Object>();
            dicList.Add("userId", userId);

            String postStr = buildQueryStr(dicList);

            RongHttpClient client = new RongHttpClient(appKey, appSecret, InterfaceUrl.checkOnlineUrl, postStr, format);

            return client.ExecutePost();
        }

        /// <summary>
        /// 封禁用户
        /// </summary>
        /// <param name="userId">用户 id</param>
        /// <param name="minute">封禁分钟</param>
        /// <returns></returns>
        public RongHttpResult blockUser(String userId, int minute, FormatType format = null) {
            Dictionary<String, Object> dicList = new Dictionary<String, Object>();
            if (minute < 0 || minute > 43200) {
                new RongHttpResult(400, "{\"code\":1002, \"msg\":\"minute is error.\"}");
            }
            dicList.Add("userId", userId);
            dicList.Add("minute", minute.ToString());

            String postStr = buildQueryStr(dicList);

            RongHttpClient client = new RongHttpClient(appKey, appSecret, InterfaceUrl.blockUserUrl, postStr, format);

            return client.ExecutePost();
        }

        /// <summary>
        /// 解除用户封禁
        /// </summary>
        /// <param name="userId">用户 id</param>
        /// <returns></returns>
        public RongHttpResult unblockUser(String userId, FormatType format = null) {
            Dictionary<String, Object> dicList = new Dictionary<String, Object>();
            dicList.Add("userId", userId);

            String postStr = buildQueryStr(dicList);

            RongHttpClient client = new RongHttpClient(appKey, appSecret, InterfaceUrl.unblockUserUrl, postStr, format);

            return client.ExecutePost();
        }

        /// <summary>
        /// 获取被封禁用户
        /// </summary>
        /// <returns></returns>
        public RongHttpResult getBlockList(FormatType format = null) {
            RongHttpClient client = new RongHttpClient(appKey, appSecret, InterfaceUrl.getBlockUserUrl, "", format);

            return client.ExecutePost();
        }

        /// <summary>
        /// 添加用户到黑名单
        /// </summary>
        /// <param name="userId">用户 id</param>
        /// <param name="blackUserId">需要封禁的用户 id</param>
        /// <returns></returns>
        public RongHttpResult addToBlackList(String userId, String blackUserId, FormatType format = null) {
            Dictionary<String, Object> dicList = new Dictionary<String, Object>();
            dicList.Add("userId", userId);
            dicList.Add("blackUserId", blackUserId);
            String postStr = buildQueryStr(dicList);

            RongHttpClient client = new RongHttpClient(appKey, appSecret, InterfaceUrl.addToBlacklistUrl, postStr, format);

            return client.ExecutePost();
        }

        /// <summary>
        /// 从黑名单中移除用户
        /// </summary>
        /// <param name="userId">用户 id</param>
        /// <param name="blackUserId">被封禁用户 id</param>
        /// <returns></returns>
        public RongHttpResult removeFromBlackList(String userId, String blackUserId, FormatType format = null) {
            Dictionary<String, Object> dicList = new Dictionary<String, Object>();
            dicList.Add("userId", userId);
            dicList.Add("blackUserId", blackUserId);
            String postStr = buildQueryStr(dicList);

            RongHttpClient client = new RongHttpClient(appKey, appSecret, InterfaceUrl.removeFromBlacklistUrl, postStr, format);

            return client.ExecutePost();
        }

        /// <summary>
        /// 获取用户的黑名单列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public RongHttpResult getBlackList(String userId, FormatType format = null) {
            Dictionary<String, Object> dicList = new Dictionary<String, Object>();
            dicList.Add("userId", userId);
            String postStr = buildQueryStr(dicList);

            RongHttpClient client = new RongHttpClient(appKey, appSecret, InterfaceUrl.getBlacklistUrl, postStr, format);

            return client.ExecutePost();
        }

        /// <summary>
        /// 发送单聊消息
        /// </summary>
        /// <param name="fromUserId">发送者 id</param>
        /// <param name="toUserIds">接收者 id 支持多个用户</param>
        /// <param name="msg"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public RongHttpResult publishMessage(String fromUserId, List<String> toUserIds, Message msg, FormatType format = null) {
            Dictionary<String, Object> dicList = new Dictionary<String, Object>();
            dicList.Add("fromUserId", fromUserId);

            if (toUserIds != null) {
                List<String> listUser = new List<string>();
                foreach (String userId in toUserIds) {
                    listUser.Add(userId);
                    if (!dicList.ContainsKey("toUserId")) {
                        dicList.Add("toUserId", listUser);
                    }
                }
            }

            dicList.Add("objectName", msg.getType());
            dicList.Add("content", msg.toString());

            String postStr = buildQueryStr(dicList);

            RongHttpClient client = new RongHttpClient(appKey, appSecret, InterfaceUrl.sendMsgUrl, postStr, format);

            return client.ExecutePost();
        }

        /// <summary>
        /// 发送单聊模板消息
        /// </summary>
        /// <param name="fromUserId">发送人用户 Id</param>
        /// <param name="toUserId">接收用户 Id</param>
        /// <param name="msg">发送消息内容</param>
        /// <param name="values">消息内容中，标识位对应内容</param>
        /// <param name="pushContent"></param>
        /// <param name="pushData"></param>
        /// <param name="verifyBlacklist"></param>
        /// <returns></returns>
        public RongHttpResult publishTemplateMsg(String fromUserId, List<String> toUserId, Message msg, List<Dictionary<String, String>> values, 
            List<String> pushContent, List<String> pushData, int verifyBlacklist, FormatType format = null) {
            Dictionary<String, Object> dicList = new Dictionary<string, object>();
            dicList.Add("fromUserId", fromUserId);
            dicList.Add("objectName", msg.getType());
            dicList.Add("content", msg.toString());
            dicList.Add("toUserId", toUserId);
            dicList.Add("values", values);
            dicList.Add("pushContent", pushContent);
            dicList.Add("pushData", pushData);
            dicList.Add("verifyBlacklist", verifyBlacklist);

            JsonSerializerSettings jsetting = new JsonSerializerSettings();
            jsetting.NullValueHandling = NullValueHandling.Ignore;
            String postStr = JsonConvert.SerializeObject(dicList);

            RongHttpClient client = new RongHttpClient(appKey, appSecret, InterfaceUrl.sendTemplateMsgUrl, postStr, format);

            return client.ExecutePostJson();
        }

        /// <summary>
        /// 发送系统消息
        /// </summary>
        /// <param name="fromUserId">发送者 id</param>
        /// <param name="toUserIds">接收者 id</param>
        /// <param name="msg"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public RongHttpResult publishSysMsg(String fromUserId, List<String> toUserIds, Message msg, FormatType format = null) {
            Dictionary<String, Object> dicList = new Dictionary<String, Object>();
            dicList.Add("fromUserId", fromUserId);

            if (toUserIds != null) {
                List<String> listUser = new List<string>();
                foreach (String userId in toUserIds) {
                    listUser.Add(userId);
                    if (!dicList.ContainsKey("toUserId")) {
                        dicList.Add("toUserId", listUser);
                    }
                }
            }

            dicList.Add("objectName", msg.getType());
            dicList.Add("content", msg.toString());

            String postStr = buildQueryStr(dicList);

            RongHttpClient client = new RongHttpClient(appKey, appSecret, InterfaceUrl.sendSysMsgUrl, postStr, format);

            return client.ExecutePost();
        }

        /// <summary>
        /// 发送系统模板消息
        /// </summary>
        /// <param name="fromUserId">发送人用户 Id</param>
        /// <param name="toUserId">接收用户 Id</param>
        /// <param name="msg">发送消息内容</param>
        /// <param name="values">消息内容中，标识位对应内容</param>
        /// <param name="pushContent"></param>
        /// <param name="pushData"></param>
        /// <param name="verifyBlacklist"></param>
        /// <returns></returns>
        public RongHttpResult publishSysTemplateMsg(String fromUserId, List<String> toUserId, Message msg, List<Dictionary<String, String>> values,
            List<String> pushContent, List<String> pushData, FormatType format = null) {
            Dictionary<String, Object> dicList = new Dictionary<string, object>();
            dicList.Add("fromUserId", fromUserId);
            dicList.Add("objectName", msg.getType());
            dicList.Add("content", msg.toString());
            dicList.Add("toUserId", toUserId);
            dicList.Add("values", values);
            dicList.Add("pushContent", pushContent);
            dicList.Add("pushData", pushData);

            JsonSerializerSettings jsetting = new JsonSerializerSettings();
            jsetting.NullValueHandling = NullValueHandling.Ignore;
            String postStr = JsonConvert.SerializeObject(dicList);

            RongHttpClient client = new RongHttpClient(appKey, appSecret, InterfaceUrl.sendSysTemplateMsgUrl, postStr, format);

            return client.ExecutePostJson();
        }

        /// <summary>
        /// 发送群组消息
        /// </summary>
        /// <param name="fromUserId">发送者 id</param>
        /// <param name="toUserIds">接收者 id</param>
        /// <param name="msg"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public RongHttpResult publishGrmMsg(String fromUserId, List<String> toGroupIds, Message msg, FormatType format = null) {
            Dictionary<String, Object> dicList = new Dictionary<String, Object>();
            dicList.Add("fromUserId", fromUserId);

            if (toGroupIds != null) {
                List<String> listGroup = new List<string>();
                foreach (String toGroupId in toGroupIds) {
                    listGroup.Add(toGroupId);
                    if (!dicList.ContainsKey("toGroupId")) {
                        dicList.Add("toGroupId", listGroup);
                    }
                }
            }

            dicList.Add("objectName", msg.getType());
            dicList.Add("content", msg.toString());

            String postStr = buildQueryStr(dicList);

            RongHttpClient client = new RongHttpClient(appKey, appSecret, InterfaceUrl.sendGrmMsgUrl, postStr, format);

            return client.ExecutePost();
        }

        /// <summary>
        /// 发送讨论组消息
        /// </summary>
        /// <param name="fromUserId">发送者 id</param>
        /// <param name="toUserIds">讨论组 id</param>
        /// <param name="msg"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public RongHttpResult publishDissMsg(String fromUserId, String toDiscussionId, Message msg, FormatType format = null) {
            Dictionary<String, Object> dicList = new Dictionary<String, Object>();
            dicList.Add("fromUserId", fromUserId);
            dicList.Add("toDiscussionId", toDiscussionId);
            dicList.Add("objectName", msg.getType());
            dicList.Add("content", msg.toString());

            String postStr = buildQueryStr(dicList);

            RongHttpClient client = new RongHttpClient(appKey, appSecret, InterfaceUrl.sendDissMsgUrl, postStr, format);

            return client.ExecutePost();
        }

        /// <summary>
        /// 发送聊天室消息
        /// </summary>
        /// <param name="fromUserId">发送者 id</param>
        /// <param name="toUserIds">聊天室 id</param>
        /// <param name="msg"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public RongHttpResult publishCtrmMsg(String fromUserId, List<String> toChatroomIds, Message msg, FormatType format = null) {
            Dictionary<String, Object> dicList = new Dictionary<String, Object>();
            dicList.Add("fromUserId", fromUserId);

            if (toChatroomIds != null) {
                List<String> listChatroom = new List<string>();
                foreach (String chatroomId in toChatroomIds) {
                    listChatroom.Add(chatroomId);
                    if (!dicList.ContainsKey("toChatroomId")) {
                        dicList.Add("toChatroomId", listChatroom);
                    }
                }
            }
            
            dicList.Add("objectName", msg.getType());
            dicList.Add("content", msg.toString());

            String postStr = buildQueryStr(dicList);

            RongHttpClient client = new RongHttpClient(appKey, appSecret, InterfaceUrl.sendCtrmMsgUrl, postStr, format);

            return client.ExecutePost();
        }

        /// <summary>
        /// 发送广播消息
        /// </summary>
        /// <param name="fromUserId">发送者 id</param>
        /// <param name="msg"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public RongHttpResult publishBroMsg(String fromUserId, Message msg, FormatType format = null) {
            Dictionary<String, Object> dicList = new Dictionary<String, Object>();
            dicList.Add("fromUserId", fromUserId);
            dicList.Add("objectName", msg.getType());
            dicList.Add("content", msg.toString());

            String postStr = buildQueryStr(dicList);

            RongHttpClient client = new RongHttpClient(appKey, appSecret, InterfaceUrl.sendBroMsgUrl, postStr, format);

            return client.ExecutePost();
        }

        /// <summary>
        /// 添加敏感词
        /// </summary>
        /// <param name="word">敏感词</param>
        /// <returns></returns>
        public RongHttpResult addWordFilter(String word, FormatType format = null) {
            Dictionary<String, Object> dicList = new Dictionary<String, Object>();
            dicList.Add("word", word);
            String postStr = buildQueryStr(dicList);

            RongHttpClient client = new RongHttpClient(appKey, appSecret, InterfaceUrl.addWordFilterUrl, postStr, format);

            return client.ExecutePost();
        }

        /// <summary>
        /// 移除敏感词
        /// </summary>
        /// <param name="word">敏感词</param>
        /// <returns></returns>
        public RongHttpResult removeWordFilter(String word, FormatType format = null) {
            Dictionary<String, Object> dicList = new Dictionary<String, Object>();
            dicList.Add("word", word);
            String postStr = buildQueryStr(dicList);

            RongHttpClient client = new RongHttpClient(appKey, appSecret, InterfaceUrl.removeWordFilterUrl, postStr, format);

            return client.ExecutePost();
        }

        /// <summary>
        /// 查询敏感词列表
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public RongHttpResult listWordFilter(FormatType format = null) {
            String postStr = "";
            RongHttpClient client = new RongHttpClient(appKey, appSecret, InterfaceUrl.listWordFilterUrl, postStr, format);

            return client.ExecutePost();
        }

        /// <summary>
        /// 创建群组
        /// </summary>
        /// <param name="userId">用户 id</param>
        /// <param name="groupId">群组 id</param>
        /// <param name="groupName">群租名称</param>
        /// <param name="format"></param>
        /// <returns></returns>
        public RongHttpResult createGroup(String userId, String groupId, String groupName, FormatType format = null) {
            Dictionary<String, Object> dicList = new Dictionary<String, Object>();
            dicList.Add("userId", userId);
            dicList.Add("groupId", groupId);
            dicList.Add("groupName", groupName);

            String postStr = buildQueryStr(dicList);

            RongHttpClient client = new RongHttpClient(appKey, appSecret, InterfaceUrl.createGroupUrl, postStr, format);

            return client.ExecutePost();
        }

        /// <summary>
        /// 加入群组
        /// </summary>
        /// <param name="userId">用户 id</param>
        /// <param name="groupId">群 id</param>
        /// <param name="groupName">群名称</param>
        /// <param name="format"></param>
        /// <returns></returns>
        public RongHttpResult joinGroup(List<String> userIds, String groupId, String groupName, FormatType format = null) {
            Dictionary<String, Object> dicList = new Dictionary<string, Object>();

            if (userIds != null) {
                List<String> listUser = new List<string>();
                foreach (String userId in userIds) {
                    listUser.Add(userId);
                    if (!dicList.ContainsKey("userId")) {
                        dicList.Add("userId", listUser);
                    }
                }
            }
            dicList.Add("groupId", groupId);
            dicList.Add("groupName", groupName);

            String postStr = buildQueryStr(dicList);

            RongHttpClient client = new RongHttpClient(appKey, appSecret, InterfaceUrl.joinGroupUrl, postStr, format);

            return client.ExecutePost();
        }

        /// <summary>
        /// 退出群组
        /// </summary>
        /// <param name="userId">用户 id</param>
        /// <param name="groupId">群 id</param>
        /// <param name="format"></param>
        /// <returns></returns>
        public RongHttpResult quitGroup(String userId, String groupId, FormatType format = null) {
            Dictionary<String, Object> dicList = new Dictionary<String, Object>();
            dicList.Add("userId", userId);
            dicList.Add("groupId", groupId);

            String postStr = buildQueryStr(dicList);

            RongHttpClient client = new RongHttpClient(appKey, appSecret, InterfaceUrl.quitGroupUrl, postStr, format);

            return client.ExecutePost();
        }

        /// <summary>
        /// 解散群组
        /// </summary>
        /// <param name="userId">用户 id</param>
        /// <param name="groupId">群 id</param>
        /// <param name="format"></param>
        /// <returns></returns>
        public RongHttpResult dismissGroup(String userId, String groupId, FormatType format = null) {
            Dictionary<String, Object> dicList = new Dictionary<String, Object>();
            dicList.Add("userId", userId);
            dicList.Add("groupId", groupId);

            String postStr = buildQueryStr(dicList);

            RongHttpClient client = new RongHttpClient(appKey, appSecret, InterfaceUrl.dismissUrl, postStr, format);

            return client.ExecutePost();
        }

        /// <summary>
        /// 同步群组
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="groupId"></param>
        /// <param name="groupName"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public RongHttpResult syncGroup(String userId, String[] groupId, String[] groupName, FormatType format = null) {
            String postStr = "userId=" + userId + "&";
            String id, name;

            for (int i = 0; i < groupId.Length; i++) {
                id = HttpUtility.UrlEncode(groupId[i], Encoding.UTF8);
                name = HttpUtility.UrlEncode(groupName[i], Encoding.UTF8);
                postStr += "group[" + id + "]=" + name + "&";
            }

            postStr = postStr.Substring(0, postStr.LastIndexOf('&'));

            RongHttpClient client = new RongHttpClient(appKey, appSecret, InterfaceUrl.syncGroupUrl, postStr, format);

            return client.ExecutePost();
        }

        /// <summary>
        /// 刷新群组信息
        /// </summary>
        /// <param name="groupId">群组 id</param>
        /// <param name="groupName">群组名称</param>
        /// <returns></returns>
        public RongHttpResult refreshGroup(String groupId, String groupName, FormatType format = null) {
            Dictionary<String, Object> dicList = new Dictionary<String, Object>();
            dicList.Add("groupId", groupId);
            dicList.Add("groupName", groupName);
            String postStr = buildQueryStr(dicList);

            RongHttpClient client = new RongHttpClient(appKey, appSecret, InterfaceUrl.refreshGroupUrl, postStr, format);

            return client.ExecutePost();
        }

        /// <summary>
        /// 查询群成员
        /// </summary>
        /// <param name="groupId">群组 id</param>
        /// <returns></returns>
        public RongHttpResult queryGroupUrl(String groupId, FormatType format = null) {
            String postStr = "groupId=" + groupId;
            RongHttpClient client = new RongHttpClient(appKey, appSecret, InterfaceUrl.queryGroupUrl, postStr, format);

            return client.ExecutePost();
        }

        /// <summary>
        /// 添加禁言群成员
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="groupId"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public RongHttpResult addGroupGagUser(String userId, String groupId, int minute, FormatType format = null) {
            Dictionary<String, Object> dicList = new Dictionary<String, Object>();
            dicList.Add("userId", userId);
            dicList.Add("groupId", groupId);
            dicList.Add("minute", minute.ToString());
            String postStr = buildQueryStr(dicList);

            RongHttpClient client = new RongHttpClient(appKey, appSecret, InterfaceUrl.addGroupGagUrl, postStr, format);

            return client.ExecutePost();
        }

        /// <summary>
        /// 移除禁言群成员
        /// </summary>
        /// <param name="userId">用户 id</param>
        /// <param name="groupId">群组 id</param>
        /// <returns></returns>
        public RongHttpResult removeGroupGagUser(String userId, String groupId, FormatType format = null) {
            Dictionary<String, Object> dicList = new Dictionary<String, Object>();
            dicList.Add("userId", userId);
            dicList.Add("groupId", groupId);
            String postStr = buildQueryStr(dicList);

            RongHttpClient client = new RongHttpClient(appKey, appSecret, InterfaceUrl.removeGroupGagUrl, postStr, format);

            return client.ExecutePost();
        }

        /// <summary>
        /// 查询被禁言群成员
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public RongHttpResult listGroupGagUser(string groupId, FormatType format = null) {
            Dictionary<String, Object> dicList = new Dictionary<String, Object>();
            dicList.Add("groupId", groupId);
            String postStr = buildQueryStr(dicList);

            RongHttpClient client = new RongHttpClient(appKey, appSecret, InterfaceUrl.listGroupGagUrl, postStr, format);

            return client.ExecutePost();
        }

        /// <summary>
        /// 创建讨论组
        /// </summary>
        /// <param name="chatroomInfo">chatroom[id10001]=name1001</param>
        /// <returns></returns>
        public RongHttpResult createChatroom(String[] chatroomId, String[] chatroomName, FormatType format = null) {
            String postStr = null;

            String id, name;

            for (int i = 0; i < chatroomId.Length; i++) {
                id = HttpUtility.UrlEncode(chatroomId[i], Encoding.UTF8);
                name = HttpUtility.UrlEncode(chatroomName[i], Encoding.UTF8);
                postStr += "chatroom[" + id + "]=" + name + "&";
            }

            postStr = postStr.Substring(0, postStr.LastIndexOf('&'));

            RongHttpClient client = new RongHttpClient(appKey, appSecret, InterfaceUrl.createChatroomUrl, postStr, format);

            return client.ExecutePost();
        }

        /// <summary>
        /// 销毁聊天室
        /// </summary>
        /// <param name="chatroomIdInfo">chatroomId=id1001</param>
        /// <returns></returns>
        public RongHttpResult destroyChatroom(String chatroomId, FormatType format = null) {
            String postStr = null;

            postStr = "chatroomId=" + chatroomId;

            RongHttpClient client = new RongHttpClient(appKey, appSecret, InterfaceUrl.destroyChatroomUrl, postStr, format);

            return client.ExecutePost();
        }

        /// <summary>
        /// 查询聊天室信息
        /// </summary>
        /// <param name="chatroomId">聊天室 id</param>
        /// <param name="format"></param>
        /// <returns></returns>
        public RongHttpResult queryChatroom(String[] chatroomId, FormatType format = null) {
            String postStr = null;

            postStr = buildParamStr(chatroomId);

            RongHttpClient client = new RongHttpClient(appKey, appSecret, InterfaceUrl.queryChatroomUrl, postStr, format);

            return client.ExecutePost();
        }

        /// <summary>
        /// 加入讨论组
        /// </summary>
        /// <param name="userId">用户 id</param>
        /// <param name="chatroomId">讨论组 id</param>
        /// <returns></returns>
        public RongHttpResult joinChatroom(List<String> userIds, String chatroomId, FormatType format = null) {
            Dictionary<String, Object> dicList = new Dictionary<String, Object>();

            if (userIds != null) {
                List<String> listUser = new List<string>();
                foreach (String userId in userIds) {
                    listUser.Add(userId);
                    if (!dicList.ContainsKey("userId")) {
                        dicList.Add("userId", listUser);
                    }
                }
            }

            dicList.Add("chatroomId", chatroomId);

            String postStr = buildQueryStr(dicList);

            RongHttpClient client = new RongHttpClient(appKey, appSecret, InterfaceUrl.joinChatroomUrl, postStr, format);

            return client.ExecutePost();
        }

        public RongHttpResult queryChatroomUser(String chatroomId, int count, Boolean order = true, FormatType format = null) {
            Dictionary<String, Object> dicList = new Dictionary<String, Object>();
            dicList.Add("chatroomId", chatroomId);
            dicList.Add("count", count.ToString());
            if (order == true) {
                dicList.Add("order", "1");
            } else {
                dicList.Add("order", "0");
            }

            String postStr = buildQueryStr(dicList);

            RongHttpClient client = new RongHttpClient(appKey, appSecret, InterfaceUrl.queryChatroomUserUrl, postStr, format);

            return client.ExecutePost();
        }

        /// <summary>
        /// 添加禁言聊天室成员
        /// </summary>
        /// <param name="userId">用户 id</param>
        /// <param name="chatroomId">聊天室 id</param>
        /// <param name="minute">禁言时长</param>
        /// <returns></returns>
        public RongHttpResult addChatroomGagUser(String userId, String chatroomId, int minute, FormatType format = null) {
            Dictionary<String, Object> dicList = new Dictionary<String, Object>();
            dicList.Add("userId", userId);
            dicList.Add("chatroomId", chatroomId);
            dicList.Add("minute", minute.ToString());
            String postStr = buildQueryStr(dicList);

            RongHttpClient client = new RongHttpClient(appKey, appSecret, InterfaceUrl.addChatroomGagUrl, postStr, format);

            return client.ExecutePost();
        }

        /// <summary>
        /// 移除禁言聊天室成员
        /// </summary>
        /// <param name="userId">用户 id</param>
        /// <param name="chatroomId">聊天室 id</param>
        /// <param name="minute">禁言时长</param>
        /// <returns></returns>
        public RongHttpResult removeChatroomGagUser(String userId, String chatroomId, FormatType format = null) {
            Dictionary<String, Object> dicList = new Dictionary<String, Object>();
            dicList.Add("userId", userId);
            dicList.Add("chatroomId", chatroomId);
            String postStr = buildQueryStr(dicList);

            RongHttpClient client = new RongHttpClient(appKey, appSecret, InterfaceUrl.removeChatroomGagUrl, postStr, format);

            return client.ExecutePost();
        }

        /// <summary>
        /// 查询禁言聊天室成员
        /// </summary>
        /// <param name="userId">用户 id</param>
        /// <param name="chatroomId">聊天室 id</param>
        /// <param name="minute">禁言时长</param>
        /// <returns></returns>
        public RongHttpResult listChatroomGagUser(String chatroomId, FormatType format = null) {
            Dictionary<String, Object> dicList = new Dictionary<String, Object>();
            dicList.Add("chatroomId", chatroomId);
            String postStr = buildQueryStr(dicList);

            RongHttpClient client = new RongHttpClient(appKey, appSecret, InterfaceUrl.listChatroomGagUrl, postStr, format);

            return client.ExecutePost();
        }

        /// <summary>
        /// 添加封禁聊天室成员
        /// </summary>
        /// <param name="userId">用户 id</param>
        /// <param name="chatroomId">聊天室 id</param>
        /// <param name="minute">禁言时长</param>
        /// <returns></returns>
        public RongHttpResult addChatroomBlockUser(String userId, String chatroomId, int minute, FormatType format = null) {
            Dictionary<String, Object> dicList = new Dictionary<String, Object>();
            dicList.Add("userId", userId);
            dicList.Add("chatroomId", chatroomId);
            dicList.Add("minute", minute.ToString());
            String postStr = buildQueryStr(dicList);

            RongHttpClient client = new RongHttpClient(appKey, appSecret, InterfaceUrl.addChatroomBlockUserUrl, postStr, format);

            return client.ExecutePost();
        }

        /// <summary>
        /// 移除封禁聊天室成员
        /// </summary>
        /// <param name="userId">用户 id</param>
        /// <param name="chatroomId">聊天室 id</param>
        /// <param name="minute">禁言时长</param>
        /// <returns></returns>
        public RongHttpResult removeChatroomBlockUser(String userId, String chatroomId, FormatType format = null) {
            Dictionary<String, Object> dicList = new Dictionary<String, Object>();
            dicList.Add("userId", userId);
            dicList.Add("chatroomId", chatroomId);
            String postStr = buildQueryStr(dicList);

            RongHttpClient client = new RongHttpClient(appKey, appSecret, InterfaceUrl.removeChatroomBlockUserUrl, postStr, format);

            return client.ExecutePost();
        }

        /// <summary>
        /// 查询被封禁聊天室成员
        /// </summary>
        /// <param name="userId">用户 id</param>
        /// <param name="chatroomId">聊天室 id</param>
        /// <param name="minute">禁言时长</param>
        /// <returns></returns>
        public RongHttpResult listChatroomBlockUser(String chatroomId, FormatType format = null) {
            Dictionary<String, Object> dicList = new Dictionary<String, Object>();
            dicList.Add("chatroomId", chatroomId);
            String postStr = buildQueryStr(dicList);

            RongHttpClient client = new RongHttpClient(appKey, appSecret, InterfaceUrl.listChatroomBlockUserUrl, postStr, format);

            return client.ExecutePost();
        }

        /// <summary>
        /// 聊天室消息停止分发
        /// </summary>
        /// <param name="chatroomId">聊天室 id</param>
        /// <returns></returns>
        public RongHttpResult stopChatroomDistribution(String chatroomId, FormatType format = null) {
            Dictionary<String, Object> dicList = new Dictionary<String, Object>();
            dicList.Add("chatroomId", chatroomId);
            String postStr = buildQueryStr(dicList);

            RongHttpClient client = new RongHttpClient(appKey, appSecret, InterfaceUrl.stopstopDistributionUrl, postStr, format);

            return client.ExecutePost();
        }

        /// <summary>
        /// 聊天室消息停止分发
        /// </summary>
        /// <param name="chatroomId">聊天室 id</param>
        /// <returns></returns>
        public RongHttpResult resumeChatroomDistribution(String chatroomId, FormatType format = null) {
            Dictionary<String, Object> dicList = new Dictionary<String, Object>();
            dicList.Add("chatroomId", chatroomId);
            String postStr = buildQueryStr(dicList);

            RongHttpClient client = new RongHttpClient(appKey, appSecret, InterfaceUrl.resumeDistributionUrl, postStr, format);

            return client.ExecutePost();
        }

        /// <summary>
        /// 消息历史记录下载地址获取 
        /// </summary>
        /// <param name="date">指定北京时间某天某小时，格式为2014010101</param>
        /// <returns></returns>
        public RongHttpResult getHistoryMsgUrl(String date, FormatType format = null) {
            Dictionary<String, Object> dicList = new Dictionary<String, Object>();
            dicList.Add("date", date);
            String postStr = buildQueryStr(dicList);

            RongHttpClient client = new RongHttpClient(appKey, appSecret, InterfaceUrl.getHistoryMsgUrl, postStr, format);

            return client.ExecutePost();
        }

        /// <summary>
        /// 消息历史记录删除
        /// </summary>
        /// <param name="date">指定北京时间某天某小时，格式为2014010101</param>
        /// <returns></returns>
        public RongHttpResult delHistoryMsg(String date, FormatType format = null) {
            Dictionary<String, Object> dicList = new Dictionary<String, Object>();
            dicList.Add("date", date);
            String postStr = buildQueryStr(dicList);

            RongHttpClient client = new RongHttpClient(appKey, appSecret, InterfaceUrl.delHistoryMsgUrl, postStr, format);

            return client.ExecutePost();
        }
    }
}
