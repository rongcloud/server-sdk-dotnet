using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace io.rong.models.response
{
    /**
     * push 返回结果
     */
    public class PushResult : Result
    {

        /**
         * 推送唯一标识。
         */
        private String id;

        public String GetId()
        {
            return id;
        }

        public void SetId(String id)
        {
            this.id = id;
        }


        public PushResult(int code, String id) : base(code, id)
        {
            this.code = code;
            this.id = id;
        }

        override
        public String ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
