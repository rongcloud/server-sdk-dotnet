using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.models.response
{
    public class GroupUser

    {
        // 用户 Id。
        [JsonProperty(PropertyName = "id")]
        String id;

        public GroupUser(String id)
        {
            this.id = id;
        }

        [JsonIgnore]
        public string Id { get => id; set => id = value; }

        override
        public String ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
