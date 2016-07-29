using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace io.rong.models {
    class ProfileNtfMessage :Message {
        [JsonProperty]
        private String operation, extra;
        [JsonProperty]
        private Dictionary<String, String> data;

        public String getOperation() {
            return operation;
        }

        public void setOperation(String operation) {
            this.operation = operation;
        }

        public Dictionary<String, String> getData() {
            return this.data;
        }

        public void setData(Dictionary<String, String> data) {
            this.data = data;
        }

        public String getExtra() {
            return extra;
        }

        public void setExtra(String extra) {
            this.extra = extra;
        }

        public ProfileNtfMessage(String operation, Dictionary<String, String> data) {
            this.type = "RC:ProfileNtf";
            this.operation = operation;
        }

        public ProfileNtfMessage(String operation, Dictionary<String, String> data, String extra) : this(operation, data) {
            this.extra = extra;
        }

        public override string toString() {
            JsonSerializerSettings jsetting = new JsonSerializerSettings();
            jsetting.NullValueHandling = NullValueHandling.Ignore;
            return JsonConvert.SerializeObject(this);
        }
    }
}
