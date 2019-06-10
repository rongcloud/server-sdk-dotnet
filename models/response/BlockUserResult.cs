using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.models.response
{
    class BlockUserResult : Result
    {
        // 被封禁用户列表。
        [JsonProperty(PropertyName = "users")]
        List<BlockUsers> users;

        [JsonIgnore]
        public List<BlockUsers> Users { get => users; set => users = value; }

        public BlockUserResult(int code, String errorMessage, List<BlockUsers> users) : base(code, errorMessage)
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
