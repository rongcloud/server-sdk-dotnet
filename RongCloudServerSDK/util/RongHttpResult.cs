using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace io.rong.util {
    public class RongHttpResult {
        [JsonProperty]
        private int httpCode;
        [JsonProperty]
        private String result;

        public RongHttpResult(int code, String result) {
            this.httpCode = code;
            this.result = result;
        }

        public int getHttpCode() {
            return this.httpCode;
        }

        public String getResult() {
            return this.result;
        }

        public String toString() {
            return JsonConvert.SerializeObject(this);
        }
    }
}
