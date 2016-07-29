using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using io.rong;
using io.rong.util;
using io.rong.models;

namespace RongSDKDemo {
    class Program {
        static void Main(string[] args) {
            RongHttpResult retstr = null;
            String appKey = "uwd1c0sxdlx91";
            String appSecret = "hhetmryhVm";
            RongCloudServer rongServer = RongCloudServer.getInstance(appKey, appSecret);

            String userId = "232424";
            
            retstr = rongServer.getToken(userId, "xugang", "http://www.qqw21.com/article/UploadPic/2012-11/201211259378560.jpg");
            Console.WriteLine("getToken: " + retstr.toString() + retstr.getHttpCode() + retstr.getResult());
            Console.ReadKey();

            retstr = rongServer.refreshUserInfo(userId, "ceshi", "http://www.qqw21.com/article/UploadPic/2012-11/201211259378560.jpg");
            Console.WriteLine("refreshUserInfo: " + retstr.toString());
            Console.ReadKey();

            retstr = rongServer.checkOnline(userId);
            Console.WriteLine("checkOnline: " + retstr.toString());

            retstr = rongServer.blockUser(userId, 2);
            Console.WriteLine("blockUser: " + retstr.toString());
            Console.ReadKey();

            retstr = rongServer.getBlockList();
            Console.WriteLine("getBlockList: " + retstr.toString());

            retstr = rongServer.unblockUser(userId);
            Console.WriteLine("unblockUser: " + retstr.toString());
            retstr = rongServer.getBlockList();
            Console.WriteLine("getBlockList: " + retstr.toString());
            Console.ReadKey();

            retstr = rongServer.addToBlackList(userId, "1");
            Console.WriteLine("addToBlackList: " + retstr.toString());
            Console.WriteLine("getBlackList: " + rongServer.getBlackList(userId).toString());
            retstr = rongServer.removeFromBlackList(userId, "1");
            Console.WriteLine("removeFromBlackList: " + retstr.toString());
            Console.WriteLine("getBlackList: " + rongServer.getBlackList(userId).toString());
            Console.ReadKey();

            Console.WriteLine("addWordFilter: " + rongServer.addWordFilter("SB").toString());
            Console.WriteLine("addListWordFilter: " + rongServer.listWordFilter().toString());
            Console.WriteLine("removeWordFilter: " + rongServer.removeWordFilter("SB").toString());
            Console.WriteLine("addListWordFilter: " + rongServer.listWordFilter().toString());
            Console.ReadKey();

            Console.WriteLine("createGroup: " + rongServer.createGroup(userId, "group1", "群组1").toString());
            Console.WriteLine("queryGroup: " + rongServer.queryGroupUrl("group1").toString());
            Console.WriteLine("refreshGroup: " + rongServer.refreshGroup("group1", "群组2").toString());
            Console.WriteLine("jsonGroup: " + rongServer.joinGroup(new List<string> { "1", "2" }, "group1", "群组2").toString());
            Console.WriteLine("queryGroup: " + rongServer.queryGroupUrl("group1").toString());
            Console.WriteLine("quitGroup: " + rongServer.quitGroup(userId, "group1").toString());
            string[] arrId = { "group001", "group002", "group003" };
            string[] arrName = { "测试 01", "测试 02", "测试 03" };
            Console.WriteLine("syncGroup: " + rongServer.syncGroup(userId, arrId, arrName).toString());
            Console.WriteLine("queryGroup: " + rongServer.queryGroupUrl("group1").toString());
            Console.ReadKey();

            Console.WriteLine("addGroupGag: " + rongServer.addGroupGagUser("1", "group1", 2).toString());
            Console.WriteLine("listGroupGag: " + rongServer.listGroupGagUser("group1").toString());
            Console.WriteLine("removeGroupGag: " + rongServer.removeGroupGagUser("1", "group1").toString());
            Console.WriteLine("listGroupGag: " + rongServer.listGroupGagUser("group1").toString());
            Console.ReadKey();

            Console.WriteLine("createChatroom: " + rongServer.createChatroom(new String[] { "chatroom1", "chatroom2" },
                new String[] { "聊天室1", "聊天室2" }).toString());
            Console.WriteLine("queryChatroomInfo: " + rongServer.queryChatroom(new String[] { "chatroom1", "chatroom2" }).toString());
            Console.WriteLine("joinChatroom: " + rongServer.joinChatroom(new List<string> { userId, "1" }, "chatroom1").toString());
            Console.WriteLine("queryChatroomUser: " + rongServer.queryChatroomUser("chatroom1", 100, true).toString());
            Console.ReadKey();

            Console.WriteLine("addChatroomGag: " + rongServer.addChatroomGagUser(userId, "chatroom1", 2).toString());
            Console.WriteLine("listChatroomGag: " + rongServer.listChatroomGagUser("chatroom1").toString());
            Console.WriteLine("removeChatroomGag: " + rongServer.removeChatroomGagUser(userId, "chatroom1").toString());
            Console.WriteLine("listChatroomGag: " + rongServer.listChatroomGagUser("chatroom1").toString());
            Console.WriteLine("destroyChatroom: " + rongServer.destroyChatroom("chatroom1").toString());
            Console.ReadKey();

            Console.WriteLine("addChatroomBlock: " + rongServer.addChatroomBlockUser(userId, "chatroom1", 2).toString());
            Console.WriteLine("listChatroomBlock: " + rongServer.listChatroomBlockUser("chatroom1").toString());
            Console.WriteLine("removeChatroomBlock: " + rongServer.removeChatroomBlockUser(userId, "chatroom1").toString());
            Console.WriteLine("listChatroomBlock: " + rongServer.listChatroomBlockUser("chatroom1").toString());
            Console.ReadKey();

            Console.WriteLine("stopDistribution: " + rongServer.stopChatroomDistribution("chatroom1").toString());
            Console.WriteLine("resumeDistribution: " + rongServer.resumeChatroomDistribution("chatroom1").toString());
            Console.ReadKey();

            Message msg = new TxtMessage("测试消息");
            UserInfo user = new UserInfo("123", "测试123");
            msg.setUser(user);
            Console.WriteLine("SendMsg: " + rongServer.publishMessage("123", new List<string> { userId }, msg).toString());
            Console.ReadKey();

            List<String> toUserIds = new List<string>() { "1", "2" };
            Message msg1 = new TxtMessage("{c}{d}{e}");
            List<Dictionary<String, String>> values = new List<Dictionary<string, string>>();
            Dictionary<string, string> dicList1 = new Dictionary<string, string>();
            dicList1.Add("{c}", "1");
            dicList1.Add("{d}", "2");
            dicList1.Add("{e}", "3");

            Dictionary<string, string> dicList2 = new Dictionary<string, string>();
            dicList2.Add("{c}", "4");
            dicList2.Add("{d}", "5");
            dicList2.Add("{e}", "6");

            values.Add(dicList1);
            values.Add(dicList2);

            Console.WriteLine("publishTemplateMsg: " + rongServer.publishTemplateMsg(userId, toUserIds, msg1, values, new List<string>() { "push{c}", "push{c}" }, new List<string>() { "pushd", "pushd" }, 0).toString());
            Console.WriteLine("publishSysTemplateMsg: " + rongServer.publishSysTemplateMsg(userId, toUserIds, msg1, values, new List<string>() { "push{c}", "push{c}" }, new List<string>() { "pushd", "pushd" }).toString());
            Console.ReadKey();

            Console.WriteLine("接口测试结束！");
            Console.ReadKey();
        }
    }
}
