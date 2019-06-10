using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.models.response
{
    /**
     * historyMessage返回结果
     */
    public class HistoryMessageResult : Result

    {

        // 历史消息下载地址。
        [JsonProperty(PropertyName = "url")]
        String url;
        // 历史记录时间。（yyyymmddhh）
        [JsonProperty(PropertyName = "date")]
        String date;

        [JsonIgnore]
        public string Url { get => url; set => url = value; }
        [JsonIgnore]
        public string Date { get => date; set => date = value; }

        public HistoryMessageResult(int code, String url, String date, String errorMessage):base(code, errorMessage)
        {
            this.code = code;
            this.url = url;
            this.date = date;
            this.msg = errorMessage;
        }

        override
        public String ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}