using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace io.rong.models {
    class VoiceMessage : Message {
        [JsonProperty]
        private String content, duration, extra;

        public String getContent() {
            return content;
        }

        public void setContent(String content) {
            this.content = content;
        }

        public String getDuration() {
            return this.duration;
        }

        public void setDuration(String uri) {
            this.duration = uri;
        }

        public String getExtra() {
            return extra;
        }

        public void setExtra(String extra) {
            this.extra = extra;
        }

        public VoiceMessage(String content, String duration) {
            this.type = "RC:VcMsg";
            this.duration = duration;
            this.content = content;
        }

        public VoiceMessage(String content, String duration, String extra) : this(content, duration) {
            this.extra = extra;
        }

        public override string toString() {
            JsonSerializerSettings jsetting = new JsonSerializerSettings();
            jsetting.NullValueHandling = NullValueHandling.Ignore;
            return JsonConvert.SerializeObject(this);
        }
    }
}
