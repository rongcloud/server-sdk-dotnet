using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.messages
{
    /**
     *
     * 自定义消息
     *
     */
    class CustomTxtMessage : BaseMessage
    {
        [JsonProperty(PropertyName = "content")]
        private String content = "";
        private static readonly String TYPE = "RC:TxtMsg";

        [JsonIgnore]
        public string Content { get => content; set => content = value; }

        public CustomTxtMessage(String content)
        {
            this.content = content;
        }
        override
        public String GetType()
        {
            return TYPE;
        }

        /**
         * 获取自定义消息内容。
         *
         * @return String
         */
        public String getContent()
        {
            return content;
        }

        /**
         * @param content 设置自定义消息内容。
         *
         *
         */
        public void setContent(String content)
        {
            this.content = content;
        }

        override
        public String ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}