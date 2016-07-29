using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace io.rong {
    class InterfaceUrl {
        public static String server_addr = "http://api.cn.ronghub.com";

        // 用户服务
        public static String getTokenUrl = server_addr + "/user/getToken";
        public static String refreshInfoUrl = server_addr + "/user/refresh";
        public static String checkOnlineUrl = server_addr + "/user/checkOnline";
        public static String blockUserUrl = server_addr + "/user/block";
        public static String unblockUserUrl = server_addr + "/user/unblock";
        public static String getBlockUserUrl = server_addr + "/user/block/query";
        public static String addToBlacklistUrl = server_addr + "/user/blacklist/add";
        public static String removeFromBlacklistUrl = server_addr + "/user/blacklist/remove";
        public static String getBlacklistUrl = server_addr + "/user/blacklist/query";

        // 消息发送服务
        public static String sendMsgUrl = server_addr + "/message/private/publish";
        public static String sendSysMsgUrl = server_addr + "/message/system/publish";
        public static String sendGrmMsgUrl = server_addr + "/message/group/publish";
        public static String sendDissMsgUrl = server_addr + "/message/discussion/publish";
        public static String sendCtrmMsgUrl = server_addr + "/message/chatroom/publish";
        public static String sendBroMsgUrl = server_addr + "/message/broadcast";
        public static String sendTemplateMsgUrl = server_addr + "/message/private/publish_template";
        public static String sendSysTemplateMsgUrl = server_addr + "/message/system/publish_template";

        // 敏感词服务
        public static String addWordFilterUrl = server_addr + "/wordfilter/add";
        public static String removeWordFilterUrl = server_addr + "/wordfilter/delete";
        public static String listWordFilterUrl = server_addr + "/wordfilter/list";

        // 群组服务
        public static String createGroupUrl = server_addr + "/group/create";
        public static String joinGroupUrl = server_addr + "/group/join";
        public static String quitGroupUrl = server_addr + "/group/quit";
        public static String dismissUrl = server_addr + "/group/dismiss";
        public static String syncGroupUrl = server_addr + "/group/sync";
        public static String refreshGroupUrl = server_addr + "/group/refresh";
        public static String queryGroupUrl = server_addr + "/group/user/query";
        // 群组成员禁言服务
        public static String addGroupGagUrl = server_addr + "/group/user/gag/add";
        public static String removeGroupGagUrl = server_addr + "/group/user/gag/rollback";
        public static String listGroupGagUrl = server_addr + "/group/user/gag/list";

        // 聊天室服务
        public static String createChatroomUrl = server_addr + "/chatroom/create";
        public static String destroyChatroomUrl = server_addr + "/chatroom/destroy";
        public static String queryChatroomUrl = server_addr + "/chatroom/query";
        public static String joinChatroomUrl = server_addr + "/chatroom/join";
        public static String queryChatroomUserUrl = server_addr + "/chatroom/user/query";
        // 聊天室成员禁言服务
        public static String addChatroomGagUrl = server_addr + "/chatroom/user/gag/add";
        public static String removeChatroomGagUrl = server_addr + "/chatroom/user/gag/rollback";
        public static String listChatroomGagUrl = server_addr + "/chatroom/user/gag/list";
        // 聊天室封禁服务
        public static String addChatroomBlockUserUrl = server_addr + "/chatroom/user/block/add";
        public static String removeChatroomBlockUserUrl = server_addr + "/chatroom/user/block/rollback";
        public static String listChatroomBlockUserUrl = server_addr + "/chatroom/user/block/list";
        // 聊天室消息分发服务
        public static String stopstopDistributionUrl = server_addr + "/chatroom/message/stopDistribution";
        public static String resumeDistributionUrl = server_addr + "/chatroom/message/resumeDistribution";

        //public static String getTokenUrl = server_addr + "/user/getToken.xml";
        //public static String joinGroupUrl = server_addr + "/group/join.xml";
        //public static String quitGroupUrl = server_addr + "/group/quit.xml";
        //public static String dismissUrl = server_addr + "/group/dismiss.xml";
        //public static String syncGroupUrl = server_addr + "/group/sync.xml";
        //public static String SendMsgUrl = server_addr + "/message/publish.xml";
        //public static String sendSysMsgUrl = server_addr + "/message/system/publish.xml";
        //public static String broadcastUrl = server_addr + "/message/broadcast.xml";
        //public static String createChatroomUrl = server_addr + "/chatroom/create.xml";
        //public static String destroyChatroomUrl = server_addr + "/chatroom/destroy.xml";
        //public static String queryChatroomUrl = server_addr + "/chatroom/query.xml";

    }
}
