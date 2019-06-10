using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.models.response
{
    public class ResponseResult : Result

    {
        public ResponseResult(int code, string msg) : base(code, msg)
        {
            this.code = code;
            this.msg = msg;
        }

        override
        public String ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }

    }
}
