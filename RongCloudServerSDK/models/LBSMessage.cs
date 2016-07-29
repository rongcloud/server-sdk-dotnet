using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace io.rong.models {
    class LBSMessage : Message {
        [JsonProperty]
        private String content, extra;
        [JsonProperty]
        private float latitude, longitude;

        public String getContent() {
            return content;
        }

        public void setContent(String content) {
            this.content = content;
        }

        public float getLatitude() {
            return this.latitude;
        }

        public void setLatitude(float latitude) {
            this.latitude = latitude;
        }

        public float getLongitude() {
            return this.longitude;
        }

        public void setLongitude(float longitude) {
            this.longitude = longitude;
        }

        public String getExtra() {
            return extra;
        }

        public void setExtra(String extra) {
            this.extra = extra;
        }

        public LBSMessage(String content, float latitude, float longitude) {
            this.type = "RC:LBSMsg";
            this.content = content;
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public LBSMessage(String content, float latitude, float longitude, String extra) : this(content, latitude, longitude) {
            this.extra = extra;
        }

        public override string toString() {
            JsonSerializerSettings jsetting = new JsonSerializerSettings();
            jsetting.NullValueHandling = NullValueHandling.Ignore;
            return JsonConvert.SerializeObject(this);
        }
    }
}
