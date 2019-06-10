using io.rong.methods.group;
using io.rong.methods.group.gap;
using io.rong.models;
using io.rong.models.group;
using io.rong.models.response;
using System;

namespace io.rong.example.group
{
    /**
     *
     * 群组禁言例子
     *
     */
    public class GagExample

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
         *
         * @throws Exception
         */
        static void Main(String[] args)
        {
            RongCloud rongCloud = RongCloud.GetInstance(appKey, appSecret);
            //自定义 api 地址方式
            // RongCloud rongCloud = RongCloud.getInstance(appKey, appSecret,api);

            Gag gag = rongCloud.Group.Gag;
            Group Group = rongCloud.Group;

            /**
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/group/gag.html#add
             * 添加禁言群成员方法
             */

            GroupMember[] members = { new GroupMember() { Id = "Vu-oC0_LQ6kgPqltm_zYtI" }, new GroupMember() { Id = "uPj70HUrRSUk-ixtt7iIGc" } };

            GroupModel group = new GroupModel()
            {
                Id = "goupId1.NET",
                Members = members,
                Name = "groupName",
                Minute = 5
            };

            Result groupCreateResult = (Result)Group.Create(group);
            Console.WriteLine("group create result:  " + groupCreateResult.ToString());
            Console.WriteLine("get group users:" + Group.Get(new GroupModel() { Id = "goupId1.NET" }).ToString());


            Result result = gag.Add(group);
            Console.WriteLine("group.gag.add:  " + result.ToString());

            /**
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/group/gag.html#getList
             * 查询被禁言群成员
             */
            ListGagGroupUserResult groupLisGagUserResult = gag.GetList("goupId1.NET");
            Console.WriteLine("group.gag.getList:  " + groupLisGagUserResult.ToString());

            /**
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/group/gag.html#remove
             * 移除禁言群成员
             */
            group = new GroupModel()
            {
                Id = "goupId1.NET",
                Members = members
            };


            Result groupRollBackGagUserResult = gag.Remove(group);
            Console.WriteLine("group.gag.remove:  " + groupRollBackGagUserResult.ToString());
            Console.ReadLine();

        }
    }
}
