using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace io.rong.exception
{
    class Error
    {
        [JsonProperty(PropertyName = "url")]
        private String url;
        [JsonProperty(PropertyName = "httpCode")]
        private int httpCode = 200;
        [JsonProperty(PropertyName = "code")]
        private int code;
        [JsonProperty(PropertyName = "errorMessage")]
        private String errorMessage;

        [JsonIgnore]
        public string Url { get => url; set => url = value; }
        [JsonIgnore]
        public int HttpCode { get => httpCode; set => httpCode = value; }
        [JsonIgnore]
        public int Code { get => code; set => code = value; }
        [JsonIgnore]
        public string ErrorMessage { get => errorMessage; set => errorMessage = value; }

        public Error(int code, int httpCode, String url, String errorMessage)
        {
            this.url = url;
            this.code = code;
            this.errorMessage = errorMessage;
            this.httpCode = httpCode;
        }

        public bool HasError()
        {
            return this.code != 200;
        }

        override
        public String ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
