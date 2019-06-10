using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.models.response
{
    class CheckOnlineResult : Result
    {
        // 在线状态，1为在线，0为不在线。
        [JsonProperty(PropertyName = "status")]
        String status;

        public string Status { get => status; set => status = value; }

        public CheckOnlineResult(int code, String status, String errorMessage):base(code, errorMessage)
        {
            this.code = code;
            this.status = status;
            this.msg = errorMessage;
        }
        /**
         * 设置status
         *
         */
        public void setStatus(String status)
        {
            this.status = status;
        }

        /**
         * 获取status
         *
         * @return String
         */
        public String getStatus()
        {
            return status;
        }

        override
        public String ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
