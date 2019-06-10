using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace io.rong.models.push.tag
{
    public class TagModel
    {
        [JsonProperty(PropertyName = "userId")]
        private String userId;
        [JsonProperty(PropertyName = "userIds")]
        private String[] userIds;
        [JsonProperty(PropertyName = "tags")]
        private String[] tags;

        public string GetUserId()
        {
            return userId;
        }

        public void SetUserId(string value)
        {
            userId = value;
        }

        public string[] GetUserIds()
        {
            return userIds;
        }

        public void SetUserIds(string[] value)
        {
            userIds = value;
        }

        public string[] GetTags()
        {
            return tags;
        }

        public void SetTags(string[] value)
        {
            tags = value;
        }

        public TagModel()
        {
        }

        public TagModel(string userId, string[] tags)
        {
            this.userId = userId;
            this.tags = tags;
        }

        public TagModel(string[] userIds, string[] tags)
        {
            this.userIds = userIds;
            this.tags = tags;
        }
    }
}
