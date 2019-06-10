using io.rong.models;
using io.rong.models.response;
using io.rong.models.push;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using io.rong.methods.user;
using io.rong.methods.user.block;

namespace io.rong.example.user
{
    public class BlockExample

    {
        /**
         * 此处替换成您的appKey
         * */
        private static readonly String appKey = "appKey";
        /**
         * 此处替换成您的appSecret
         * */
        private static readonly String appSecret = "appSecret";
        /**
         * 自定义api地址
         * */
        private static readonly String api = "http://api.cn.ronghub.com";

        static void Main(String[] args)
        {

            RongCloud rongCloud = RongCloud.GetInstance(appKey, appSecret);
            //自定义 api 地址方式
            // RongCloud rongCloud = RongCloud.getInstance(appKey, appSecret,api);

            Block block = rongCloud.User.block;

            /**
             *
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/user/block.html#add
             * 解除用户封禁
             *
             */
            UserModel user = new UserModel()
            {
                Id = "hkjo09h",
                Minute = 1000
            };

            Result addBlockResult = (ResponseResult)block.Add(user);
            Console.WriteLine("userAddBlock:  " + addBlockResult.ToString());

            /**
             *
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/user/block.html#remove
             * 解除用户封禁
             *
             */
            ResponseResult unBlockResult = (ResponseResult)block.Remove(user.Id);
            Console.WriteLine("unBlock:  " + unBlockResult.ToString());

            /**
             *
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/user/block.html#getList
             * 获取被封禁用户
             *
             */
            BlockUserResult blockResult = (BlockUserResult)block.GetList();
            Console.Write("queryBlock:  " + blockResult.ToString());

            Console.ReadLine();

        }
    }
}
