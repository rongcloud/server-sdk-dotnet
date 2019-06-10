using io.rong.models.user;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.models.response
{
    class WhiteListResult : Result
    {
        [JsonProperty(PropertyName = "members")]
        private UserModel[] members;

        [JsonIgnore]
        internal UserModel[] Members { get => members; set => members = value; }

        public WhiteListResult(int code, String msg) :base(code, msg)
        {

        }

        public WhiteListResult(int code, String msg, UserModel[] members) : base(code, msg)
        {
            this.members = members;
        }

        public WhiteListResult(UserModel[] members)
        {
            this.members = members;
        }

        public UserModel[] getMembers()
        {
            return this.members;
        }

        public void setMembers(UserModel[] members)
        {
            this.members = members;
        }

        override
        public String ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
