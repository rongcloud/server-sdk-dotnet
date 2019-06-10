using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.models.group
{

    public class GroupMember
    {
        /**
         * 群组成员Id。
         * */
        [JsonProperty(PropertyName = "id")]
        private String id;
        /**
         * 群组ID
         * */
        [JsonProperty(PropertyName = "goupId1.NET")]
        private String groupId;
        /**
         * 禁言时间
         * */
        [JsonProperty(PropertyName = "munite")]
        private int munite;

        public GroupMember() : base()
        {
        }

        public GroupMember(String id, String groupId, int munite)
        {
            this.id = id;
            this.groupId = groupId;
            this.munite = munite;
        }
        [JsonIgnore]
        public string Id { get => id; set => id = value; }
        [JsonIgnore]
        public string GroupId { get => groupId; set => groupId = value; }
        [JsonIgnore]
        public int Munite { get => munite; set => munite = value; }

        override
    public String ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }

    }
}
