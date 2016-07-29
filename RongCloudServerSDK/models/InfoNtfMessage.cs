using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace io.rong.models {
    class InfoNtfMessage : Message {
        [JsonProperty]
        private String message, extra;

        public String getMessage() {
            return message;
        }

        public void setMessage(String message) {
            this.message = message;
        }

        public String getExtra() {
            return extra;
        }

        public void setExtra(String extra) {
            this.extra = extra;
        }

        public InfoNtfMessage(String message) {
            this.type = "RC:InfoNtf";
            this.message = message;
        }

        public InfoNtfMessage(String message, String extra) : this(message) {
            this.extra = extra;
        }

        public override string toString() {
            JsonSerializerSettings jsetting = new JsonSerializerSettings();
            jsetting.NullValueHandling = NullValueHandling.Ignore;
            return JsonConvert.SerializeObject(this);
        }
    }
}
