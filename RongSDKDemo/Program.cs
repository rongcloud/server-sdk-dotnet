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
            //retstr=RongCloudServer.GetToken("e0x9wycfx7flq", "TESTSECRET", "232424", "xugang", "http://www.qqw21.com/article/UploadPic/2012-11/201211259378560.jpg");
            //String retstr = RongCloudServer.GetToken("z3v5yqkbv8v30", "aL1VbnQdzNII8v", "232424", "xugang", "http://www.qqw21.com/article/UploadPic/2012-11/201211259378560.jpg");

            //retstr = RongCloudServer.JoinGroup("e0x9wycfx7flq", "TESTSECRET", "232424", "group001","wsw");

            //string[] array = { "group[group004]=name"};

            //retstr = RongCloudServer.syncGroup("e0x9wycfx7flq", "TESTSECRET", "42424",array );

            //retstr = RongCloudServer.DismissGroup("e0x9wycfx7flq", "TESTSECRET", "42424", "group0013");

           retstr = RongCloudServer.PublishMessage("e0x9wycfx7flq", "TESTSECRET", "2191", "2191", "RC:TxtMsg", "{\"content\":\"c#hello\"}");

            //retstr = RongCloudServer.BroadcastMessage("e0x9wycfx7flq", "TESTSECRET", "2191", "RC:TxtMsg", "{\"content\":\"c#hello\"}");

            //retstr = RongCloudServer.JoinGroup("e0x9wycfx7flq", "TESTSECRET", "423424", "dwef", "dwef");

           // string[] array = { "chatroom[id10001]=name1001"};
            //string[] array = { "chatroomId=id1001" };

            //retstr = RongCloudServer.CreateChatroom("e0x9wycfx7flq", "TESTSECRET", array);
            //retstr = RongCloudServer.DestroyChatroom("e0x9wycfx7flq", "TESTSECRET", array);

            //string[] aaa={"group002"};
            //retstr = RongCloudServer.queryChatroom("e0x9wycfx7flq", "TESTSECRET",aaa);
            
            Console.WriteLine(retstr);


        }
    }
}
