using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace io.rong.models {
    public class TxtMessage : Message {
        [JsonProperty]
        private String content, extra;

        public String getContent() {
            return content;
        }

        public void setContent(String content) {
            this.content = content;
        }

        public String getExtra() {
            return extra;
        }

        public void setExtra(String extra) {
            this.extra = extra;
        }

        public TxtMessage(String content) {
            this.type = "RC:TxtMsg";
            this.content = content;
        }

        public TxtMessage(String content, String extra) : this(content) {
            this.extra = extra;
        }

        public override string toString() {
            JsonSerializerSettings jsetting = new JsonSerializerSettings();
            jsetting.NullValueHandling = NullValueHandling.Ignore;
            return JsonConvert.SerializeObject(this);
        }
    }
}
