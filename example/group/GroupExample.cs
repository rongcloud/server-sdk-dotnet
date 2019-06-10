using io.rong.methods.group;
using io.rong.models;
using io.rong.models.group;
using io.rong.models.response;
using System;

namespace io.rong.example.group
{
    /**
     *
     * 群组服务示例
     *
     */
    class GroupExample
    {
        /**
         * 此处替换成您的appKey
         * */
        private static readonly String appKey = "pwe86ga5pwrj6";
        /**
         * 此处替换成您的appSecret
         * */
        private static readonly String appSecret = "rb8fWki1mJcK";
        /**
         * 自定义api地址
         * */
        private static readonly String api = "http://api.cn.ronghub.com";

        /**
         * 本地调用测试
         * 
         * @param args
         * @throws Exception
         */
        static void Main(String[] args)
        {

            RongCloud rongCloud = RongCloud.GetInstance(appKey, appSecret);
            //自定义 api 地址方式
            // RongCloud rongCloud = RongCloud.getInstance(appKey, appSecret,api);

            Group Group = rongCloud.group;

            /**
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/group/group.html#create
             *
             * 创建群组方法
             *
             */
            GroupMember[] members = { new GroupMember() { Id = "Vu-oC0_LQ6kgPqltm_zYtI" }, new GroupMember() { Id = "uPj70HUrRSUk-ixtt7iIGc" } };


            GroupModel group = new GroupModel()
            {
                Id = "goupId1.net",
                Members = members,
                Name = "groupName"
            };

            Result groupCreateResult = (Result)Group.Create(group);
            Console.WriteLine("group create result:  " + groupCreateResult.ToString());

            /**
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/group/group.html#sync
             *
             * 	同步用户所属群组方法
             */

            GroupModel group1 = new GroupModel()
            {
                Id = "goupId1.net",
                Name = "groupName1"
            };

            GroupModel group2 = new GroupModel()
            {
                Id = "goupId2.net",
                Name = "groupName2"
            };

            GroupModel[] groups = { group1, group2 };
            UserGroup user = new UserGroup()
            {
                Id = "Vu-oC0_LQ6kgPqltm_zYtI",
                Groups = groups
            };


            Result syncResult = (Result)Group.Sync(user);
            Console.WriteLine("group sync:  " + syncResult.ToString());

            Console.WriteLine("get group users:" + Group.Get(new GroupModel(){Id = "goupId1.NET"}).ToString());


            /**
             *
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/group/group.html#refresh
             *  刷新群组信息方法
             */
            //GroupMember[] members = {new GroupMember().setId("ghJiu7H1"),new GroupMember().setId("ghJiu7H2")};

            group = new GroupModel()
            {
                Id = "goupId1.NET",
                Name = "groupName"
            };

            Result refreshResult = (Result)Group.Update(group);
            Console.WriteLine("refresh:  " + refreshResult.ToString());

            /**
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/group/group.html#join
             *
             * 邀请用户加入群组
             *
             */
            group = new GroupModel()
            {
                Id = "goupId1.NET",
                Members = members,
                Name = "groupName"
            };

            Result groupInviteResult = (Result)rongCloud.group.Invite(group);
            Console.WriteLine("invite:  " + groupInviteResult.ToString());

            Console.WriteLine("get group users:" + Group.Get(new GroupModel() { Id = "goupId1.NET" }).ToString());


            /**
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/group/group.html#join
             *
             * 用户加入指定群组
             *
             */
            group = new GroupModel()
            {
                Id = "goupId1.NET",
                Members = members,
                Name = "groupName"
            };

            Result groupJoinResult = (Result)Group.Join(group);
            Console.WriteLine("join:  " + groupJoinResult.ToString());
            Console.WriteLine("get group users:" + Group.Get(new GroupModel() { Id = "goupId1.NET" }).ToString());


            /**
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/group/group.html#getMembers
             *
             * 查询群成员方法
             *
             */
            group = new GroupModel()
            {
                Id = "goupId1.NET"
            };
            GroupUserQueryResult getMemberesult = Group.Get(group);
            Console.WriteLine("group getMember:  " + getMemberesult.ToString());

            /**
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/group/group.html#quit
             *
             * 退出群组
             *
             */
            group = new GroupModel()
            {
                Id = "goupId1.NET",
                Members = new GroupMember[]{  new GroupMember() { Id = "uPj70HUrRSUk-ixtt7iIGc" } },
                Name = "groupName"
            };

            Result groupQuitResult = (Result)Group.Quit(group);
            Console.WriteLine("quit:  " + groupQuitResult.ToString());
            Console.WriteLine("get group users:" + Group.Get(new GroupModel() { Id = "goupId1.NET" }).ToString());


            /**
             *
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/group/group.html#dismiss
             *
             * 解散群组
             *
             */
            members = new GroupMember[]{ new GroupMember() {
                Id = "Vu-oC0_LQ6kgPqltm_zYtI"
            } };

            group = new GroupModel()
            {
                Id = "goupId1.NET",
                Members = members
            };

            Result groupDismissResult = (Result)Group.Dismiss(group);
            Console.WriteLine("dismiss:  " + groupDismissResult.ToString());
            Console.ReadLine();
        }

    }
}