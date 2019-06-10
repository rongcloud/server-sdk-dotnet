using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.messages
{

    /**
     *
     * 提示条（小灰条）通知消息。此类型消息没有 Push 通知。
     *
     */
    class InfoNtfMessage : BaseMessage
    {
        [JsonProperty(PropertyName = "content")]
        private String message = "";
        [JsonProperty(PropertyName = "content")]
        private String extra = "";
        private static readonly String TYPE = "RC:InfoNtf";

        [JsonIgnore]
        public string Message { get => message; set => message = value; }
        [JsonIgnore]
        public string Extra { get => extra; set => extra = value; }

        public static string TYPE1 => TYPE;

        public InfoNtfMessage(String message, String extra)
        {
            this.message = message;
            this.extra = extra;
        }
        override
        public String GetType()
        {
            return TYPE;
        }


        /**
         * @param extra 设置附加信息(如果开发者自己需要，可以自己在 App 端进行解析)。
         *
         *
         */
        public void setExtra(String extra)
        {
            this.extra = extra;
        }

        override
        public String ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}