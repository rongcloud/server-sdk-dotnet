using io.rong.models.push;
using Newtonsoft.Json;
using System;

namespace io.rong.models.response
{
    public class BlackListResult : Result

    {
        /**
         * 黑名单用户列表
         */
        [JsonProperty(PropertyName = "users")]
        UserModel[] users;

        [JsonIgnore]
        public UserModel[] Users { get => users; set => users = value; }

        public BlackListResult(int code, String msg, UserModel[] users) : base(code, msg)
        {
            this.users = users;
        }


        /**
         * 获取users
         *
         * @return User[]
         */
        public UserModel[] getUsers()
        {
            return this.users;
        }
        /**
         * 设置users
         *
         */
        public void setUsers(UserModel[] users)
        {
            this.users = users;
        }

        override
        public String ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
