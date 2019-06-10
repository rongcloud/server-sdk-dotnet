using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.models.response
{
    public class UserList

    {
        /**
         * 返回码，200 为正常。
         *
         */
        [JsonProperty(PropertyName = "code")]
        private int code;
        /**
         * 黑名单用户列表
         */
        [JsonProperty(PropertyName = "users")]
        private String[] users;

        [JsonIgnore]
        public int Code { get => code; set => code = value; }
        [JsonIgnore]
        public string[] Users { get => users; set => users = value; }

        public UserList(int code, String[] users)
        {
            this.code = code;
            this.users = users;
        }

        public String[] getUsers()
        {
            return this.users;
        }

        public void setUsers(String[] users)
        {
            this.users = users;
        }

        public int getCode()
        {
            return this.code;
        }

        public void setCode(int code)
        {
            this.code = code;
        }

        override
        public String ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
