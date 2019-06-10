using io.rong.util;
using io.rong.models.group;
using io.rong.models;
using io.rong.models.response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace io.rong.methods.group.gap
{
    /**
     * 群组成员禁言服务
     * docs : http://www.rongcloud.cn/docs/server.html#group_user_gag
     *
     * */
    class Gag
    {
        private static readonly Encoding UTF8 = Encoding.UTF8;
        private static readonly String PATH = "group/gag";
        private String appKey;
        private String appSecret;
        private RongCloud rongCloud;


        public Gag(String appKey, String appSecret)
        {
            this.appKey = appKey;
            this.appSecret = appSecret;

        }

        public string AppKey { get => appKey; set => appKey = value; }
        public string AppSecret { get => appSecret; set => appSecret = value; }
        internal RongCloud RongCloud { get => rongCloud; set => rongCloud = value; }

        /**
        * 添加禁言群成员方法（在 App 中如果不想让某一用户在群中发言时，可将此用户在群组中禁言，被禁言用户可以接收查看群组中用户聊天信息，但不能发送消息。）
        *
        * @param group:群组信息。id , munite , memberIds（必传）
        *
        * @return Result
        **/
        public Result Add(GroupModel group)
        {
            String message = CommonUtil.CheckFiled(group, PATH, CheckMethod.ADD);
            if (null != message)
            {
                return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(message);
            }

            /* message = CommonUtil.checkParam("munite",munite,PATH,CheckMethod.ADD);
             if(null != message){
                 return (Result)RongJsonUtil.JsonStringToObj(message,Result.class);
             }*/

            StringBuilder sb = new StringBuilder();
            GroupMember[] members = group.Members;
            foreach (var member in members)
            {
                sb.Append("&userId=").Append(HttpUtility.UrlEncode(member.Id.ToString(), UTF8));
            }
            sb.Append("&groupId=").Append(HttpUtility.UrlEncode(group.Id.ToString(), UTF8));
            sb.Append("&minute=").Append(HttpUtility.UrlEncode(group.Minute.ToString(), UTF8));
            String body = sb.ToString();
            if (body.IndexOf("&") == 0)
            {
                body = body.Substring(1, body.Length - 1);
            }
            String result = RongHttpClient.ExecutePost(appKey, appSecret, body,
                            rongCloud.ApiHostType.Type + "/group/user/gag/add.json", "application/x-www-form-urlencoded");

            return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.ADD, result));

        }

        /**
         * 查询被禁言群成员方法
         *
         * @param  groupId:群组Id。（必传）
         *
         * @return ListGagGroupUserResult
         **/
        public ListGagGroupUserResult GetList(String groupId)
        {
            String message = CommonUtil.CheckParam("id", groupId, PATH, CheckMethod.GETLIST);
            if (null != message)
            {
                return (ListGagGroupUserResult)RongJsonUtil.JsonStringToObj<ListGagGroupUserResult>(message);
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("&groupId=").Append(HttpUtility.UrlEncode(groupId.ToString(), UTF8));
            String body = sb.ToString();
            if (body.IndexOf("&") == 0)
            {
                body = body.Substring(1, body.Length - 1);
            }
            String result = RongHttpClient.ExecutePost(appKey, appSecret, body,
                                rongCloud.ApiHostType.Type + "/group/user/gag/list.json", "application/x-www-form-urlencoded");

            return (ListGagGroupUserResult)RongJsonUtil.JsonStringToObj<ListGagGroupUserResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.GETLIST, result));
        }

        /**
         * 移除禁言群成员方法
         *
         * @param  group:群组（必传）
         *
         * @return ResponseResult
         **/
        public Result Remove(GroupModel group)
        {
            //参数校验
            String message = CommonUtil.CheckFiled(group, PATH, CheckMethod.REMOVE);
            if (null != message)
            {
                return (ResponseResult)RongJsonUtil.JsonStringToObj<ResponseResult>(message);
            }
            StringBuilder sb = new StringBuilder();

            GroupMember[] members = group.Members;
            foreach (var member in members)
            {
                sb.Append("&userId=").Append(HttpUtility.UrlEncode(member.Id.ToString(), UTF8));
            }

            sb.Append("&groupId=").Append(HttpUtility.UrlEncode(group.Id.ToString(), UTF8));
            String body = sb.ToString();
            if (body.IndexOf("&") == 0)
            {
                body = body.Substring(1, body.Length - 1);
            }
            String result = RongHttpClient.ExecutePost(appKey, appSecret, body,
                                    rongCloud.ApiHostType.Type + "/group/user/gag/rollback.json", "application/x-www-form-urlencoded");

            return (ListGagGroupUserResult)RongJsonUtil.JsonStringToObj<ListGagGroupUserResult>(CommonUtil.GetResponseByCode(PATH, CheckMethod.REMOVE, result));
        }
    }
}