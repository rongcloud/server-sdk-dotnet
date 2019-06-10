using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.models
{
    class BlockUsers
    {
        // 被封禁用户 ID。
        [JsonProperty(PropertyName = "id")]
        String id;
        // 封禁结束时间。
        [JsonProperty(PropertyName = "blockEndTime")]
        String blockEndTime;

        [JsonIgnore]
        public string Id { get => id; set => id = value; }
        [JsonIgnore]
        public string BlockEndTime { get => blockEndTime; set => blockEndTime = value; }

        public BlockUsers(String id, String blockEndTime)
        {
            this.id = id;
            this.blockEndTime = blockEndTime;
        }

        override
         public String ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
