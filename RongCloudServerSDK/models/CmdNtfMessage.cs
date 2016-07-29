using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace io.rong.models {
    class CmdNtfMessage : Message {
        [JsonProperty]
        private String name;
        [JsonProperty]
        private Dictionary<String, String> data;

        public String getName() {
            return name;
        }

        public void setName(String name) {
            this.name = name;
        }

        public Dictionary<String, String> getData() {
            return this.data;
        }

        public void setData(Dictionary<String, String> data) {
            this.data = data;
        }

        public CmdNtfMessage(String name, Dictionary<String, String> data) {
            this.type = "RC:CmdNtf";
            this.name = name;
            this.data = data;
        }

        public override string toString() {
            JsonSerializerSettings jsetting = new JsonSerializerSettings();
            jsetting.NullValueHandling = NullValueHandling.Ignore;
            return JsonConvert.SerializeObject(this);
        }
    }
}
