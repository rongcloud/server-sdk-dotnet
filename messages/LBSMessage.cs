using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.messages
{

    /**
     *
     * 位置消息。
     *
     */
    public class LBSMessage : BaseMessage

    {
        [JsonProperty(PropertyName = "content")]
        private String content = "";
        [JsonProperty(PropertyName = "extra")]
        private String extra = "";
        [JsonProperty(PropertyName = "latitude")]
        private double latitude = 0;
        [JsonProperty(PropertyName = "longitude")]
        private double longitude = 0;
        [JsonProperty(PropertyName = "poi")]
        private String poi = "";
        private static readonly String TYPE = "RC:LBSMsg";

        [JsonIgnore]
        public string Content { get => content; set => content = value; }
        [JsonIgnore]
        public string Extra { get => extra; set => extra = value; }
        [JsonIgnore]
        public double Latitude { get => latitude; set => latitude = value; }
        [JsonIgnore]
        public double Longitude { get => longitude; set => longitude = value; }
        [JsonIgnore]
        public string Poi { get => poi; set => poi = value; }

        public LBSMessage(String content, String extra, double latitude, double longitude, String poi)
        {
            this.content = content;
            this.extra = extra;
            this.latitude = latitude;
            this.longitude = longitude;
            this.poi = poi;
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