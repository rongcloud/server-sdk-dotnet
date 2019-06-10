using System;
using Newtonsoft.Json;

namespace io.rong.models.push
{
    /**
     * 广播消息体。
     */
    public class BroadcastModel : BroadcastPushPublicPart
    {

        /**
         *  发送人用户 Id。（必传）
         */
        [JsonProperty(PropertyName = "fromuserid")]
        private String fromuserid;

        /**
         * 发送消息内容（必传）
         */
        [JsonProperty(PropertyName = "message")]
        private Message message;

        public String GetFromuserid()
        {
            return fromuserid;
        }

        public void SetFromuserid(String fromuserid)
        {
            this.fromuserid = fromuserid;
        }

        public Message GetMessage()
        {
            return message;
        }

        public void SetMessage(Message message)
        {
            this.message = message;
        }

        override
        public String ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
