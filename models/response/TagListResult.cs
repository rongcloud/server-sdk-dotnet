using io.rong.models.push.tag;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace io.rong.models.response
{
    public class TagListResult : Result
    {
        [JsonProperty(PropertyName = "result")]
        Dictionary<String, String[]> result;

        [JsonIgnore]
        public Dictionary<string, String[]> Result { get => result; set => result = value; }

        override
        public String ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
