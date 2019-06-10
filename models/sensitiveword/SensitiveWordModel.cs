using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.models.sensitiveword
{
    /**
     * 敏感词、替换词信息
     */
    public class SensitiveWordModel

    {
        /**
         * 敏感词类型
         */
        [JsonProperty(PropertyName = "type")]
        int type = 1;
        /**
         *敏感词
         */
        [JsonProperty(PropertyName = "keyword")]
        String keyword;
        /**
         *替换词
         */
        [JsonProperty(PropertyName = "replace")]
        String replace;

        [JsonIgnore]
        public int Type { get => type; set => type = value; }
        [JsonIgnore]
        public string Keyword { get => keyword; set => keyword = value; }
        [JsonIgnore]
        public string Replace { get => replace; set => replace = value; }

        public SensitiveWordModel(int type, String keyword, String replace)
        {
            this.type = type;
            this.keyword = keyword;
            this.replace = replace;
        }

        public SensitiveWordModel()
        {
        }

        override
        public String ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
