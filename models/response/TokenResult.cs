using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/**
 * getToken 返回结果
 */
namespace io.rong.models.response
{
    class TokenResult : Result
    {
        // 用户 Token，可以保存应用内，长度在 256 字节以内.用户 Token，可以保存应用内，长度在 256 字节以内。
        [JsonProperty(PropertyName = "token")]
        String token;
        // 用户 Id，与输入的用户 Id 相同.
        [JsonProperty(PropertyName = "userId")]
        private String userId;

        public TokenResult(int code, String token, String userId, String errorMessage)
        {
            this.code = code;
            this.token = token;
            this.userId = userId;
            this.msg = errorMessage;
        }

        [JsonIgnore]
        public String Token

        {
            get { return this.token; }
            set { this.token = value; }
        }

        [JsonIgnore]
        public string UserId { get => userId; set => userId = value; }
        [JsonIgnore]
        public string UserId1 { get => userId; set => userId = value; }

        override
        public String ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }

    }
}
