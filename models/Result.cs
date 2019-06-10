using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.models
{
    public class Result

    {
        /**
     * 返回码，200 为正常。
     *
     */
        [JsonProperty(PropertyName = "code")]
        protected int code;
        /**
         * 错误信息。
         *
         */
        [JsonProperty(PropertyName = "msg")]
        protected String msg;

        [JsonIgnore]
        public int Code { get => code; set => code = value; }
        [JsonIgnore]
        public string Msg { get => msg; set => msg = value; }

        public Result(int code, String msg)
        {
            this.code = code;
            this.msg = msg;
        }

        public Result()
        {

        }
        /**
         * 设置code
         *
         */
        public void setCode(int code)
        {
            this.code = code;
        }

        /**
         * 获取code
         *
         * @return int
         */
        public int getCode()
        {
            return code;
        }

        /**
         * 获取msg
         *
         * @return String
         */
        public String getMsg()
        {
            return this.msg;
        }
        /**
         * 设置msg
         *
         */
        public void setMsg(String msg)
        {
            this.msg = msg;
        }
    }
}
