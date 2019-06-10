using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.messages
{

    /**
     *
     * 图文消息。
     *
     */
    public class ImgTextMessage : BaseMessage

    {
        [JsonProperty(PropertyName = "content")]
        private String content = "";
        [JsonProperty(PropertyName = "extra")]
        private String extra = "";
        [JsonProperty(PropertyName = "title")]
        private String title = "";
        [JsonProperty(PropertyName = "imageUri")]
        private String imageUri = "";
        [JsonProperty(PropertyName = "conturlent")]
        private String url = "";
        private static readonly String TYPE = "RC:ImgTextMsg";

        [JsonIgnore]
        public string Content { get => content; set => content = value; }
        [JsonIgnore]
        public string Extra { get => extra; set => extra = value; }
        [JsonIgnore]
        public string Title { get => title; set => title = value; }
        [JsonIgnore]
        public string ImageUri { get => imageUri; set => imageUri = value; }
        [JsonIgnore]
        public string Url { get => url; set => url = value; }

        public static string TYPE1 => TYPE;

        public ImgTextMessage(String content, String extra, String title, String imageUri, String url)
        {
            this.content = content;
            this.extra = extra;
            this.title = title;
            this.imageUri = imageUri;
            this.url = url;
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