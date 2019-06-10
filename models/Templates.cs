using io.rong.util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.models
{
    public class Templates

    {
        /**
	  * 发送人用户 Id。（必传）
	  * */
        [JsonProperty(PropertyName = "fromUserId")]
        private String fromUserId;
        /**
         * 接收用户 Id，提供多个本参数可以实现向多人发送消息，上限为 1000 人。（必传）
         **/
        [JsonProperty(PropertyName = "toUserId")]
        private String[] toUserId;
        /**
         *发送消息内容，内容中定义标识通过 values 中设置的标识位内容进行替换，参考融云消息类型表.示例说明；如果 objectName 为自定义消息类型，该参数可自定义格式。（必传）
         * */
        [JsonProperty(PropertyName = "content")]
        private String content;
        /**
         *
         */
        [JsonProperty(PropertyName = "values")]
        private List<Dictionary<String, String>> values;
        // 接收用户 Id，提供多个本参数可以实现向多人发送消息，上限为 1000 人。（必传）
        [JsonProperty(PropertyName = "objectName")]
        private String objectName;
        // 定义显示的 Push 内容，如果 objectName 为融云内置消息类型时，则发送后用户一定会收到 Push 信息。如果为自定义消息，定义显示的 Push 内容，内容中定义标识通过 values 中设置的标识位内容进行替换。如消息类型为自定义不需要 Push 通知，则对应数组传空值即可。（必传）
        [JsonProperty(PropertyName = "pushContent")]
        private String[] pushContent;
        // 针对 iOS 平台为 Push 通知时附加到 payload 中，Android 客户端收到推送消息时对应字段名为 pushData。如不需要 Push 功能对应数组传空值即可。（可选）
        [JsonProperty(PropertyName = "pushData")]
        private String[] pushData;
        // 是否过滤发送人黑名单列表，0 为不过滤、 1 为过滤，默认为 0 不过滤。（可选）

        [JsonProperty(PropertyName = "verifyBlacklist")]
        private int verifyBlacklist;
        [JsonProperty(PropertyName = "contentAvailable")]
        private int contentAvailable;

        public Templates()
        {
        }

        public Templates(String fromUserId, String[] toUserId, String content, List<Dictionary<String, String>> values, String objectName, String[] pushContent, String[] pushData, int verifyBlacklist)
        {
            this.fromUserId = fromUserId;
            this.toUserId = toUserId;
            this.content = content;
            this.values = values;
            this.objectName = objectName;
            this.pushContent = pushContent;
            this.pushData = pushData;
            this.verifyBlacklist = verifyBlacklist;
        }
        [JsonIgnore]
        public string FromUserId { get => fromUserId; set => fromUserId = value; }
        [JsonIgnore]
        public string[] ToUserId { get => toUserId; set => toUserId = value; }
        [JsonIgnore]
        public string Content { get => content; set => content = value; }
        [JsonIgnore]
        public List<Dictionary<string, string>> Values { get => values; set => values = value; }
        [JsonIgnore]
        public string ObjectName { get => objectName; set => objectName = value; }
        [JsonIgnore]
        public string[] PushContent { get => pushContent; set => pushContent = value; }
        [JsonIgnore]
        public string[] PushData { get => pushData; set => pushData = value; }
        [JsonIgnore]
        public int VerifyBlacklist { get => verifyBlacklist; set => verifyBlacklist = value; }
        [JsonIgnore]
        public int ContentAvailable { get => contentAvailable; set => contentAvailable = value; }

        override
        public String ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
