using io.rong.models.chatroom;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.models.response
{
    class CheckChatRoomUserResult
    {
        [JsonProperty(PropertyName = "code")]
        private String code;
        [JsonProperty(PropertyName = "isInChrm")]
        private Boolean isInChrm;

        [JsonIgnore]
        public string Code { get => code; set => code = value; }
        [JsonIgnore]
        public bool IsInChrm { get => isInChrm; set => isInChrm = value; }

        public CheckChatRoomUserResult(String code, Boolean isInChrm)
        {
            this.code = code;
            this.isInChrm = isInChrm;
        }

		override
		public String ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
