using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.models.response
{
    class GroupUserQueryResult : Result
    {

        // 群成员用户Id。
        [JsonProperty(PropertyName = "id")]
        String id;
        // 群成员列表。
        [JsonProperty(PropertyName = "members")]
        List<GroupUser> members;

        [JsonIgnore]
        public string Id { get => id; set => id = value; }
        [JsonIgnore]
        public List<GroupUser> Members { get => members; set => members = value; }

        public GroupUserQueryResult()
        {

        }
        public GroupUserQueryResult(int code, String msg, String id, List<GroupUser> members) : base(code, msg)
        {
            this.id = id;
            this.members = members;
        }

        public GroupUserQueryResult(int code, List<GroupUser> members): base(code, "")
        {
            this.members = members;
        }


        public GroupUserQueryResult(String id, List<GroupUser> members)
        {
            this.id = id;
            this.members = members;
        }

        override
        public String ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
