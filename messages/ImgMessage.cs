using io.rong.messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.message
{

    /**
     *
     * 图片消息。
     *
     */
    class ImgMessage : BaseMessage
    {
        [JsonProperty(PropertyName = "content")]
        private String content = "";
        [JsonProperty(PropertyName = "extra")]
        private String extra = "";
        [JsonProperty(PropertyName = "imageUri")]
        private String imageUri = "";
        private static readonly String TYPE = "RC:ImgMsg";

        [JsonIgnore]
        public string Content { get => content; set => content = value; }
        [JsonIgnore]
        public string Extra { get => extra; set => extra = value; }
        [JsonIgnore]
        public string ImageUri { get => imageUri; set => imageUri = value; }

        public static string TYPE1=> TYPE;

        public ImgMessage(String content, String extra, String imageUri)
        {
            this.content = content;
            this.extra = extra;
            this.imageUri = imageUri;
        }
        override
        public String GetType()
        {
            return TYPE;
        }

        override
        public String ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}