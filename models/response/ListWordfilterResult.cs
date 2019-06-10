using Newtonsoft.Json;
using io.rong.models.sensitiveword;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.models.response
{
    class ListWordfilterResult:Result
    {
        // 敏感词内容。

        [JsonProperty(PropertyName = "words")]
        List<SensitiveWordModel> words;

        [JsonIgnore]
        public List<SensitiveWordModel> Words { get => words; set => words = value; }

        public ListWordfilterResult()
        {
        }

        public ListWordfilterResult(int code, List<SensitiveWordModel> words, String errorMessage):base(code, errorMessage)
        {
            this.code = code;
            this.words = words;
            this.msg = errorMessage;
        }

        override
        public String ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
