using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using io.rong.methods.user;
using io.rong.models;
using io.rong.models.response;
using io.rong.models.user;

namespace io.rong.example.user
{
    class UserExample
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

        static void Main(String[] args)
        {

            RongCloud rongCloud = RongCloud.GetInstance(appKey, appSecret);
            //自定义 api 地址方式
            // RongCloud rongCloud = RongCloud.getInstance(appKey, appSecret,api);
            User User = rongCloud.user;

            /**
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/user/user.html#register
             *
             * 注册用户，生成用户在融云的唯一身份标识 Token
             */
            UserModel user = new UserModel
            {
                Id = "注册用户，生成用户在融云的唯一身份标识 Token注册用户，生成用户在融云的唯一身份标识 Token注册用户，生成用户在融云的唯一身份标识 Token注册用户，生成用户在融云的唯一身份标识 Token注册用户，生成用户在融云的唯一身份标识 Token注册用户，生成用户在融云的唯一身份标识 Token注册用户，生成用户在融云的唯一身份标识 Token注册用户，生成用户在融云的唯一身份标识 Token注册用户，生成用户在融云的唯一身份标识 Token注册用户，生成用户在融云的唯一身份标识 Token注册用户，生成用户在融云的唯一身份标识 Token注册用户，生成用户在融云的唯一身份标识 Token注册用户，生成用户在融云的唯一身份标识 Token注册用户，生成用户在融云的唯一身份标识 Token注册用户，生成用户在融云的唯一身份标识 Token注册用户，生成用户在融云的唯一身份标识 Token注册用户，生成用户在融云的唯一身份标识 Token注册用户，生成用户在融云的唯一身份标识 Token注册用户，生成用户在融云的唯一身份标识 Token注册用户，生成用户在融云的唯一身份标识 Token注册用户，生成用户在融云的唯一身份标识 Token注册用户，生成用户在融云的唯一身份标识 Token注册用户，生成用户在融云的唯一身份标识 Token注册用户，生成用户在融云的唯一身份标识 Token注册用户，生成用户在融云的唯一身份标识 Token注册用户，生成用户在融云的唯一身份标识 Token注册用户，生成用户在融云的唯一身份标识 Token注册用户，生成用户在融云的唯一身份标识 Token注册用户，生成用户在融云的唯一身份标识 Token注册用户，生成用户在融云的唯一身份标识 Token",
                Name = "username",
                Portrait = "http://www.rongcloud.cn/images/logo.png"
            };

            TokenResult result = User.Register(user);
            Console.WriteLine("getToken:  " + result.ToString());

            /**
             *
             * API 文档: http://www.rongcloud.cn/docs/server_sdk_api/user/user.html#refresh
             *
             * 刷新用户信息方法
             */
            Result refreshResult = User.Update(user);
            Console.WriteLine("refresh:  " + refreshResult.ToString());

            Console.ReadLine();

        }
    }
}
